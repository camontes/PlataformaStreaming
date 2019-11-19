using SampleAPI.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace SampleAPI.Domain.Infrastructure.Repositories
{
    public interface IContentRepository
    {
        Task CreateContentAsync(Content content);
        Task DeleteContentAsync(Content content);
        Task UpdateContentAsync(Content content);
    }
}