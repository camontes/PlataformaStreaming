using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPI.Commands
{
    public class UpdateContentCommand
    {
        public string Name { get; set; }

        public string Url { get; set; }
    }
}