using System.Collections.Generic;
using System.Linq;
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

                TempData["User"] = mappedUser;

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
                
        public ActionResult Sort(string sortOrder)
        {
            var userModel = TempData["User"] as UserViewModel;
            if (userModel == null)
                return View("Index");


            var repos = userModel.Repositories;
            var userReposList = repos as IList<UserReporViewModel> ?? repos.ToList();
            if (!userReposList.Any())
                return View("Index");

            TempData.Keep("User");

            ViewBag.NameSortParm     = sortOrder == "name" ? "name_desc" : "name";
            ViewBag.FullNameSortParm = sortOrder == "full_name" ? "full_name_desc" : "full_name";
            ViewBag.StarsSortParm    = sortOrder == "stars" ? "stars_desc" : "stars";
            ViewBag.LanguageSortParm = sortOrder == "language" ? "language_desc" : "language";
            ViewBag.DescrSortParm    = sortOrder == "description" ? "description_desc" : "description";

            switch (sortOrder)
            {
                case "name":
                    repos = userReposList.OrderBy(s => s.Name);
                    userModel.Repositories = repos;
                    break;
                case "name_desc":
                    repos = userReposList.OrderByDescending(s => s.Name);
                    userModel.Repositories = repos;
                    break;
                case "full_name":
                    repos = userReposList.OrderBy(s => s.FullName);
                    userModel.Repositories = repos;
                    break;
                case "full_name_desc":
                    repos = userReposList.OrderByDescending(s => s.FullName);
                    userModel.Repositories = repos;
                    break;
                case "language":
                    repos = userReposList.OrderBy(s => s.Language);
                    userModel.Repositories = repos;
                    break;
                case "language_desc":
                    repos = userReposList.OrderByDescending(s => s.Language);
                    userModel.Repositories = repos;
                    break;
                case "description":
                    repos = userReposList.OrderBy(s => s.Description);
                    userModel.Repositories = repos;
                    break;
                case "description_desc":
                    repos = userReposList.OrderByDescending(s => s.Description);
                    userModel.Repositories = repos;
                    break;
                case "stars":
                    repos = userReposList.OrderBy(s => s.StargazersCount);
                    userModel.Repositories = repos;
                    break;
                case "stars_desc":
                default:
                    repos = userReposList.OrderByDescending(s => s.StargazersCount);
                    userModel.Repositories = repos;
                    break;
            }

            return View("Index", userModel);
        }
    }
}