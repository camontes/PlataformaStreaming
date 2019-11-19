using SampleAPI.Domain.Infrastructure.Repositories;
using SampleAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SampleAPI.Domain.Managers
{
    public class ContentBehavior : IContentBehavior
    {
        protected readonly IContentRepository _repository;

        public ContentBehavior(IContentRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateContentAsync(Content content)
        {
            if (content is null) throw new ArgumentNullException(nameof(content));

            content.IsActive = true;
            content.CreatedAt = DateTime.Now;
            content.UpdatedAt = DateTime.Now;
            await _repository.CreateContentAsync(content);
        }

        public async Task UpdateContentAsync(Content content)
        {
            if (content is null) throw new ArgumentNullException(nameof(content));

            content.UpdatedAt = DateTime.Now;
            await _repository.UpdateContentAsync(content);
        }

        public async Task DeleteContentAsync(Content content)
        {
            if (content is null) throw new ArgumentNullException(nameof(content));

            await _repository.DeleteContentAsync(content);
        }
    }
}

