using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPI.Commands
{
    public class CreateUserCourseCommand
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public int CourseId { get; set; }
    }
}