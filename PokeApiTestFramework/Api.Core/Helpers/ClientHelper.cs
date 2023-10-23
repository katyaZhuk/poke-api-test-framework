using Api.Core.Models.BerryModels;
using Api.Core.Models.PokemonModels;
using Api.Core.Rest.Api;
using Api.Core.Rest.Response;

namespace Api.Core.Helpers
{
    public class ClientHelper
   {
      private readonly Client _client;

      public ClientHelper(Client client)
      {
         _client = client;
      }

      public Response<BerryResult> GetAllBerries() => _client.GetAllBerries();

      public Response<PokemonResult> GetAllPokemons() => _client.GetAllPokemons();

      public Response GetPokemonBy(string name) => _client.GetPokemonBy(name);
   }
}
