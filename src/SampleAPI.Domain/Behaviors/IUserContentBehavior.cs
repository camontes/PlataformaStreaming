using SampleAPI.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace SampleAPI.Domain.Managers
{
    public interface IUserContentBehavior
    {
        Task CreateUserContentAsync(UserContent usercontent);

        Task UpdateUserContentAsync(UserContent usercontent);
    }
}

