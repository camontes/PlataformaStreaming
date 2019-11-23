using SampleAPI.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace SampleAPI.Domain.Managers
{
    public interface IOptionBehavior
    {
        Task CreateOptionAsync(Option option);
        Task DeleteOptionAsync(Option option);
        Task UpdateOptionAsync(Option option);
    }
}

