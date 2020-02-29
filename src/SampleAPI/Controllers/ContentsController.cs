using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SampleAPI.Commands;
using SampleAPI.Domain;
using SampleAPI.Domain.Behaviors;
using SampleAPI.Domain.Managers;
using SampleAPI.Domain.Models;
using SampleAPI.Queries;
using SampleAPI.ViewModels;


namespace SampleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentsController : ControllerBase
    {
        private readonly IContentBehavior _behavior;

        private readonly IUserCourseBehavior _userCourseBehavior;

        private readonly IUserContentBehavior _userContentBehavior;

        private readonly IContentQueries _queries;

        private readonly IUserCourseQueries _userCourseQueries;

        private readonly IUserContentQueries _userContentQueries;

        private readonly IUserQueries _userQueries;

        private readonly ICourseQueries _courseQueries;

        private readonly ISubjectQueries _subjectQueries;

        private readonly IMapper _mapper;

        public ContentsController(IContentBehavior behavior,
            IContentQueries queries,
            IUserQueries userQueries,
            ISubjectQueries subjectQueries,
            IUserContentBehavior userContentBehavior,
            IUserCourseBehavior userCourseBehavior,
            IUserContentQueries userContentQueries,
            IUserCourseQueries userCourseQueries,
            ICourseQueries courseQueries,
            IMapper mapper)
        {
            _behavior = behavior;
            _userContentBehavior = userContentBehavior;
            _userCourseBehavior = userCourseBehavior;
            _queries = queries;
            _mapper = mapper;
            _subjectQueries = subjectQueries;
            _userQueries = userQueries;
            _userContentQueries = userContentQueries;
            _userCourseQueries = userCourseQueries;
            _courseQueries = courseQueries;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<ContentViewModel>>> GetAllAsync()
        {
            return await _queries.FindAllAsync();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<ContentViewModel>> GetByIdAsync(int id)
        {
            var existingContent = await _queries.FindByIdAsync(id);
            if (existingContent == null)
            {
                return NotFound("el contenido no existe");
            }
            return existingContent;
        }

        [Route("GetReadContent/{username}/{id}")]
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(409)]
        public async Task<ActionResult<PlayerViewModel>> GetReadContentAsync(string username, int id)
        {
            var existingUser = await _userQueries.FindByUsernameAsync(username);

            ContentViewModel existingContent = await _queries.FindByIdAsync(id);
           
            if (existingContent == null || existingUser == null)
            {
                return NotFound("Usuario o contenido no existente");
            }

            var courseId = existingContent.CourseId;

            // Chequeamos si la matricula existe
            UserCourseViewModel userCourseViewModel = await _userCourseQueries.FindExistUserCourseAsync(username, courseId);

            if (userCourseViewModel == null)
            {
                return NotFound("No estas matriculado al curso");
            }

            BasicUserContentViewModel existingUserContent = await _userContentQueries.FindUserContentAsync(id, username);


            if (existingUserContent != null)
            {
                var userContentUpdate = _mapper.Map<UserContent>(existingUserContent);

                await _userContentBehavior.UpdateUserContentAsync(userContentUpdate);

                var existingUserContentViewModel = await _userContentQueries.FindUserContentAsync(userContentUpdate.Id, username);

                PlayerViewModel playerViewModel = new PlayerViewModel
                {
                    ContentPlayer = existingContent,
                    UserCoursePlayer = userCourseViewModel,
                    UserContentPlayer = existingUserContentViewModel

                };
                return playerViewModel;
            }

            UserContent usercontent = new UserContent
            { 
                Username=username,
                ContentId=id
            };
      
            await _userContentBehavior.CreateUserContentAsync(usercontent);

            BasicUserContentViewModel userContentPlayer = await _userContentQueries.FindByIdAsync(usercontent.Id);


            var countUserContents = await _userContentQueries.CountByContentAsync(courseId, username);
            var countContents = await _queries.CountByCourseIdAsync(courseId);


            var userCourse = _mapper.Map<UserCourse>(userCourseViewModel);

            await _userCourseBehavior.UpdateProgressUserCourseAsync(userCourse, countUserContents, countContents);

            UserCourseViewModel userCoursePlayer = await _userCourseQueries.FindByIdAsync(userCourse.Id);

            PlayerViewModel updatePlayerViewModel = new PlayerViewModel
            {
                ContentPlayer = existingContent,
                UserCoursePlayer = userCoursePlayer,
                UserContentPlayer = userContentPlayer

            };
            return updatePlayerViewModel;
        }

        [Route("BySubject/{SubjectId}")]
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<IEnumerable<ContentViewModel>>> GetAllBySubjectIdAsync(int SubjectId)
        {
            return await _queries.GetAllBySubjectIdAsync(SubjectId);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<ContentViewModel>> CreateContentAsync(CreateContentCommand createContentCommand)
        {
            var subjectId = createContentCommand.SubjectId;
            var existingSubject = await _subjectQueries.FindByIdAsync(subjectId);

            if (existingSubject == null)
            {
                return NotFound("El tema no existe");
            }

            var content = _mapper.Map<Content>(createContentCommand);
            await _behavior.CreateContentAsync(content);

            var contentViewModel = await _queries.FindByIdAsync(content.Id);

            return contentViewModel;
        }

        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<ContentViewModel>> UpdateContentAsync(int id, UpdateContentCommand updateContentCommand)
        {
            var existingContent = await _queries.FindByIdAsync(id);
            if (existingContent == null)
            {
                return NotFound();
            }

            Content contentUpdated = _mapper.Map<Content>(existingContent);
            _mapper.Map(updateContentCommand, contentUpdated);
            await _behavior.UpdateContentAsync(contentUpdated);

            var contentViewModel = await _queries.FindByIdAsync(contentUpdated.Id);

            return contentViewModel;
        }

        [Route("GetLastContentDescending/{courseId}/{username}")]
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<ContentViewModel>> GetLastContentDescending(int courseId, string username)
        {
            var existingUsername = await _userQueries.FindByUsernameAsync(username);
            var existingCourse = await _courseQueries.FindByIdAsync(courseId);

            if (existingUsername == null || existingCourse == null)
            {
                return NotFound("El usuario no existe o el curso no existe");
            }

            var existingUserContent = await _userContentQueries.FindLastUserContentAsync(courseId, username);

            if (existingUserContent == null)
            {
                return NoContent();
            }

            var existingContent = await _queries.FindByIdAsync(existingUserContent.ContentId);

            return existingContent;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteContentAsync(int id)
        {
            var existingContent = await _queries.FindByIdAsync(id);
            if (existingContent == null)
            {
                return NotFound("Contenido no encontrado");
            }

            Content contentDeleted = _mapper.Map<Content>(existingContent);
            await _behavior.DeleteContentAsync(contentDeleted);
            return NoContent();
        }
    }
}