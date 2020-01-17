using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinCI.Core.Constants;

namespace XamarinCI.UI.Views.Templet
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CellListViewMain : ViewCell
    {
        public CellListViewMain()
        {
            InitializeComponent();
        }
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            if (BindingContext != null)
            {
                switch (lbrequest.Text)
                {
                    case HTTPMethodAPI.GetMethod:
                        bvRequest.BackgroundColor = Color.FromHex("#61AFFE");
                        FrameMain.BackgroundColor = Color.FromHex("#b0faff");
                        break;

                    case HTTPMethodAPI.PostMethod:
                        bvRequest.BackgroundColor = Color.FromHex("#97ff57");
                        FrameMain.BackgroundColor = Color.FromHex("#ceffb0");
                        break;
                    case HTTPMethodAPI.PatchMethod:
                        bvRequest.BackgroundColor = Color.FromHex("#00d0ff");
                        FrameMain.BackgroundColor = Color.FromHex("#85e9ff");
                        break;

                    case HTTPMethodAPI.DeletetMethod:
                        bvRequest.BackgroundColor = Color.FromHex("#ff2b2b");
                        FrameMain.BackgroundColor = Color.FromHex("#ff7878");
                        break;

                    default:
                        bvRequest.BackgroundColor = Color.FromHex("#61AFFE");
                        FrameMain.BackgroundColor = Color.FromHex("#b0faff");
                        break;
                }

            }
        }
    }
}
