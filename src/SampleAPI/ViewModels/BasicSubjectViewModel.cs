using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPI.ViewModels
{
    public class BasicSubjectViewModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int CourseId { get; set; }

        public bool IsActive { get; set; }
    }
}
