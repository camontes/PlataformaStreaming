using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SampleAPI.Commands;
using SampleAPI.Domain;
using SampleAPI.Domain.Managers;
using SampleAPI.Queries;
using SampleAPI.ViewModels;

namespace SampleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserBehavior _behavior;

        private readonly IUserQueries _queries;

        private readonly IMapper _mapper;

        public UsersController(IUserBehavior behavior, IUserQueries queries, IMapper mapper)
        {
            _behavior = behavior;
            _queries = queries;
            _mapper = mapper;
        }

        [EnableCors("_myAllowSpecificOrigins")]
        [HttpGet]
        [ProducesResponseType(200)]
        [Authorize]
        public async Task<ActionResult<IEnumerable<User>>> GetAllAsync()
        {
            return await _queries.FindAllAsync();
        }

        [EnableCors("_myAllowSpecificOrigins")]
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        [Authorize]
        public async Task<ActionResult<User>> CreateUserAsync(CreateUserCommand createUserCommand)
        {
            var existingUser = await _queries.FindByUsernameAsync(createUserCommand.Username);
            if (existingUser != null)
            {
                return NoContent();
            }

            var user = _mapper.Map<User>(createUserCommand);
            await _behavior.CreateUserAsync(user);
            return NoContent();
        }
    }
}
