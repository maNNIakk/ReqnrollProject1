using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
using ReqnrollProject1.Models;
using System.Globalization;

namespace ReqnrollProject1.StepDefinitions.Challenge
{
    [Binding]
    public sealed class ChallengeSetupSteps
    {
        private InternalUserTypeContext? _userTypeContext;
        private Stores.StoreContext? _storeContext;

        public ChallengeSetupSteps(InternalUserTypeContext userTypeContext, Stores.StoreContext? storeContext)
        {
            _userTypeContext = userTypeContext;
            _storeContext = storeContext;
        }
        [Given("I have the following users")]
        public void GivenIHaveTheFollowingUsers(DataTable dataTable)
        {
            _userTypeContext.Users = dataTable.CreateSet<Users>().ToList();
            _userTypeContext.Users.ForEach(ValidateUserType);

        }

        [Given("I have the following stores")]
        public void GivenIHaveTheFollowingStores(DataTable dataTable)
        {
            //var result = dataTable.CreateDynamicSet();
            //var stores = new List<Stores>();

            //foreach(var entry in result)
            //{
            //    var store = new Stores();
            //    var coords = entry.GeoLocation.Split(',');
            //    store.StoreName = entry.StoreName;
            //    store.Location = new Stores.GeoLocation
            //    {
            //        Latitude = double.Parse(coords[0], CultureInfo.InvariantCulture),
            //        Longitude = double.Parse(coords[1], CultureInfo.InvariantCulture)
            //    };

            //    _storeContext.StoresList.Add(store);  
            //}    
            _storeContext.StoresList = dataTable.Rows.Select(row =>
            {
                var geoParts = row["GeoLocation"].Split(',');
                return new Stores
                {
                    StoreName = row["StoreName"],
                    Location = new Stores.GeoLocation
                    {
                        Latitude = double.Parse(geoParts[0], CultureInfo.InvariantCulture),
                        Longitude = double.Parse(geoParts[1], CultureInfo.InvariantCulture)
                    }
                };
            }).ToList();

        }

        private static void ValidateUserType(Users user)
        {
            if (user.UserType == InternalUserType.Unknown)
            {
                Logger.LogMessage($"[WARNING] User '{user.UserName}' UserType value diddn't matched, set to Default '{InternalUserType.Unknown}'");
            }
        }

    }
}
