using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPI.Commands
{
    public class CreateContentCommand
    {
        [Required]
        public string Name { get; set; }


        [Required]
        public string Url { get; set; }

        public int SubjectId { get; set; }
    }
}