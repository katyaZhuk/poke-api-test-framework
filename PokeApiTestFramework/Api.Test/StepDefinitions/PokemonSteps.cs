using Api.Core.Generators;
using Api.Core.Generators.PokemonGenerators;
using Api.Core.Helpers;
using Api.Core.Models.PokemonModels;
using Api.Core.Rest.Response;
using Api.Core.Utils;
using Bogus.DataSets;
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

      [When("I try to call '(get pokemon/{name})' endpoint with incorrect name")]
      public void WhenITryToCallEndpointWithIncorrectName(string endpoint)
      {
         string incorrectName = BaseGenerator.IncorrectPokemonName();

         var response = _clientHelper.GetPokemonBy(incorrectName);

         _scenarioContext.Add(endpoint, response);
      }

      [Then(@"the response of '(get pokemons|get pokemon/{name})' endpoint '(should|should not)' have successful code")]
      public void TheTheResponseOfEndpointWillHaveSuccessfulCode(string endpoint, string should)
      {
         var pokemonResult = _scenarioContext.Get<Response>(endpoint);

         if (should == "should")
         {
            Assert.That(pokemonResult.StatusCode, Is.EqualTo(200),
               "Status code is not 200");
         }
         else
         {
            Assert.That(pokemonResult.StatusCode, Is.EqualTo(404),
               "Status code is not 404");
         }
      }

      [Then("the '(get pokemons)' endpoint should return 20 pokemon models")]
      public void TheTheEndpointWillReturn20PokemonModels(string endpoint)
      {
         var pokemons = _scenarioContext.Get<Response<PokemonResult>>(endpoint).SuccessModel.Results;

         Assert.That(pokemons, Has.Count.EqualTo(20),
            "Response model does not contain 20 pokemons");
      }

      [Then("the response of '(get pokemon/{name})' endpoint should contain correct '(.+)' model")]
      public void ThenTheResponseOfEndpointWillContainCorrectPokemonModel(string endpoint, string name)
      {
         var pokemon = _scenarioContext.Get<Response<Pokemon>>(endpoint).SuccessModel;

         switch (name)
         {
            case "pikachu":
               Pokemon pikachu = PikachuGenerator.Get();
               ObjectComparer.CompareObjects(pokemon, pikachu);
               break;
            case "bulbasaur":
               Pokemon bulbasaur = BulbasaurGenerator.Get();
               ObjectComparer.CompareObjects(pokemon, bulbasaur);
               break;
            case "meowth":
               Pokemon meowth = MeowthGenerator.Get();
               ObjectComparer.CompareObjects(pokemon, meowth);
               break;
            default: 
               throw new ArgumentException(endpoint);
         }
      }
   }
}
