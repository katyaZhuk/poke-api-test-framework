﻿using Api.Core.Attributes;
using Api.Core.Models.BerryModels;
using Api.Core.Models.PokemonModels;
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

      [HttpGet("/pokemon")]
      public Response<PokemonResult> GetAllPokemons()
      {
         return Send<PokemonResult>(new Request.Request
         {
            Headers = Headers,
         });
      }
   }
}
