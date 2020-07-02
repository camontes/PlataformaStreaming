using SampleAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPI.Queries
{
    public interface IStreamQueries
    {
        Task<StreamViewModel> GetStream();
    }
}
