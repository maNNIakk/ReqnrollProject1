using Reqnroll;
using Reqnroll.Bindings;
using System.Diagnostics;

namespace ReqnrollProject1.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        private IReqnrollOutputHelper _outputHelper;
        private ScenarioContext _scenarioContext;
        private FeatureContext _featureContext;

        public Hooks(IReqnrollOutputHelper outputHelper, FeatureContext featureContext, ScenarioContext scenarioContext)
        {
            _outputHelper = outputHelper;
            _featureContext = featureContext;
            _scenarioContext = scenarioContext;
        }
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            Debug.WriteLine(nameof(BeforeTestRun));
        }
        [AfterTestRun]
        public static void AfterTestRun()
        {
            // Code to run after the test run
            Debug.WriteLine(nameof(AfterTestRun));
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            Debug.WriteLine($"Before Feature: Title: {featureContext.FeatureInfo.Title}");
        }

        [AfterFeature]
        public static void AfterFeature(FeatureContext featureContext)
        {
            // Code to run after each feature
            Debug.WriteLine($"After Feature: Title: {featureContext.FeatureInfo.Title}");
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            _outputHelper.WriteLine($"Before Scenario: {_scenarioContext.ScenarioInfo.Title}");
           
        }
        [AfterScenario]
        public void AfterScenario(ScenarioContext scenarioContext)
        {
            _outputHelper.WriteLine($"After Scenario: {scenarioContext.ScenarioInfo.Title}");
            if(scenarioContext.TestError is not null) _outputHelper.WriteLine("Holy cow i got an error");
        }

        [BeforeScenarioBlock]
        public void BeforeScenarioBlock()
        {
            _outputHelper.WriteLine(nameof(BeforeScenarioBlock));
        }

        [AfterScenarioBlock]
        public void AfterScenarioBlock()
        {
            // Code to run after each scenario block
            _outputHelper.WriteLine(nameof(AfterScenarioBlock));
        }

        [BeforeStep]
        public void BeforeStep(ScenarioContext scenarioContext)
        {
            // Code to run before each step
            _outputHelper.WriteLine($"Step Context {scenarioContext.StepContext. StepInfo.Text} Type {scenarioContext.StepContext.StepInfo.StepDefinitionType}");
        }
        [AfterStep]
        public void AfterStep(ScenarioContext scenarioContext)
        {
            // Code to run after each step
            _outputHelper.WriteLine($"Step Context {scenarioContext.StepContext.StepInfo.Text}");
        }  
    }
}
