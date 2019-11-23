using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPI.ViewModels
{
    public class QuestionViewModel
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public bool IsActive { get; set; }

        public int CourseId { get; set; }

        public string CourseName { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
