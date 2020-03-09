using SampleAPI.Domain.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SampleAPI.Domain.Managers
{
    public class CategoryBehavior :ICategoryBehavior
    {
        protected readonly ICategoryRepository _repository;

        public CategoryBehavior(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateCategoryAsync(Category category)
        {
            if (category is null) throw new ArgumentNullException(nameof(category));

            category.IsActive = true;
            category.CreatedAt = DateTime.Now;
            category.UpdatedAt = DateTime.Now;
            await _repository.CreateCategoryAsync(category);
        }

        public async Task UpdateCategoryAsync(Category category, string photo)
        {
            if (category is null) throw new ArgumentNullException(nameof(category));

            if (category.Photo == "")
            {
                category.Photo = photo;
            }

            category.UpdatedAt = DateTime.Now;
            await _repository.UpdateCategoryAsync(category);
        }

        public async Task DeleteCategoryAsync(Category category)
        {
            if (category is null) throw new ArgumentNullException(nameof(category));

            await _repository.DeleteCategoryAsync(category);
        }
    }
}
