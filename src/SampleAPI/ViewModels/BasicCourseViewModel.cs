﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPI.ViewModels
{
    public class BasicCourseViewModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public double Rating { get; set; }

        public int CategoryId { get; set; }

        public string Username { get; set; }

        public bool IsActive { get; set; }
    }
}