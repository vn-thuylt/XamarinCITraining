using System;
using System.Threading.Tasks;
using UIKit;
using XamarinCI.Core.BusinessServices.Interfaces.Common;
namespace XamarinCI.iOS.Services.Implementations
{
    public class ClipboardService : IClipboardService
    {
        bool IClipboardService.HasText => !string.IsNullOrEmpty(UIPasteboard.General.String);

        Task<string> IClipboardService.GetTextAsync()
        {
            return Task.FromResult(UIPasteboard.General.String);
        }

        void IClipboardService.SetText(string text)
        {
            UIPasteboard.General.String = text;
        }
    }
}
