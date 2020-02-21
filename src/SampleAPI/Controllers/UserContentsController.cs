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
        private readonly IUserQueries _userQueries;
        private readonly IContentQueries _contentQueries;

        public UserContentsController(IUserContentQueries queries,
            IUserQueries userQueries,
            IContentQueries contentQueries,
            IMapper mapper)
        {
            _queries = queries;
            _userQueries = userQueries;
            _contentQueries = contentQueries;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<BasicUserContentViewModel>>> GetAllAsync()
        {
            return await _queries.FindAllUserContentAsync();
        }

        [Route("ByUsername/{username}")]
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<IEnumerable<BasicUserContentViewModel>>> GetAllByUsernameAsync(string username)
        {
            var existingUsername = await _userQueries.FindByUsernameAsync(username);

            if (existingUsername == null)
            {
                return NotFound("El usuario no existe");
            }

            return await _queries.FindAllUserContenByUsernameAsync(username);
        }

        [Route("ByUsernameContent/{contentId}/{username}")]
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<BasicUserContentViewModel>> GetByUsernameContentAsync(int contentId, string username)
        {
            var existingUsername = await _userQueries.FindByUsernameAsync(username);
            var existingContent = await _contentQueries.FindByIdAsync(contentId);

            if (existingUsername == null || existingContent == null)
            {
                return NotFound("El usuario no existe o el contenido no existe");
            }

            return await _queries.FindUserContenByUsernameContentAsync(contentId, username);
        }
    }
}