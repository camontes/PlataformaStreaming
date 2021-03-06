﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
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
        private readonly ICourseQueries _courseQueries;

        public UserContentsController(IUserContentQueries queries,
            IUserQueries userQueries,
            IContentQueries contentQueries,
            ICourseQueries courseQueries,
            IMapper mapper)
        {
            _queries = queries;
            _userQueries = userQueries;
            _contentQueries = contentQueries;
            _courseQueries = courseQueries;
        }

        [EnableCors("_myAllowSpecificOrigins")]
        [HttpGet]
        [ProducesResponseType(200)]
        [Authorize]
        public async Task<ActionResult<IEnumerable<BasicUserContentViewModel>>> GetAllAsync()
        {
            return await _queries.FindAllUserContentAsync();
        }

        [EnableCors("_myAllowSpecificOrigins")]
        [Route("ByUsername/{username}")]
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [Authorize]
        public async Task<ActionResult<IEnumerable<BasicUserContentViewModel>>> GetAllByUsernameAsync(string username)
        {
            var existingUsername = await _userQueries.FindByUsernameAsync(username);

            if (existingUsername == null)
            {
                return NotFound("El usuario no existe");
            }

            return await _queries.FindAllUserContenByUsernameAsync(username);
        }

        [EnableCors("_myAllowSpecificOrigins")]
        [Route("ByUsernameContent/{contentId}/{username}")]
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [Authorize]
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

        [EnableCors("_myAllowSpecificOrigins")]
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [Authorize]
        public async Task<ActionResult<BasicUserContentViewModel>> GetByIdAsync(int id)
        {
            var existingUserContent = await _queries.FindByIdAsync(id);

            if (existingUserContent == null)
            {
                return NotFound("El contenido no existe");
            }

            return existingUserContent;
        }
    }
}