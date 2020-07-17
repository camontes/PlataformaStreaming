using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleAPI.Commands;
using SampleAPI.Domain.Behaviors;
using SampleAPI.Domain.Models;
using SampleAPI.Queries;
using SampleAPI.ViewModels;

namespace SampleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StreamsController : ControllerBase
    {
        private readonly IStreamQueries _queries;
        private readonly IStreamBehavior _behavior;
        private readonly IMapper _mapper;

        public StreamsController(IStreamQueries queries, IMapper mapper, IStreamBehavior behavior)
        {
            _queries = queries;
            _mapper = mapper;
            _behavior = behavior;
        }

        [EnableCors("_myAllowSpecificOrigins")]
        [HttpGet]
        [ProducesResponseType(200)]
        [Authorize]
        public async Task<ActionResult<StreamViewModel>> GetAllAsync()
        {
            return await _queries.GetStream();
        }

        [EnableCors("_myAllowSpecificOrigins")]
        [HttpPut]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [Authorize]
        public async Task<ActionResult<StreamViewModel>> UpdateStreamAsync(StreamCommand streamCommand)
        {
            var existingStreamViewModel = await _queries.GetStream();

            if (existingStreamViewModel == null)
            {
                return NotFound();
            }

            var stream = _mapper.Map<Stream>(existingStreamViewModel);

            _mapper.Map(streamCommand, stream);
            await _behavior.UpdateStreamAsync(stream);

            var streamViewModel = await _queries.GetStream();

            return streamViewModel;
        }
    }
}
