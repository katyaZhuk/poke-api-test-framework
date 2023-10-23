using Api.Core.Extentions;
using Flurl.Http;
using System.Net;

namespace Api.Core.Rest.Response
{
   public class Response
   {
      private readonly IFlurlResponse _flurlRresponse;

      public Response(IFlurlResponse response, bool logResponse = true)
      {
         _flurlRresponse = response;

         if (!logResponse)
         {
            return;
         }

         switch (StatusCode)
         {
            case (int)HttpStatusCode.OK:
               break;
            case (int)HttpStatusCode.NoContent:
               break;
         }
      }

      public int StatusCode => _flurlRresponse.StatusCode;

      public string Content => _flurlRresponse.GetStringAsync().Result.FormatJsonOrDefault();
   }
}
