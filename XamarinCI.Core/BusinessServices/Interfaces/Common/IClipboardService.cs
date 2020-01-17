using System.Threading.Tasks;

namespace XamarinCI.Core.BusinessServices.Interfaces.Common
{
    public interface IClipboardService
    {
        bool HasText { get; }
        Task<string> GetTextAsync();
        void SetText(string text);
    }
}
