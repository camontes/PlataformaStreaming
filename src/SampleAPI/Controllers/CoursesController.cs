﻿using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
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
    public class CoursesController : ControllerBase
    {
        private readonly ICourseBehavior _behavior;

        private readonly ICourseQueries _queries;

        private readonly IContentQueries _contentQueries;

        private readonly ISubjectQueries _subjectQueries;

        private readonly ICategoryQueries _categoryQueries;

        private readonly IUserQueries _userQueries;

        private readonly IMapper _mapper;

        public CoursesController(ICourseBehavior behavior,
                                IContentQueries contentQueries,
                                ICourseQueries queries,
                                ISubjectQueries subjectQueries,
                                IUserQueries userQueries,
                                ICategoryQueries categoryQueries,
                                IMapper mapper)
        {
            _behavior = behavior;
            _queries = queries;
            _contentQueries = contentQueries;
            _subjectQueries = subjectQueries;
            _categoryQueries = categoryQueries;
            _userQueries = userQueries;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<CourseViewModel>>> GetAllAsync()
        {
            return await _queries.FindAllAsync();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<CourseViewModel>> GetByIdAsync(int id)
        {
            var existingCourse = await _queries.FindByIdAsync(id);
            if (existingCourse == null)
            {
                return NotFound();
            }
            return existingCourse;
        }

        [Route("ByCategory/{CategoryId}")]
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<IEnumerable<CourseViewModel>>> GetAllByCategoryIdAsync(int CategoryId)
        {
            return await _queries.GetAllByCategoryIdAsync(CategoryId);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Course>> CreateCourseAsync(CreateCourseCommand createCourseCommand)
        {
            var categoryId = createCourseCommand.CategoryId;
            var username = createCourseCommand.Username;
            var existingCategory = await _categoryQueries.FindByIdAsync(categoryId);
            var existingUser = await _userQueries.FindByUsernameAsync(username);

            if (existingCategory == null || existingUser == null)
            {
                return NotFound();
            }

            Course course = _mapper.Map<Course>(createCourseCommand);
            await _behavior.CreateCourseAsync(course);
            return CreatedAtAction(
                nameof(GetByIdAsync),
                new { id = course.Id },
                _mapper.Map<BasicCourseViewModel>(course));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateCourseAsync(int id, UpdateCourseCommand updateCourseCommand)
        {
            var existingCourse = await _queries.FindByIdAsync(id);
            if (existingCourse == null)
            {
                return NotFound();
            }

            Course courseUpdated = _mapper.Map<Course>(existingCourse);
            _mapper.Map(updateCourseCommand, courseUpdated);
            await _behavior.UpdateCourseAsync(courseUpdated);
            return NoContent();
        }

        //validar si se puede publicar el curso
        [Route("PostCourse/{id}")]
        [HttpPut]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> PostCourseAsync(int id)
        {
            var existingCourse = await _queries.FindByIdAsync(id);

            if (existingCourse == null)
            {
                return NotFound("curso no encontrado");
            }

            var existingSubjects = await _subjectQueries.GetAllByCourseIdAsync(id);

            if (existingSubjects.Count == 0)
            {
                return NotFound("el curso no tiene temas y no se puede publicar");
            }

            for (var i = 0; i < existingSubjects.Count; i++)
            {
                var subjectId = existingSubjects[i].Id;
                var existingContents = await _contentQueries.GetAllBySubjectIdAsync(subjectId);

                if (existingContents.Count == 0)
                {
                    return NotFound("no se puede publicar porque hay temas que no contienen contenidos");
                }
            }
            

            Course courseUpdated = _mapper.Map<Course>(existingCourse);
            await _behavior.UpdatePostCourseAsync(courseUpdated);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteCourseAsync(int id)
        {
            var existingCourse = await _queries.FindByIdAsync(id);
            if (existingCourse == null)
            {
                return NotFound();
            }

            Course courseDeleted = _mapper.Map<Course>(existingCourse);
            await _behavior.DeleteCourseAsync(courseDeleted);
            return NoContent();
        }
    }
}