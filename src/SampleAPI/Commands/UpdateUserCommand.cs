using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPI.Commands
{
    public class UpdateUserCommand
    {
        public string Email { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Photo { get; set; }

        [Required]
        public bool IsActive { get; set; }
    }
}
