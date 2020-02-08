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

        private readonly ISubjectQueries _subjectQueries;

        private readonly IMapper _mapper;

        public ContentsController(IContentBehavior behavior, IContentQueries queries, IUserQueries userQueries, ISubjectQueries subjectQueries, IUserContentBehavior userContentBehavior, IUserCourseBehavior userCourseBehavior, IUserContentQueries userContentQueries, IUserCourseQueries userCourseQueries,  IMapper mapper)
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
        public async Task<ActionResult<ContentViewModel>> GetReadContentAsync(string username, int id)
        {
            var existingUser = await _userQueries.FindByUsernameAsync(username);
            var existingContent = await _queries.FindByIdAsync(id);
           
            if (existingContent == null || existingUser == null)
            {
                return NotFound();
            }

            var existingUserContent = await _userContentQueries.FindUserContentAsync(id, username);
            if (existingUserContent != null)
            {
                return existingContent;
            }

            UserContent usercontent = new UserContent
            { 
                Username=username,
                ContentId=id
            };
      
            await _userContentBehavior.CreateUserContentAsync(usercontent);

            var courseId = existingContent.CourseId;

            var countUserContents = await _userContentQueries.CountByContentAsync(courseId, username);
            var countContents = await _queries.CountByCourseIdAsync(courseId);

            // Chequeamos si la matricula existe

            UserCourseViewModel userCourseViewModel = await _userCourseQueries.FindExistUserCourseAsync(username, courseId);

            if(userCourseViewModel == null)
            {
                return NotFound();
            }

            var userCourse = _mapper.Map<UserCourse>(userCourseViewModel);

            await _userCourseBehavior.UpdateProgressUserCourseAsync(userCourse, countUserContents, countContents);

            return existingContent;
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

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteContentAsync(int id)
        {
            var existingContent = await _queries.FindByIdAsync(id);
            if (existingContent == null)
            {
                return NotFound();
            }

            Content contentDeleted = _mapper.Map<Content>(existingContent);
            await _behavior.DeleteContentAsync(contentDeleted);
            return NoContent();
        }
    }
}