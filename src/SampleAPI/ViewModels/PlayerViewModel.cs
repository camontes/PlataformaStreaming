using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPI.ViewModels
{
    public class PlayerViewModel
    {
        public ContentViewModel ContentPlayer { get; set; }

        public UserCourseViewModel UserCoursePlayer { get; set; }

        public BasicUserContentViewModel UserContentPlayer { get; set; }

    }
}
