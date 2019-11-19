using SampleAPI.Domain.Infrastructure.Repositories;
using SampleAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SampleAPI.Domain.Managers
{
    public class SubjectBehavior : ISubjectBehavior
    {
        protected readonly ISubjectRepository _repository;

        public SubjectBehavior(ISubjectRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateSubjectAsync(Subject subject)
        {
            if (subject is null) throw new ArgumentNullException(nameof(subject));

            subject.IsActive = true;
            subject.CreatedAt = DateTime.Now;
            subject.UpdatedAt = DateTime.Now;
            await _repository.CreateSubjectAsync(subject);
        }

        public async Task UpdateSubjectAsync(Subject subject)
        {
            if (subject is null) throw new ArgumentNullException(nameof(subject));

            subject.UpdatedAt = DateTime.Now;
            await _repository.UpdateSubjectAsync(subject);
        }

        public async Task DeleteSubjectAsync(Subject subject)
        {
            if (subject is null) throw new ArgumentNullException(nameof(subject));

            await _repository.DeleteSubjectAsync(subject);
        }
    }
}

