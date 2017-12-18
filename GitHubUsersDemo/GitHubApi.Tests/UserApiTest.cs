using GitHubApi.ErrorHandling;
using GitHubDataModel;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace GitHubApi.Tests
{
    [TestFixture]
    public class UserApiTest
    {
        [Test]
        public void GetUserTestSuccess()
        {
            var api = new UserApi();
            var actual = api.GetUser("robconery");
            var actualUser = actual.Result;

            var expectedUser = new User
            {
                Login    = "robconery",
                Name     = "Rob Conery",
                Location = "Seattle, WA",
                Id       = 78586
            };

            Assert.AreEqual(expectedUser, actualUser);
        }

        [Test]
        public void GetUserThrowNotFoundException()
        {
            var api = new UserApi();

            Assert.Throws<UserNotFoundException>(async () => await api.GetUser("robconeryb"));            
        }

        [Test]
        public void GetUserThrowForEmptyString()
        {
            var api = new UserApi();

            Assert.Throws<ApplicationGeneralException>(async () => await api.GetUser(" "));
        }
    }
}
