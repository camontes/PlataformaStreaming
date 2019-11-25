using SampleAPI.Domain.Infrastructure.Repositories;
using SampleAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SampleAPI.Domain.Managers
{
    public class UserContentBehavior : IUserContentBehavior
    {
        protected readonly IUserContentRepository _repository;

        public UserContentBehavior(IUserContentRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateUserContentAsync(UserContent usercontent)
        {
            if (usercontent is null) throw new ArgumentNullException(nameof(usercontent));

            usercontent.CreatedAt = DateTime.Now;
            await _repository.CreateUserContentAsync(usercontent);
        }
    }
}

