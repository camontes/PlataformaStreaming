using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPI.Commands
{
    public class UpdateUserCourseCommand
    {
        [Required]
        public float Rating { get; set; }
    }
}