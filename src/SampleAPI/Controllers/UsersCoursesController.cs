﻿using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
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
    public class UsersCoursesController : ControllerBase
    {
        private readonly IUserCourseBehavior _behavior;

        private readonly ICourseBehavior _courseBehavior;

        private readonly IUserCourseQueries _queries;

        private readonly IUserQueries _userQueries;

        private readonly ICourseQueries _courseQueries;

        private readonly IMapper _mapper;

        public UsersCoursesController(IUserCourseBehavior behavior, ICourseBehavior courseBehavior, IUserCourseQueries queries, ICourseQueries courseQueries, IUserQueries userQueries,   IMapper mapper)
        {
            _behavior = behavior;
            _queries = queries;
            _mapper = mapper;
            _courseQueries = courseQueries;
            _courseBehavior = courseBehavior;
            _userQueries = userQueries;
        }

        [EnableCors("_myAllowSpecificOrigins")]
        [HttpGet]
        [ProducesResponseType(200)]
        [Authorize]
        public async Task<ActionResult<IEnumerable<UserCourseViewModel>>> GetAllAsync()
        {
            return await _queries.FindAllAsync();
        }

        [EnableCors("_myAllowSpecificOrigins")]
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [Authorize]
        public async Task<ActionResult<UserCourseViewModel>> GetByIdAsync(int id)
        {
            var existingUserCourse = await _queries.FindByIdAsync(id);
            if (existingUserCourse == null)
            {
                return NotFound("el curso no existe");
            }
            return existingUserCourse;
        }

        [EnableCors("_myAllowSpecificOrigins")]
        [Route("ByUsername/{Username}")]
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [Authorize]
        public async Task<ActionResult<IEnumerable<UserCourseViewModel>>> GetAllByUsernameAsync(string Username)
        {
            return await _queries.FindAllByUsernameAsync(Username);
        }

        [EnableCors("_myAllowSpecificOrigins")]
        [Route("StreamingByUsername/{Username}")]
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [Authorize]
        public async Task<ActionResult<IEnumerable<UserCourseViewModel>>> GetStreamingByUsernameAsync(string Username)
        {
            return await _queries.FindAllStreamingByUser(Username);
        }

        [EnableCors("_myAllowSpecificOrigins")]
        [Route("ByCourse/{CourseId}")]
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [Authorize]
        public async Task<ActionResult<IEnumerable<UserCourseViewModel>>> GetAllByCourseIdAsync(int CourseId)
        {
            var existingCourse = _courseQueries.FindByIdAsync(CourseId);

            if(existingCourse == null)
            {
                return NotFound("El curso no existe");
            }

            return await _queries.FindAllByCourseIdAsync(CourseId);
        }

        [EnableCors("_myAllowSpecificOrigins")]
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        [Authorize]
        public async Task<ActionResult<UserCourseViewModel>> CreateUserCourseAsync(CreateUserCourseCommand createUserCourseCommand)
        {
            var username = createUserCourseCommand.Username;
            var courseId = createUserCourseCommand.CourseId;

            var existingUser = await _userQueries.FindByUsernameAsync(username);
            var existingCourse = await _courseQueries.FindByIdAsync(courseId);

            if (existingUser == null || existingCourse == null)
            {
                return NotFound("El usuario no existe o el curso no existe");
            }

            var existingRegister = await _queries.FindExistUserCourseAsync(username, courseId);
            if (existingRegister != null)
            {
                return NoContent();
            }

            var userCourse = _mapper.Map<UserCourse>(createUserCourseCommand);
            await _behavior.CreateUserCourseAsync(userCourse);

            var course = _mapper.Map<Course>(existingCourse);
            await _courseBehavior.UpdateEnrolledStudentCourseAsync(course);

            var createdUserCourse = await _queries.FindByIdAsync(userCourse.Id);
            //CourseViewModel courseViewModel = _mapper.Map<CourseViewModel>(createdCourse);
            return createdUserCourse;
        }

        [EnableCors("_myAllowSpecificOrigins")]
        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(201)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<UserCourseViewModel>> UpdateRatingUserCourseAsync(int id, UpdateUserCourseCommand updateUserCourseCommand)
        {

            var existingUserCourse = await _queries.FindByIdAsync(id);

            if (existingUserCourse == null)
            {
                return NotFound();
            }

            var courseId = existingUserCourse.CourseId;
            var existingCourse = await _courseQueries.FindByIdAsync(courseId);

            if (existingCourse == null)
            {
                return NotFound();
            }


            UserCourse userCourseUpdated = _mapper.Map<UserCourse>(existingUserCourse);
            _mapper.Map(updateUserCourseCommand, userCourseUpdated);
            await _behavior.UpdateRatingUserCourseAsync(userCourseUpdated);

            var averageCourse = await _queries.AverageCourseAsync(courseId);
            Course courseUpdated = _mapper.Map<Course>(existingCourse);
            await _courseBehavior.UpdateRatingCourseAsync(courseUpdated, averageCourse);

            UserCourseViewModel updateUserCourse = await _queries.FindByIdAsync(userCourseUpdated.Id);
            return updateUserCourse;
        }

        [EnableCors("_myAllowSpecificOrigins")]
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [Authorize]
        public async Task<IActionResult> DeleteUserCourseAsync(int id)
        {
            var existingUserCourse = await _queries.FindByIdAsync(id);
            if (existingUserCourse == null)
            {
                return NotFound();
            }


            UserCourse userCourseDeleted = _mapper.Map<UserCourse>(existingUserCourse);
            await _behavior.DeleteUserCourseAsync(userCourseDeleted);
            return NoContent();
        }
    }
}
