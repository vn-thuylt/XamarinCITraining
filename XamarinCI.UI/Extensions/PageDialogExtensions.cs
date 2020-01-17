using System;
using Prism.Services;
using XamarinCI.UI.Languages;
using System.Threading.Tasks;

namespace XamarinCI.UI.Extensions
{
    public static class PageDialogExtensions
    {
        public static Task<bool> Confirm(this IPageDialogService pageDialogService, string confirmMessage)
         => pageDialogService.DisplayAlertAsync(AppResource.MessageTitleConfirm, confirmMessage, AppResource.MessageButtonOk, AppResource.MessageButtonCancel);

        public static Task Info(this IPageDialogService pageDialogService, string message)
         => pageDialogService.DisplayAlertAsync(AppResource.MessageTitleInfo, message, AppResource.MessageButtonOk);

        public static Task Warning(this IPageDialogService pageDialogService, string message)
         => pageDialogService.DisplayAlertAsync(AppResource.MessageTitleWarning, message, AppResource.MessageButtonOk);

        public static Task Error(this IPageDialogService pageDialogService, string message)
         => pageDialogService.DisplayAlertAsync(AppResource.MessageTitleError, message, AppResource.MessageButtonOk);
    }
}
