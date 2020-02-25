using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPI.Commands
{
    public class AnswersExam
    {
        public List<int> options { get; set; }

        public int userCourseId { get; set; }
    }
}
