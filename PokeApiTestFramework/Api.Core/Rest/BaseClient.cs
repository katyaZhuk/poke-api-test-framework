using Api.Core.Rest.Response;
using System.Net;

namespace Api.Core.Rest
{
   public class BaseClient
   {
      protected BaseClient()
      {
         Http = new Http<BaseHttpUrlManager>(new BaseHttpUrlManager());

         ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, errors) => true;
      }

      protected List<(string, string)> Headers { get; set; } = new List<(string, string)> { };

      protected Http<BaseHttpUrlManager> Http { get; set; }

      protected Response.Response Send(Request.Request request)
      {
         var response = Http.Send(request);

         return response;
      }

      protected Response<T> Send<T>(Request.Request request)
      {
         var response = Http.Send<T>(request);

         return response;
      }

      protected Response<T, TD> Send<T, TD>(Request.Request request)
      {
         var response = Http.Send<T, TD>(request);

         return response;
      }
   }
}
