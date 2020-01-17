using System;
using System.Threading.Tasks;
using XamarinCI.Core.BusinessServices.Interfaces.Common;

namespace LogicTest.MockSerivces
{
    public class MockClipboardService : IClipboardService
    {
        public bool HasText => throw new NotImplementedException();

        public Task<string> GetTextAsync()
        {
            throw new NotImplementedException();
        }

        public void SetText(string text)
        {
            throw new NotImplementedException();
        }
    }
}
