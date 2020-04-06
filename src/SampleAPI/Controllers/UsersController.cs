using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<UserViewModel>>> GetAllAsync()
        {
            return await _queries.FindAllAsync();
        }

        [HttpGet("{username}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<UserViewModel>> GetByUsernameAsync(string username)
        {
            var existingUser = await _queries.FindByUsernameAsync(username);
            if (existingUser == null)
            {
                return NotFound();
            }
            return existingUser;
        }

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
                return Conflict();
            }

            var user = _mapper.Map<User>(createUserCommand);
            await _behavior.CreateUserAsync(user);
            return CreatedAtAction(
                nameof(GetByUsernameAsync), 
                new { username = user.Username }, 
                _mapper.Map<BasicUserViewModel>(user));
        }

        [HttpPut("{username}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateUserAsync(string username, UpdateUserCommand updateUserCommand)
        {

            var existingUser = await _queries.FindByUsernameAsync(username);
            if (existingUser == null)
            {
                return NotFound();
            }

            User userUpdated = _mapper.Map<User>(existingUser);
            _mapper.Map(updateUserCommand, userUpdated);
            await _behavior.UpdateUserAsync(userUpdated);
            return NoContent();
        }

        [HttpDelete("{username}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteUserAsync(string username)
        {
            var existingUser = await _queries.FindByUsernameAsync(username);
            if (existingUser == null)
            {
                return NotFound();
            }


            User userDeleted = _mapper.Map<User>(existingUser);
            await _behavior.DeleteUserAsync(userDeleted);
            return NoContent();
        }
    }
}
