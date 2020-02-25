using SampleAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SampleAPI.Domain
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public string Username { get; set; }

        [ForeignKey("Username")]
        public virtual User User { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        public virtual IEnumerable<UserCourse> UserCourse { get; set; }

        public virtual IEnumerable<Question> Question { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public DateTime? PostedAt { get; set; }

        public double Rating { get; set; }

        public bool IsPublished { get; set; }
    }
}
