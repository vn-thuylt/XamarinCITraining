using System;
namespace XamarinCI.Core.Storage.Settings
{
    public class BussinessSettings
    {
        public BussinessSettings()
        {
            Language = "en";// default english
        }
        public string Language { get; set; }
    }
}
