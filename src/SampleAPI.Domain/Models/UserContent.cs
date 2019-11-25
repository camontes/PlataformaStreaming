using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SampleAPI.Domain.Models
{
    public class UserContent
    {
        [Key]
        public int Id { get; set; }

        public DateTime? CreatedAt { get; set; }

        public int ContentId { get; set; }

        [ForeignKey("ContentId")]
        public virtual Content Content { get; set; }

        public string Username { get; set; }

        [ForeignKey("Username")]
        public virtual User User { get; set; }

    }
}
