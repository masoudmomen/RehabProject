using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehab.Application.Common
{
    public class SearchService
    {
        public event Action<string?>? OnSearchRequested;

        public async Task RequestSearch(string? text)
        {
            OnSearchRequested?.Invoke(text);
        }
    }
}
