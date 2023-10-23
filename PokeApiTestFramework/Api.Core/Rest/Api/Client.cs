using Api.Core.Attributes;
using Api.Core.Models.BerryModels;
using Api.Core.Rest.Response;

namespace Api.Core.Rest.Api
{
    public class Client : BaseApiClient
   {
      [HttpGet("/berry")]
      public Response<BerryResult> GetAllBerries()
      {
         return Send<BerryResult>(new Request.Request
         {
            Headers = Headers,
         });
      }
   }
}
