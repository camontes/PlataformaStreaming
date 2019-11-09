using System;
using System.ComponentModel.DataAnnotations;

namespace SampleAPI.Domain
{
    public class User
    {
        [Key]
        public string Username { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Photo { get; set; }

        public string Email { get; set; }

        public bool IsActive { get; set; }

        public DateTime? CreatedAt { get;  set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
