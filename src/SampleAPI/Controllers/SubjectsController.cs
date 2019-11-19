using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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

        private readonly IMapper _mapper;

        public SubjectsController(ISubjectBehavior behavior, ISubjectQueries queries, IMapper mapper)
        {
            _behavior = behavior;
            _queries = queries;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<SubjectViewModel>>> GetAllAsync()
        {
            return await _queries.FindAllAsync();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<SubjectViewModel>> GetByIdAsync(int id)
        {
            var existingSubject = await _queries.FindByIdAsync(id);
            if (existingSubject == null)
            {
                return NotFound();
            }
            return existingSubject;
        }

        [Route("ByCourse/{courseId}")]
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<IEnumerable<SubjectViewModel>>> GetAllByCourseIdAsync(int courseId)
        {
            return await _queries.GetAllByCourseIdAsync(courseId);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<Subject>> CreateSubjectAsync(CreateSubjectCommand createSubjectCommand)
        {
            var subject = _mapper.Map<Subject>(createSubjectCommand);

            await _behavior.CreateSubjectAsync(subject);
            return CreatedAtAction(
                nameof(GetByIdAsync),
                new { id = subject.Id },
                _mapper.Map<BasicSubjectViewModel>(subject));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateSubjectAsync(int id, UpdateSubjectCommand updateSubjectCommand)
        {
            var existingSubject = await _queries.FindByIdAsync(id);
            if (existingSubject == null)
            {
                return NotFound();
            }

            Subject subjectUpdated = _mapper.Map<Subject>(existingSubject);
            _mapper.Map(updateSubjectCommand, subjectUpdated);
            await _behavior.UpdateSubjectAsync(subjectUpdated);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteSubjectAsync(int id)
        {
            var existingSubject = await _queries.FindByIdAsync(id);
            if (existingSubject == null)
            {
                return NotFound();
            }

            Subject subjectDeleted = _mapper.Map<Subject>(existingSubject);
            await _behavior.DeleteSubjectAsync(subjectDeleted);
            return NoContent();
        }
    }
}