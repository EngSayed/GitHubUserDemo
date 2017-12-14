using System.Web.Mvc;
using GitHubUsersWeb.Controllers;
using GitHubUsersWeb.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GitHubUsersWeb.Tests.Controllers
{
    [TestClass]
    public class UserControllerTest
    {
        [TestMethod]
        public void IndexLoadSuccessfully()
        {
            var controller = new UserController();
            var results = controller.Index("robconery");
            var result = results.Result as ViewResult;
            
            Assert.IsNotNull(result.Model);
        }

        [TestMethod]
        public void IndexNullModel()
        {
            var controller = new UserController();
            var results = controller.Index(string.Empty);
            var result = results.Result as ViewResult;

            Assert.IsNull(result.Model);
        }

        [TestMethod]
        public void IndexUserSuccess()
        {
            var controller = new UserController();
            var results = controller.Index("robconery");
            var result = results.Result as ViewResult;

            var expectedUserView = new UserViewModel
            {
                Login    = "robconery",
                Name     = "Rob Conery",
                Location = "Seattle, WA",
                Id       = 78586
            };

            var actual = result.Model as UserViewModel;

            Assert.IsNotNull(result.Model);
            Assert.AreEqual(expectedUserView, actual);
        }
    }
}
