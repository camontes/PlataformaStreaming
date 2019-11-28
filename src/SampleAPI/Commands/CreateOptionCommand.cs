using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPI.Commands
{
    public class CreateOptionCommand
    {
        public List<OptionList> Options { get; set; }

        [Required]
        public int QuestionId { get; set; }
    }

    public class OptionList
    {
        [Required]
        public string Content { get; set; }

        [Required]
        public bool IsCorrect { get; set; }
    }
}