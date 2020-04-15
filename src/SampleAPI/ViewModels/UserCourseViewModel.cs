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

        public int EnrolledStudents { get; set; }

        public DateTime? CoursePostedAt { get; set; }

        public bool IsStreaming { get; set; }

        public string Username { get; set; }

        public string NameTeacher { get; set; }

        public string EmailTeacher { get; set; }

        public bool IsEnd { get; set; }

        public float Rating { get; set; }

        public string Description { get; set; }

        public string CategoryName { get; set; }

        public int Progress { get; set; }

        public int CorrectAnswers { get; set; }

        public string Photo { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
