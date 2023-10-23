using Api.Core.Attributes;
using Api.Core.Models.BerryModels;
using Api.Core.Models.PokemonModels;
using Api.Core.Rest.Response;
using System.Net;

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

      [HttpGet("/pokemon")]
      public Response<PokemonResult> GetAllPokemons()
      {
         return Send<PokemonResult>(new Request.Request
         {
            Headers = Headers,
         });
      }

      [HttpGet("/pokemon/{name}")]
      public Response<Pokemon> GetPokemonBy(string name)
      {
         Request.Request request = new Request.Request(new Dictionary<string, string>
         {
            { "name", name },
         })
         {
            Headers = Headers,
         };

         return Send<Pokemon>(request);
      }
   }
}
