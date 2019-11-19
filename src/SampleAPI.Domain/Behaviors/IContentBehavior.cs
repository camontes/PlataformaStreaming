using SampleAPI.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace SampleAPI.Domain.Managers
{
    public interface IContentBehavior
    {
        Task CreateContentAsync(Content content);
        Task DeleteContentAsync(Content content);
        Task UpdateContentAsync(Content content);
    }
}