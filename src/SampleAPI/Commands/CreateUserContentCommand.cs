using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPI.Commands
{
    public class CreateUserContentCommand
    {
        public int ContentId { get; set; }

        public string Username { get; set; }
    }
}
