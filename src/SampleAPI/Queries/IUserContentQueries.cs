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

        Task<UserContent> FindUserContentAsync(int id, string username);

        Task<List<BasicUserContentViewModel>> FindAllUserContentAsync();
    }
}
