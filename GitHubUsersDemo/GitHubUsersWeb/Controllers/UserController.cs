using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using GitHubApi;
using GitHubApi.ErrorHandling;
using GitHubDataModel;
using GitHubUsersWeb.Models;

namespace GitHubUsersWeb.Controllers
{
    public class UserController : Controller
    {
        public async Task<ActionResult> Index(string loginName)
        {
            if (string.IsNullOrEmpty(loginName))
                return View();
            try
            {
                var api = new UserApi();
                var user = await api.GetUser(loginName);

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<User, UserViewModel>();
                    cfg.CreateMap<UserRepo, UserReporViewModel>();
                });
                var mapper = config.CreateMapper();

                var mappedUser = mapper.Map<User, UserViewModel>(user);

                return View("Index", mappedUser);
            }
            catch (ApplicationExceptionBase exception)
            {
                ModelState.AddModelError("ErrorMessage", exception.DisplayMessage);
                return View();
            }
            catch (System.Exception exception)
            {
                ModelState.AddModelError("ErrorMessage", exception.Message);
                return View();
            }
        }
    }
}