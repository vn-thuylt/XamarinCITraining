using System;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using XamarinCI.Core.BusinessServices.Interfaces.Common;

namespace XamarinCI.Droid.Services.Implementations
{
    public class ClipboardService : IClipboardService
    {
        public bool HasText => !string.IsNullOrEmpty(GetTextInternal());

        public Task<string> GetTextAsync()
        {
            return Task.FromResult(GetTextInternal());
        }

        public void SetText(string text)
        {
            var clipboardManager = (ClipboardManager)Application.Context.GetSystemService(Context.ClipboardService);
            clipboardManager.Text = text;
        }

        private string GetTextInternal()
        {
            var clipboardManager = (ClipboardManager)Application.Context.GetSystemService(Context.ClipboardService);
            return clipboardManager.Text;
        }
    }
}
