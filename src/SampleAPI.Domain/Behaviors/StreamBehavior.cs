using SampleAPI.Domain.Models;
using SampleAPI.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SampleAPI.Domain.Behaviors
{
   public class StreamBehavior : IStreamBehavior
    {
        protected readonly IStreamRepository _repository;

        public StreamBehavior(IStreamRepository repository)
        {
            _repository = repository;
        }

        public async Task UpdateStreamAsync(Stream stream)
        {
            if (stream is null) throw new ArgumentNullException(nameof(stream));

            await _repository.UpdateSytreamAsync(stream);
        }
    }
}
