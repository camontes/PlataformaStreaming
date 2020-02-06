using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPI.ViewModels
{
    public class BasicContentViewModel
    {
        public string Name { get; set; }

        public string Url { get; set; }

        public int SubjectId { get; set; }

        public bool IsActive { get; set; }
    }
}