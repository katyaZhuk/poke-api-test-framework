using Api.Core.Helpers;
using Api.Core.Rest.Response;
using Flurl.Http;

namespace Api.Core.Extentions
{
   internal static class FlurlResponseExtensions
   {
      public static Response<T, TD> Response<T, TD>(this IFlurlResponse response) => new Response<T, TD>(response);

      public static Response<T> Response<T>(this IFlurlResponse response) => new Response<T>(response);

      public static Response Response(this IFlurlResponse response) => new Response(response);

      public static IFlurlResponse GetResultWithRetry(this Task<IFlurlResponse> response)
      {
         try
         {
            return response.GetAwaiter().GetResult();
         }
         catch (FlurlHttpException e)
         {
            Logger.Log.Debug($"{e.Message}. Try Again");

            return response.GetAwaiter().GetResult();
         }
      }
   }
}
