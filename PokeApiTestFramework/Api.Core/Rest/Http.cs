using Api.Core.Extentions;
using Api.Core.Helpers;
using Api.Core.Rest.Api;
using Api.Core.Rest.Request;
using Api.Core.Rest.Response;
using Api.Core.Utils;
using Flurl.Http;
using Flurl.Http.Configuration;
using System.Text;

namespace Api.Core.Rest
{
   public class Http<T>
      where T : BaseHttpUrlManager
   {
      private readonly T _baseHttpUrlManager;

      public Http(T baseHttpUrlManager)
      {
         _baseHttpUrlManager = baseHttpUrlManager;

         FlurlHttp.ConfigureClient(_baseHttpUrlManager.BaseUrl, cli =>
            cli.Settings.HttpClientFactory = new UntrustedCertClientFactory());
      }

      public Response.Response Send(Request.Request request)
      {
         return GetResponse(
            request.Content.ToString(),
            request.Route,
            request.QueryParameters.AddToDictionary(),
            request.Headers.AddToDictionary(),
            Request.Request.CompletionOption)
          .Response();
      }

      public Response<TD> Send<TD>(Request.Request request)
      {
         return GetResponse(
            request.Content.ToString(),
            request.Route,
            request.QueryParameters.AddToDictionary(),
            request.Headers.AddToDictionary(),
            Request.Request.CompletionOption)
          .Response<TD>();
      }

      public Response<TU, TD> Send<TU, TD>(Request.Request request)
      {
         return GetResponse(
            request.Content.ToString(),
            request.Route,
            request.QueryParameters.AddToDictionary(),
            request.Headers.AddToDictionary(),
            Request.Request.CompletionOption)
          .Response<TU, TD>();
      }

      private IFlurlResponse GetResponse(
         string content = "",
         Route route = null,
         IDictionary<string, string> urlParameters = null,
         IDictionary<string, string> headers = null,
         HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead)
      {
         var method = AttributeProcessor.GetHttpMethod();

         var requestUrl = _baseHttpUrlManager.GetRequestedUrl(route, urlParameters);

         var createdHeader = HttpHeaderManager.CreateHeader(headers);

         var httpContent = new StringContent(content, Encoding.UTF8, "application/json");

         var methodName = method.Method;

         Logger.Log.Information("--------------------Request--------------------");

         Logger.Log.Information($"Starting {methodName} request be URL:");

         Logger.Log.Information(requestUrl);

         var result = requestUrl
            .AllowAnyHttpStatus()
            .WithHeaders(createdHeader)
            .SendAsync(method, httpContent, default, completionOption)
            .GetResultWithRetry();

         if (!(result.StatusCode >= 200 && result.StatusCode < 300))
         {
            Logger.Log.Information(content != string.Empty ? $"Content: {content}" : $"No Content: {content}");
         }

         Logger.Log.Debug("--------------------Response--------------------");

         Logger.Log.Debug("Response Status:" + result.StatusCode);

         return result;
      }

      private class UntrustedCertClientFactory : DefaultHttpClientFactory
      {
         public override HttpMessageHandler CreateMessageHandler()
         {
            return new HttpClientHandler
            {
               ServerCertificateCustomValidationCallback =
                  (requestMessage, certificate, chain, policyErrors) => true,
            };
         }
      }
   }
}
