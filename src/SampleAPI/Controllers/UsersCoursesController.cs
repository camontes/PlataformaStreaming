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
    public class UsersCoursesController : ControllerBase
    {
        private readonly ICourseBehavior _behavior;

        private readonly IUserCourseQueries _queries;

        private readonly IMapper _mapper;

        public UsersCoursesController(ICourseBehavior behavior, IUserCourseQueries queries, IMapper mapper)
        {
            _behavior = behavior;
            _queries = queries;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<UserCourseViewModel>>> GetAllAsync()
        {
            return await _queries.FindAllAsync();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<UserCourseViewModel>> GetByIdAsync(int id)
        {
            var existingUserCourse = await _queries.FindByIdAsync(id);
            if (existingUserCourse == null)
            {
                return NotFound();
            }
            return existingUserCourse;
        }

        [Route("ByUser/{Username}")]
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<IEnumerable<UserCourseViewModel>>> GetAllByUsernameAsync(string Username)
        {
            return await _queries.FindAllByUsernameAsync(Username);
        }

        [Route("ByCourse/{CourseId}")]
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<IEnumerable<UserCourseViewModel>>> GetAllByCourseIdAsync(int CourseId)
        {
            return await _queries.FindAllByCourseIdAsync(CourseId);
        }
    }
}
