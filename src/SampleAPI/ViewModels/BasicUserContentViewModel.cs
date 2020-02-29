using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPI.ViewModels
{
    public class BasicUserContentViewModel
    {
       public int ContentId { get; set; }
       public int Id { get; set; }

        public string Username { get; set; }

        public DateTime? CreatedAt { get; set; }

        public int CourseId { get; set; }
    }
}
