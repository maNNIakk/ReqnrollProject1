namespace ReqnrollProject1.StepDefinitions.ArgumentConversion
{
    [Binding]
    internal class ArgumentConversionValidationSteps
    {
        public ScenarioContext _scenarioContext;
        public ArgumentConversionValidationSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        [Then("the offer code is invalid")]
        public void ThenTheOfferCodeIsInvalid()
        {

        }

        [Then("the offer code is valid")]
        public void ThenTheOfferCodeIsValid()
        {
        }

        [Then("I am given a special discount")]
        public void ThenIAmGivenASpecialDiscount()
        {
            var ex = _scenarioContext["ZeroOrNegativeVisitorCountException"] as Exception;
            Assert.IsTrue((bool)_scenarioContext["IsFirstVisitor"]);
            Assert.IsNull(ex);

        }


        [Then("I am not given a special discount")]
        public void ThenIAmNotGivenASpecialDiscount()
        {
            var ex = _scenarioContext["ZeroOrNegativeVisitorCountException"] as Exception;
            Assert.IsFalse((bool)_scenarioContext["IsFirstVisitor"]);
            Assert.IsNull(ex);
        }

        [Then("an IndexOutOfRangeException is thrown")]
        public void ThenAnIndexOutOfRangeExceptionIsThrown()
        {
            var ex = _scenarioContext["ZeroOrNegativeVisitorCountException"] as Exception;
            Assert.IsNotNull(ex);
            Assert.IsInstanceOfType(ex, typeof(IndexOutOfRangeException), $"Expected IndexOutOfRangeException, but got {ex.GetType().Name}. ");
        }



    }
}
