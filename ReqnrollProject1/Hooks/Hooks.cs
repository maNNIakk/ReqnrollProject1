using Reqnroll.Assist;
using Reqnroll.Assist.ValueRetrievers;
using ReqnrollProject1.Utils;
using System.Diagnostics;

namespace ReqnrollProject1.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        private IReqnrollOutputHelper _outputHelper;
        private ScenarioContext _scenarioContext;

        public Hooks(IReqnrollOutputHelper outputHelper, FeatureContext featureContext, ScenarioContext scenarioContext)
        {
            _outputHelper = outputHelper;
            _scenarioContext = scenarioContext;
        }
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            Service.Instance.ValueRetrievers.Register(new ClothesSizeRetriever());
            Service.Instance.ValueComparers.Register(new ClothesSizeComparer());

            Service.Instance.ValueRetrievers.Unregister<BoolValueRetriever>();
            Service.Instance.ValueRetrievers.Register(new BooleanValueRetriever());

            Service.Instance.ValueRetrievers.Register(new UserTypeRetriever());
            Service.Instance.ValueRetrievers.Unregister<Reqnroll.Assist.ValueRetrievers.StringValueRetriever>();
            Service.Instance.ValueRetrievers.Register(new Utils.StringValueRetriever());

        }
        [AfterTestRun]
        public static void AfterTestRun()
        {
            Service.Instance.ValueRetrievers.Unregister(new ClothesSizeRetriever());
            Service.Instance.ValueComparers.Unregister(new ClothesSizeComparer());
            Service.Instance.ValueRetrievers.Unregister(new BooleanValueRetriever());
            Service.Instance.ValueRetrievers.Unregister(new UserTypeRetriever());

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
