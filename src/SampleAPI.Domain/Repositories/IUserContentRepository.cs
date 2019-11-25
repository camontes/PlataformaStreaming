using SampleAPI.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace SampleAPI.Domain.Infrastructure.Repositories
{
    public interface IUserContentRepository
    {
        Task CreateUserContentAsync(UserContent usercontent);
    }
}