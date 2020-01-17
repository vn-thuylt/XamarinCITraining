using System;
using System.Reflection;
using System.Resources;
using Plugin.Multilingual;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

/* ==================================================================================================
 * caution: put this class in the same folder with all your resource files
 * more info: https://xamgirl.com/multilingual-localization-plugin-for-xamarin/
 *===============================================================================================*/
namespace XamarinCI.UI.Languages
{
    [ContentProperty("Key")]
    public class TranslateExtension : IMarkupExtension
    {
        static readonly string ResourceId = $"{typeof(TranslateExtension).Namespace}.{nameof(AppResource)}";
        static readonly Lazy<ResourceManager> resmgr = new Lazy<ResourceManager>(() => new ResourceManager(ResourceId, typeof(TranslateExtension).GetTypeInfo().Assembly));

        public static string GetLocalizedString(string key)
        {
            try
            {
                if (key == null)
                    return string.Empty;
                return resmgr.Value.GetString(key, CrossMultilingual.Current.CurrentCultureInfo);
            }
            catch (Exception ex)
            {
#if DEBUG
                throw ex;
#else
                return key;
#endif
            }
        }

        public string Key { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            try
            {
                if (Key == null)
                    return string.Empty;
                var ci = CrossMultilingual.Current.CurrentCultureInfo;
                var translation = resmgr.Value.GetString(Key, ci);
                if (translation == null)
                {
#if DEBUG
                    throw new ArgumentException(string.Format("Key '{0}' was not found in resources '{1}' for culture '{2}'.", Key, ResourceId, ci.Name), nameof(Key));
#else
                    translation = Key; // returns the key, which GETS DISPLAYED TO THE USER
#endif
                }
                return translation;
            }
            catch (Exception ex)
            {
#if DEBUG
                throw ex;
#else
                return Key;
#endif
            }
        }
    }
}
