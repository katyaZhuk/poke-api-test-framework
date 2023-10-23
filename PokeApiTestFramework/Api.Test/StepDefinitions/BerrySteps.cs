using Api.Core.Helpers;
using Api.Core.Models.BerryModels;
using Api.Core.Rest.Response;
using NUnit.Framework;

namespace Api.Test.StepDefinitions
{
   [Binding]
   [Scope(Feature = "ValidationGet_Berries_Endpoint")]
   public class BerrySteps
   {
      private readonly ClientHelper _clientHelper;

      private readonly ScenarioContext _scenarioContext;

      public BerrySteps(ClientHelper clientHelper, ScenarioContext scenarioContext)
      {
         _clientHelper = clientHelper;
         _scenarioContext = scenarioContext;
      }

      [When("I try to call '(get berries)' endpoint")]
      public void WhenITryToCallEndpoint(string endpoint)
      {
         var response = _clientHelper.GetAllBerries();

         _scenarioContext.Add(endpoint, response);
      }

      [Then("the response of '(get berries)' endpoint will have successful code")]
      public void TheTheResponseOfEndpointWillHaveSuccessfulCode(string endpoint)
      {
         var berryResult = _scenarioContext.Get<Response<BerryResult>>(endpoint);

         Assert.That(berryResult.StatusCode, Is.EqualTo(200),
            "Status code is not 200");
      }

      [Then("the '(get berries)' endpoint will return 20 berry models")]
      public void TheTheEndpointWillReturn20BerryModels(string endpoint)
      {
         var berries = _scenarioContext.Get<Response<BerryResult>>(endpoint).SuccessModel.Results;

         Assert.That(berries, Has.Count.EqualTo(20),
            "Response model does not contain 20 berries");
      }
   }
}
