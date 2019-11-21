using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SampleAPI.Domain.Models
{
    public class UserCourse
    {
        [Key]
        public int Id { get; set; }

        public int CourseId { get; set; }

        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }

        public string Username { get; set; }

        [ForeignKey("Username")]
        public virtual User User { get; set; }

        public bool IsEnd { get; set; }

        public int Rating { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
