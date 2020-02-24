using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPI.ViewModels
{
    public class UserCourseViewModel
    {
        public int Id { get; set; }

        public int CourseId { get; set; }

        public string CourseName { get; set; }

        public DateTime? CourseDate { get; set; }

        public string Username { get; set; }

        public string NameTeacher { get; set; }

        public string LastNameTeacher { get; set; }

        public bool IsEnd { get; set; }

        public float Rating { get; set; }

        public string Description { get; set; }

        public string CategoryName { get; set; }

        public int Progress { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
