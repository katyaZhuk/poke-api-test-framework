using Api.Core.Helpers;
using Api.Core.Utils.ExtentReport;
using AventStack.ExtentReports;
using NUnit.Framework;

[assembly: Parallelizable(ParallelScope.Fixtures)]
[assembly: LevelOfParallelism(2)]
namespace Api.Test.StepDefinitions
{
   [Binding]
   public class ApiHooks
   {
      [ThreadStatic]
      private static ExtentTest _featureName;

      [ThreadStatic]
      private static ExtentTest _scenarioName;

      private static ExtentReports _extentReport;

      private readonly ScenarioContext _scenarioContext;

      private readonly FeatureContext _featureContext;

      public ApiHooks(ScenarioContext scenarioContext, FeatureContext featureContext)
      {
         _scenarioContext = scenarioContext;
         _featureContext = featureContext;
      }

      [BeforeTestRun]
      public static void BeforeTestRun()
      {
         _extentReport = new ExtentReports();
         ExtentTestManager.CreateTest(_extentReport);
      }

      [BeforeFeature]
      public static void BeforeFeature(FeatureContext featureContext)
      {
         _featureName = ExtentTestManager.AddFeatureName(_extentReport, featureContext);
      }

      [BeforeScenario]
      public void SetUp()
      {
         _scenarioName = ExtentTestManager.AddScenarioName(_featureName, _scenarioContext);

         Logger.Log.Information("--------------------Test started--------------------");
      }

      [AfterStep]
      public void InsertReportingSteps()
      {
         ExtentTestManager.InsertReportingSteps(_scenarioContext, _scenarioName);
      }

      [AfterScenario]
      public void TearDown()
      {
         Logger.Log.Information("--------------------Test finished--------------------");
      }

      [AfterTestRun]
      public static void AfterTestRun()
      {
         _extentReport.Flush();
      }
   }
}
