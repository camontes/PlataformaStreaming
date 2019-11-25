using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleAPI.Queries;
using SampleAPI.ViewModels;

namespace SampleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserContentsController : ControllerBase
    {
        private readonly IUserContentQueries _queries;

        public UserContentsController(IUserContentQueries queries, IMapper mapper)
        {
            _queries = queries;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<BasicUserContentViewModel>>> GetAllAsync()
        {
            return await _queries.FindAllUserContentAsync();
        }
    }
}