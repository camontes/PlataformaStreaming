using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPI.Commands
{
    public class CreateOptionCommand
    {
        [Required]
        public string Content { get; set; }

        [Required]
        public bool IsCorrect { get; set; }

        [Required]
        public int QuestionId { get; set; }
    }
}