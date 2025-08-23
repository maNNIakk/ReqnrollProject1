using ReqnrollProject1.Models;

namespace ReqnrollProject1.StepDefinitions.Challenge
{
    [Binding]
    internal class ChallengeValidationSteps
    {

        private InternalUserTypeContext? _userTypeContext;
        private Stores.StoreContext? _storeContext;
        public ChallengeValidationSteps(InternalUserTypeContext userTypeContext, Stores.StoreContext storeContext)
        {
            _userTypeContext = userTypeContext;
            _storeContext = storeContext;
        }

        [Then("the internal user type for users is")]
        public void ThenTheInternalUserTypeForUsersIs(DataTable dataTable)
        {
            dataTable.CompareToSet(_userTypeContext!.Users);
        }

        [Then("the correspondent GeoLocation from stores are")]
        public void ThenTheCorrespondentGeoLocationFromStoresAre(DataTable dataTable)
        {
            var actual = _storeContext.StoresList!.Select(store => new
            {
                store.StoreName,
                store.Location?.Latitude,
                store.Location?.Longitude
            });
            dataTable.CompareToSet(actual);

        }


    }
}
