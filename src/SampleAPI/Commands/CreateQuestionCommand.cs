using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPI.Commands
{
    public class CreateQuestionCommand
    {
        [Required]
        public string Content { get; set; }

        [Required]
        public int CourseId { get; set; }
    }
}