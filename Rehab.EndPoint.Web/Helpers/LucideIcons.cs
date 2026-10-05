using System.Collections.Concurrent;
using System.Text.RegularExpressions;
using Microsoft.Extensions.FileProviders;

namespace Rehab.EndPoint.Web.Helpers
{
    // Development-time checks for the hand-maintained Lucide sprite (wwwroot/icons/lucide-sprite.svg).
    // Every check is a no-op until EnableValidation runs (Program.cs calls it only in Development),
    // so production keeps the existing fallbacks: an unknown icon renders blank, an unmapped item gets circle-help.
    public static partial class LucideIcons
    {
        public const string SpritePath = "icons/lucide-sprite.svg";
        public const string Fallback = "circle-help";

        private static HashSet<string>? _symbols;
        private static ILogger? _logger;
        // Each problem is logged once, not on every render.
        private static readonly ConcurrentDictionary<string, byte> Reported = new();

        public static void EnableValidation(IFileProvider webRoot, ILogger logger)
        {
            var file = webRoot.GetFileInfo(SpritePath);
            if (!file.Exists)
            {
                logger.LogWarning("Lucide sprite not found at wwwroot/{Path}; icon validation is off.", SpritePath);
                return;
            }

            using var reader = new StreamReader(file.CreateReadStream());
            _symbols = SymbolId().Matches(reader.ReadToEnd())
                .Select(m => m.Groups[1].Value)
                .ToHashSet(StringComparer.Ordinal);
            _logger = logger;
        }

        // Warns when an icon name has no <symbol> in the sprite (it would render blank).
        public static void CheckName(string name, string usedBy)
        {
            if (_symbols is null || _symbols.Contains(name)) return;
            Report($"missing:{name}",
                "Lucide icon \"{Icon}\" (used by {UsedBy}) is not in wwwroot/{Path}, so it renders blank. Add its <symbol> from lucide.dev.",
                name, usedBy, SpritePath);
        }

        // Looks up a data-driven icon; unmapped names fall back to circle-help.
        public static string Resolve(IReadOnlyDictionary<string, string> map, string name, string mapName)
        {
            if (map.TryGetValue(name, out var icon)) return icon;
            if (_symbols is not null) ReportUnmapped(mapName, name);
            return Fallback;
        }

        // Startup check of a component's name -> icon map against the names it renders:
        // unmapped names, entries no longer matching any name (e.g. a renamed item), and icons missing from the sprite.
        public static void ValidateMap(string mapName, IReadOnlyDictionary<string, string> map, IEnumerable<string> names)
        {
            if (_symbols is null) return;

            var nameSet = new HashSet<string>(names, StringComparer.OrdinalIgnoreCase);
            foreach (var name in nameSet.Where(n => !map.ContainsKey(n)))
                ReportUnmapped(mapName, name);

            foreach (var (name, icon) in map)
            {
                if (!nameSet.Contains(name))
                    Report($"stale:{mapName}:{name}",
                        "{Map} maps \"{Name}\" to an icon, but no item has that name any more (renamed or removed?).",
                        mapName, name);
                CheckName(icon, $"{mapName}[\"{name}\"]");
            }
        }

        private static void ReportUnmapped(string mapName, string name) =>
            Report($"unmapped:{mapName}:{name}",
                "{Map} has no icon for \"{Name}\", so it shows the " + Fallback + " fallback. Add it to the component's Icons map.",
                mapName, name);

        private static void Report(string key, string message, params object[] args)
        {
            if (Reported.TryAdd(key, 0))
                _logger?.LogWarning(message, args);
        }

        [GeneratedRegex("<symbol\\s+id=\"([^\"]+)\"")]
        private static partial Regex SymbolId();
    }
}
