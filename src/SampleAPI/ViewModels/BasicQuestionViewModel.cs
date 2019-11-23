using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPI.ViewModels
{
    public class BasicQuestionViewModel
    {
        public string Content { get; set; }

        public int CourseId { get; set; }

        public bool IsActive { get; set; }
    }
}