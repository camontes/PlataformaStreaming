using SampleAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SampleAPI.Domain
{
    public class User
    {
        [Key]
        public string Username { get; set; }

        public string Name { get; set; }

        public string Photo { get; set; }

        public virtual IEnumerable<UserCourse> UserCourse { get; set; }

        public virtual IEnumerable<Course> Course { get; set; }

        public virtual IEnumerable<UserContent> UserContent { get; set; }

    }
}
