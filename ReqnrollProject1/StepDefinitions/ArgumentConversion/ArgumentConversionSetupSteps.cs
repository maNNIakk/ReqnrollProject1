namespace ReqnrollProject1.StepDefinitions.ArgumentConversion
{
    [Binding]
    public class ArgumentConversionSetupSteps
    {
        public ScenarioContext _scenarioContext;
        public ArgumentConversionSetupSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given("I have offer code {string} which expires in {string}")]
        [Given("I have offer code {string} which expires {string}")]
        public void GivenIHaveOfferCodeWhichExpiresIn(string offerCode, DateTime expiryDate)
        {

        }

        [Given(@"I am the customer N°{int} to view the offer page")]
        public void GivenIAmTheCustomerNToViewTheOfferPage(int visitorCount )
        {
            try
            {
            bool isValid = ValidateVisitorCount(visitorCount);
                _scenarioContext["IsFirstVisitor"] = isValid;
                _scenarioContext["ZeroOrNegativeVisitorCountException"] = null;
            } 
            catch (IndexOutOfRangeException ex)
            {
                _scenarioContext["ZeroOrNegativeVisitorCountException"] = ex;
            }
            
        }

        public static bool ValidateVisitorCount(int visitorCount)
        {
                return (visitorCount) switch
                {
                    1 => true,
                    < 1 => throw new IndexOutOfRangeException("Customer visit count must be 1 or greater"),
                    _ => false
                };
            
        }
    }
}
