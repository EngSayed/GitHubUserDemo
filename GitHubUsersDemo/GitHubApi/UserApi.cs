using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Configuration;
using AutoMapper;
using GitHubDataModel;
using Octokit;
using User = GitHubDataModel.User;

namespace GitHubApi
{
    public class UserApi
    {
        public async Task<User> GetUser(string loginName)
        {
            try
            {
                var repositoriesCount = WebConfigurationManager.AppSettings["RepositoriesCount"];
                
                var github = new GitHubClient(new ProductHeaderValue("GitHubUsersDemo"));
                var user = await github.User.Get(loginName);

                var config       = new MapperConfiguration(cfg => cfg.CreateMap<Octokit.User, User>());
                var mapper       = config.CreateMapper();
                var repositories = await GetRepos(user.Login);
                var mappedUser   =  mapper.Map<Octokit.User, User>(user);
                mappedUser.Repositories = repositories;

                int repoCount;
                if (int.TryParse(repositoriesCount, out repoCount))
                {
                    mappedUser.Repositories = mappedUser.Repositories.OrderByDescending(repo => repo.StargazersCount).Take(repoCount);
                }
                return mappedUser;
            }
            catch (Exception exception)
            {
                throw ExceptionFactory.GetException(exception);
            }
        }

        public async Task<IEnumerable<UserRepo>> GetRepos(string loginName)
        {
            try
            {
                var github = new GitHubClient(new ProductHeaderValue("GitHubUsersDemo"));

                var repositories = await github.Repository.GetAllForUser(loginName);

                var config       = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Repository, UserRepo>();
                    cfg.CreateMap<Octokit.User, User>();
                } );
                var mapper       = config.CreateMapper();

                var repos        =  mapper.Map<IList<Repository>, IList<UserRepo>>(repositories.ToList());
                return repos;
            }
            catch (Exception exception)
            {
                throw ExceptionFactory.GetException(exception);
            }
        }
    }
}
