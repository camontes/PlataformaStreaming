using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SampleAPI.Domain.Models
{
    public class Stream
    {
        [Key]
        public int Id { get; set; }
        public string Url { get; set; }
    }
}
