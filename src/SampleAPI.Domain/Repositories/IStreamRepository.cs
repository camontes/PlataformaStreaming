using SampleAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SampleAPI.Domain.Repositories
{
    public interface IStreamRepository
    {
        Task UpdateSytreamAsync(Stream stream);
    }
}
