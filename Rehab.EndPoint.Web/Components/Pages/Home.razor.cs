//using Microsoft.JSInterop;

//namespace Rehab.EndPoint.Web.Components.Pages
//{
//    public partial class Home
//    {
//        private IJSObjectReference? jsModule;

//        protected override async Task OnAfterRenderAsync(bool firstRender)
//        {
//            if (firstRender)
//            {
//                jsModule = await jSRuntime.InvokeAsync<IJSObjectReference>("import", "/js/home.js");
//                await jsModule.InvokeVoidAsync("initialize");
//            }

//        }
//        public async ValueTask DisposeAsync()
//        {
//            if (jsModule != null)
//            {
//                await jsModule.DisposeAsync();
//            }
//        }
//    }
//}
