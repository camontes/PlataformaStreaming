using AutoMapper;
using SampleAPI.Commands;
using SampleAPI.Domain.Models;
using SampleAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPI.Mappings
{
    public class StreamMappings :Profile
    {
        public StreamMappings()
        {
            CreateMap<StreamCommand, Stream>();
            CreateMap<StreamViewModel, Stream>();
        }
    }
}
