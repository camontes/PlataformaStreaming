using SampleAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SampleAPI.Domain.Behaviors
{
   public  interface IStreamBehavior
    {
        Task UpdateStreamAsync(Stream stream);
    }
}
