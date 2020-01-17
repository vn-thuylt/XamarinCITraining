using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Navigation;
using Xamarin.Forms;
using XamarinCI.Core.ApiDefinitions;
using XamarinCI.Core.ApiDefinitions.Orgs;
using XamarinCI.Core.BusinessServices.Dtos.ApiDto;
using XamarinCI.Core.BusinessServices.Dtos.Orgs;
using XamarinCI.Core.BusinessServices.Dtos.User;
using XamarinCI.Core.BusinessServices.Interfaces.User;
using XamarinCI.Core.Constants;
using XamarinCI.Core.Infrastructure.Networking.Base;
using XamarinCI.Core.Shared;
using XamarinCI.UI.ViewModels.Base;

namespace XamarinCI.UI.ViewModels.Common
{
    public class HomePageViewModel : ViewModelBase
    {
        private ObservableCollection<ApiModels> apiModels = new ObservableCollection<ApiModels>();
        public ObservableCollection<ApiModels> ApiModels { get { return apiModels; } }
        string org_name = "runsystem";
        string user_name = "thuylt";
        string team_name = "xamarin_training";
        string distribution_group_name = "xamarin_group";
        string owner_name = "runsystem";
        string app_name = "xamarinci";
        bool isRefreshing = false;
        public bool IsRefreshing
        {
            get { return isRefreshing; }
            set { SetProperty(ref isRefreshing, value); }
        }

        bool isShowLayout = false;
        public bool IsShowLayout
        {
            get { return isShowLayout; }
            set { SetProperty(ref isShowLayout, value); }
        }
        bool runActivity = false;
        public bool RunActivity
        {
            get { return runActivity; }
            set { SetProperty(ref runActivity, value); }
        }

        string dataitem;
        public string DataItem
        {
            get { return dataitem; }
            set { SetProperty(ref dataitem, value); }
        }
        string tokenid;
        public string TokenID
        {
            get { return tokenid; }
            set { SetProperty(ref tokenid, value); }
        }

        public ICommand RefreshListApiCommand { get; set; }
        public ICommand BackCommand { get; set; }

        private DelegateCommand<ApiModels> _seletedItemCommand;
        public DelegateCommand<ApiModels> SeletedItemCommand => _seletedItemCommand ?? (_seletedItemCommand = new DelegateCommand<ApiModels>(async (arg) => await SelectedItemCommandExecute(arg)));
        public HomePageViewModel(INavigationService navigationService) : base(navigationService)
        {
            RefreshListApiCommand = new Command(HandleRefreshList);
            BackCommand = new Command(HandleBack);
            TokenID = RequestBase.Token;

        }
        public async Task SelectedItemCommandExecute(ApiModels arg)
        {
            IsShowLayout = true;
            DataItem = arg.Data;

        }

        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            RunActivity = true;
            for (int i = 0; i < 3; i++)
            {
                await CallApi();
            }
            RunActivity = false;
        }
        private void HandleBack(object obj)
        {
            IsShowLayout = false;

        }
        private async void HandleRefreshList(object obj)
        {
            IsRefreshing = true;
            await CallApi();
            IsRefreshing = false;
        }

        public string ConverterToJson(object ApiResult)
        {
            return JsonConvert.SerializeObject(ApiResult);
        }

        private async Task CallApi()
        {

            //var userService = DependencyRegistrar.Current.Resolve<IUserService>();
            //var userInfo = await userService.Get();
            var orgsService = DependencyRegistrar.Current.Resolve<IOrgsApi>();
            var orgUser = await orgsService.GetUser(org_name, user_name);
            var orgsTesters = await orgsService.GetTesters(org_name);

            ApiModels.Add(new ApiModels { HTTPMethods = HTTPMethodAPI.GetMethod, NameAPIs = $"v{ApiHosts.AppCenterApiVersion}{NameMethodAPI.GetUser}", Data = ConverterToJson(orgUser) });
            ApiModels.Add(new ApiModels { HTTPMethods = HTTPMethodAPI.PostMethod, NameAPIs = $"v{ApiHosts.AppCenterApiVersion}{NameMethodAPI.GetTesters}", Data = ConverterToJson(orgsTesters) });


        }
    }
}
