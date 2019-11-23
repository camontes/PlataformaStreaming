using SampleAPI.Domain.Infrastructure.Repositories;
using SampleAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SampleAPI.Domain.Managers
{
    public class OptionBehavior : IOptionBehavior
    {
        protected readonly IOptionRepository _repository;

        public OptionBehavior(IOptionRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateOptionAsync(Option option)
        {
            if (option is null) throw new ArgumentNullException(nameof(option));

            option.IsActive = true;
            option.CreatedAt = DateTime.Now;
            option.UpdatedAt = DateTime.Now;
            await _repository.CreateOptionAsync(option);
        }

        public async Task UpdateOptionAsync(Option option)
        {
            if (option is null) throw new ArgumentNullException(nameof(option));

            option.UpdatedAt = DateTime.Now;
            await _repository.UpdateOptionAsync(option);
        }

        public async Task DeleteOptionAsync(Option option)
        {
            if (option is null) throw new ArgumentNullException(nameof(option));

            await _repository.DeleteOptionAsync(option);
        }
    }
}
