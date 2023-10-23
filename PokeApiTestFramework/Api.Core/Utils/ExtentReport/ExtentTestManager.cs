using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports;
using TechTalk.SpecFlow;
using Api.Core.Helpers;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Config;

namespace Api.Core.Utils.ExtentReport
{
   public static class ExtentTestManager
   {
      private static readonly string ReportPath = Path.Combine(DirectoryHelper.GetSolutionDirectory(), "ExtentReport", "TestUiReport") + "/";

      public static void CreateTest(ExtentReports extent)
      {
         var reporter = new ExtentSparkReporter(ReportPath)
         {
            Config =
                {
                    DocumentTitle = "Test project API auto-tests report",
                    Theme = Theme.Dark
                }
         };

         extent.AttachReporter(reporter);
      }

      public static ExtentTest AddFeatureName(ExtentReports extentReport, FeatureContext featureContext)
      {
         return extentReport.CreateTest<Feature>(featureContext.FeatureInfo.Title);
      }

      public static ExtentTest AddScenarioName(ExtentTest featureName, ScenarioContext scenarioContext)
      {
         return featureName.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
      }

      public static void InsertReportingSteps(ScenarioContext scenarioContext, ExtentTest scenarioName)
      {
         string stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
         string stepInfo = scenarioContext.StepContext.StepInfo.Text;
         string resultOfImplementation = scenarioContext.ScenarioExecutionStatus.ToString();

         if (scenarioContext.TestError == null && resultOfImplementation == "OK")
         {
            switch (stepType)
            {
               case "Given":
                  scenarioName.CreateNode<Given>(stepInfo);
                  break;
               case "When":
                  scenarioName.CreateNode<When>(stepInfo);
                  break;
               case "Then":
                  scenarioName.CreateNode<Then>(stepInfo);
                  break;
               case "And":
                  scenarioName.CreateNode<And>(stepInfo);
                  break;
               default:
                  throw new ArgumentException(stepType);
            }
         }
         else if (scenarioContext.TestError != null)
         {
            string testError = scenarioContext.TestError.Message;

            switch (stepType)
            {
               case "Given":
                  scenarioName.CreateNode<Given>(stepInfo).Fail(testError);
                  break;
               case "When":
                  scenarioName.CreateNode<When>(stepInfo).Fail(testError);
                  break;
               case "Then":
                  scenarioName.CreateNode<Then>(stepInfo).Fail(testError);
                  break;
               case "And":
                  scenarioName.CreateNode<And>(stepInfo).Fail(testError);
                  break;
               default:
                  throw new ArgumentException(stepType);
            }
         }
         else if (resultOfImplementation == "StepDefinitionPending")
         {
            string errorMessage = "Step Definition is not implemented!";

            switch (stepType)
            {
               case "Given":
                  scenarioName.CreateNode<Given>(stepInfo).Skip(errorMessage);
                  break;
               case "When":
                  scenarioName.CreateNode<When>(stepInfo).Skip(errorMessage);
                  break;
               case "Then":
                  scenarioName.CreateNode<Then>(stepInfo).Skip(errorMessage);
                  break;
               case "And":
                  scenarioName.CreateNode<And>(stepInfo).Skip(errorMessage);
                  break;
               default:
                  throw new ArgumentException(stepType);
            }
         }
      }
   }
}
