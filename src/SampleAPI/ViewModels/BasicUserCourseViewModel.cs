﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPI.ViewModels
{
    public class BasicUserCourseViewModel
    {
        public int Id { get; set; }

        public int CourseId { get; set; }

        public string Username { get; set; }

        public bool IsEnd { get; set; }
    }
}