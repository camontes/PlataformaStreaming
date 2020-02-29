using SampleAPI.Domain.Models;
using SampleAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPI.Queries
{
    public interface IUserContentQueries
    {
        Task<int> CountByContentAsync(int courseid, string username);

        Task<BasicUserContentViewModel> FindUserContentAsync(int id, string username);

        Task<List<BasicUserContentViewModel>> FindAllUserContentAsync();

        Task<BasicUserContentViewModel> FindByIdAsync(int id);

        Task<List<BasicUserContentViewModel>> FindAllUserContenByUsernameAsync(string username);

        Task<BasicUserContentViewModel> FindLastUserContentAsync(int courseId, string username);

        Task<BasicUserContentViewModel> FindUserContenByUsernameContentAsync(int contentId, string username);
    }
}
