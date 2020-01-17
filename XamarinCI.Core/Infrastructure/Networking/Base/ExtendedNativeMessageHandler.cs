using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ModernHttpClient;
#if DEBUG
using System.Diagnostics;
using XamarinCI.Core.Infrastructure.Logging;
#endif

namespace XamarinCI.Core.Infrastructure.Networking.Base
{
    public class ExtendedNativeMessageHandler : NativeMessageHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
#if DEBUG
            var stopWatch = Stopwatch.StartNew();
            LogCommon.Info($"Begin call api. Method: {request.Method.ToString()} - Resource: '{request.RequestUri.AbsolutePath ?? "---"}' - Host: '{request.RequestUri.Host ?? "---"}'");
#endif
            try
            {
                /* ==================================================================================================
                 * provide authorization bearer token if needed
                 * ================================================================================================*/
                request.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                /* ==================================================================================================
                 * authorization token
                 * ================================================================================================*/
                var token = RequestBase.Token;

                request.Headers.Add("X-API-Token", token);

                var response = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
#if DEBUG
                /* ==================================================================================================
                 * Uncomment these codes to log raw json string if you want for debug
                 * DO NOT push your changes (avoid output spam)
                 * ================================================================================================*/
                //var responseString = await response.Content.ReadAsStringAsync();
                //LogCommon.Info($"response string: {responseString}");
#endif
                return response;
            }
            finally
            {
#if DEBUG
                stopWatch.Stop();
                LogCommon.Info($"Durations for resource '{request.RequestUri.AbsolutePath ?? "---"}': {stopWatch.ElapsedMilliseconds:n0} ms");
#endif
            }
        }
    }
}
