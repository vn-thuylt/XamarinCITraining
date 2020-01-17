using System;
using System.Threading.Tasks;
namespace XamarinCI.Core.BusinessServices.Interfaces.Common
{
    public interface IStartupService
    {
        void PrepareMetaDataInBackground();
    }
}
