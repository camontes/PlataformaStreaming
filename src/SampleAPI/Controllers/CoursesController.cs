using System.Collections.Generic;
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

        private readonly IMapper _mapper;

        public CoursesController(ICourseBehavior behavior, ICourseQueries queries, IMapper mapper)
        {
            _behavior = behavior;
            _queries = queries;
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
        public async Task<ActionResult<Course>> CreateCourseAsync(CreateCourseCommand createCourseCommand)
        {
            var course = _mapper.Map<Course>(createCourseCommand);
            await _behavior.CreateCourseAsync(course);
            return CreatedAtAction(
                nameof(GetByIdAsync),
                new { id = course.Id },
                _mapper.Map<CourseViewModel>(course));
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