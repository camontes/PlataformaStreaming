using SampleAPI.Domain.Infrastructure.Repositories;
using SampleAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SampleAPI.Domain.Managers
{
    public class QuestionBehavior : IQuestionBehavior
    {
        protected readonly IQuestionRepository _repository;

        public QuestionBehavior(IQuestionRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateQuestionAsync(Question question)
        {
            if (question is null) throw new ArgumentNullException(nameof(question));

            question.IsActive = true;
            question.CreatedAt = DateTime.Now;
            question.UpdatedAt = DateTime.Now;
            await _repository.CreateQuestionAsync(question);
        }

        public async Task UpdateQuestionAsync(Question question)
        {
            if (question is null) throw new ArgumentNullException(nameof(question));

            question.UpdatedAt = DateTime.Now;
            await _repository.UpdateQuestionAsync(question);
        }

        public async Task DeleteQuestionAsync(Question question)
        {
            if (question is null) throw new ArgumentNullException(nameof(question));

            await _repository.DeleteQuestionAsync(question);
        }
    }
}
