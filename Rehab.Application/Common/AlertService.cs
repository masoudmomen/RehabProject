using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehab.Application.Common
{
    public class AlertService
    {
        public event Func<string, string, Task>? OnShow;

        public Task ShowAsync(string message, string type = "success")
        {
            return OnShow?.Invoke(message,type) ?? Task.CompletedTask;
        }
    }
}
