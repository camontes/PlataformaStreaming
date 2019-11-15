using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPI.ViewModels
{
    public class UserViewModel
    {
        public string Username { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Photo { get; set; }

        public string Email { get; set; }

        public bool IsActive { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
