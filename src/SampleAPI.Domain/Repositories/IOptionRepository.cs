using SampleAPI.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace SampleAPI.Domain.Infrastructure.Repositories
{
    public interface IOptionRepository
    {
        Task CreateOptionAsync(Option option);
        Task DeleteOptionAsync(Option option);
        Task UpdateOptionAsync(Option option);
    }
}
