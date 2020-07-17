using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SampleAPI.Commands;
using SampleAPI.Domain.Managers;
using SampleAPI.Domain.Models;
using SampleAPI.Queries;
using SampleAPI.ViewModels;

namespace SampleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private readonly ISubjectBehavior _behavior;

        private readonly ISubjectQueries _queries;

        private readonly ICourseQueries _courseQueries;

        private readonly IMapper _mapper;

        public SubjectsController(ISubjectBehavior behavior, ISubjectQueries queries, ICourseQueries courseQueries, IMapper mapper)
        {
            _behavior = behavior;
            _queries = queries;
            _mapper = mapper;
            _courseQueries = courseQueries;
        }

        [EnableCors("_myAllowSpecificOrigins")]
        [HttpGet]
        [ProducesResponseType(200)]
        [Authorize]
        public async Task<ActionResult<IEnumerable<SubjectViewModel>>> GetAllAsync()
        {
            return await _queries.FindAllAsync();
        }

        [EnableCors("_myAllowSpecificOrigins")]
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [Authorize("teacher:api")]
        public async Task<ActionResult<SubjectViewModel>> GetByIdAsync(int id)
        {
            var existingSubject = await _queries.FindByIdAsync(id);
            if (existingSubject == null)
            {
                return NotFound("Tema no hallado");
            }
            return existingSubject;
        }

        [EnableCors("_myAllowSpecificOrigins")]
        [Route("ByCourse/{courseId}")]
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [Authorize]
        public async Task<ActionResult<IEnumerable<SubjectViewModel>>> GetAllByCourseIdAsync(int courseId)
        {
            var existingCourse = await _courseQueries.FindByIdAsync(courseId);

            if (existingCourse == null)
            {
                return NotFound("El curso no existe");
            }

            return await _queries.GetAllByCourseIdAsync(courseId);
        }

        [EnableCors("_myAllowSpecificOrigins")]
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [Authorize("teacher:api")]
        public async Task<ActionResult<SubjectViewModel>> CreateSubjectAsync(CreateSubjectCommand createSubjectCommand)
        {
            var courseId = createSubjectCommand.CourseId;
            var existingCourse = await _courseQueries.FindByIdAsync(courseId);

            if (existingCourse == null)
            {
                return NotFound();
            }

            var subject = _mapper.Map<Subject>(createSubjectCommand);
            await _behavior.CreateSubjectAsync(subject);

            var subjectViewModel = await _queries.FindByIdAsync(subject.Id);

            return (subjectViewModel);
        }

        [EnableCors("_myAllowSpecificOrigins")]
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [Authorize("teacher:api")]
        public async Task<ActionResult<SubjectViewModel>> UpdateSubjectAsync(int id, UpdateSubjectCommand updateSubjectCommand)
        {
            var existingSubject = await _queries.FindByIdAsync(id);
            if (existingSubject == null)
            {
                return NotFound();
            }

            Subject subjectUpdated = _mapper.Map<Subject>(existingSubject);
            _mapper.Map(updateSubjectCommand, subjectUpdated);
            await _behavior.UpdateSubjectAsync(subjectUpdated);

            var subjectViewModel = await _queries.FindByIdAsync(subjectUpdated.Id);

            return (subjectViewModel);
        }

        [EnableCors("_myAllowSpecificOrigins")]
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [Authorize("teacher:api")]
        public async Task<IActionResult> DeleteSubjectAsync(int id)
        {
            var existingSubject = await _queries.FindByIdAsync(id);
            if (existingSubject == null)
            {
                return NotFound("el tema no existe");
            }

            Subject subjectDeleted = _mapper.Map<Subject>(existingSubject);
            await _behavior.DeleteSubjectAsync(subjectDeleted);
            return NoContent();
        }
    }
}