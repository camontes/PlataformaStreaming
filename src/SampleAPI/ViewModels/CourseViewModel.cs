using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPI.ViewModels
{
    public class CourseViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Photo { get; set; }

        public int EnrolledStudents { get; set; }

        public bool IsActive { get; set; }

        public string Username { get; set; }

        public string NameTeacher{ get; set; }

        public string LastNameTeacher { get; set; }

        public string PhotoTeacher { get; set; }

        public string EmailTeacher { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public double Rating { get; set; }
        public bool IsPublished { get; set; }
        public bool IsStreaming { get; set; }
        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public DateTime? PostedAt { get; set; }


    }
}
