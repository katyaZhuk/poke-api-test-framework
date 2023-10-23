using Api.Core.Helpers;
using Api.Core.Models.PokemonModels;
using Api.Core.Rest.Response;
using NUnit.Framework;

namespace Api.Test.StepDefinitions
{
   [Binding]
   [Scope(Feature = "ValidationGet_Pokemon_Endpoint")]
   [Scope(Feature = "ValidationGet_Pokemon_Name_Endpoint")]
   public class PokemonSteps
   {
      private readonly ClientHelper _clientHelper;

      private readonly ScenarioContext _scenarioContext;

      public PokemonSteps(ClientHelper clientHelper, ScenarioContext scenarioContext)
      {
         _clientHelper = clientHelper;
         _scenarioContext = scenarioContext;
      }

      [When("I try to call '(get pokemons)' endpoint")]
      public void WhenITryToCallEndpoint(string endpoint)
      {
         var response = _clientHelper.GetAllPokemons();

         _scenarioContext.Add(endpoint, response);
      }

      [When(@"I try to call '(get pokemon/{name})' endpoint with '(.+)' name")]
      public void WhenITryToCallEndpointWithName(string endpoint, string name)
      {
         var response = _clientHelper.GetPokemonBy(name);

         _scenarioContext.Add(endpoint, response);
      }

      [Then("the response of '(get pokemons)' endpoint will have successful code")]
      public void TheTheResponseOfEndpointWillHaveSuccessfulCode(string endpoint)
      {
         var pokemonResult = _scenarioContext.Get<Response<PokemonResult>>(endpoint);

         Assert.That(pokemonResult.StatusCode, Is.EqualTo(200),
            "Status code is not 200");
      }

      [Then("the '(get pokemons)' endpoint will return 20 pokemon models")]
      public void TheTheEndpointWillReturn20PokemonModels(string endpoint)
      {
         var pokemons = _scenarioContext.Get<Response<PokemonResult>>(endpoint).SuccessModel.Results;

         Assert.That(pokemons, Has.Count.EqualTo(20),
            "Response model does not contain 20 pokemons");
      }
   }
}
