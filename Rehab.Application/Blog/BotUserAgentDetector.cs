namespace Rehab.Application.Blog
{
 
    public static class BotUserAgentDetector
    {
        private static readonly string[] Markers =
        {
            "bot", "crawl", "spider", "slurp", "scraper",
            "facebookexternalhit", "facebot", "whatsapp", "telegrambot",
            "slackbot", "slack-imgproxy", "twitterbot", "discordbot", "linkedinbot",
            "embedly", "pinterest", "redditbot", "quora link preview", "skypeuripreview",
            "bingpreview", "google-inspectiontool", "googleweblight", "googleother",
            "headlesschrome", "phantomjs", "puppeteer", "playwright",
            "lighthouse", "pagespeed", "gtmetrix", "pingdom", "uptimerobot",
            "statuscake", "site24x7", "newrelicpinger",
            "curl", "wget", "python-requests", "python-httpx", "aiohttp",
            "go-http-client", "java/", "okhttp", "libwww-perl", "axios/",
            "ahrefsbot", "semrushbot", "mj12bot", "dotbot", "petalbot", "dataforseo",
        };

        public static bool IsBot(string? userAgent)
        {
            if (string.IsNullOrWhiteSpace(userAgent))
                return true; // no UA at all -> almost always automated

            var ua = userAgent.ToLowerInvariant();
            foreach (var marker in Markers)
            {
                if (ua.Contains(marker))
                    return true;
            }
            return false;
        }
    }
}
