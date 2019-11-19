using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SampleAPI.Commands;
using SampleAPI.Domain;
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

        private readonly IContentQueries _queries;

        private readonly IMapper _mapper;

        public ContentsController(IContentBehavior behavior, IContentQueries queries, IMapper mapper)
        {
            _behavior = behavior;
            _queries = queries;
            _mapper = mapper;
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
                return NotFound();
            }
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
        public async Task<ActionResult<Content>> CreateContentAsync(CreateContentCommand createContentCommand)
        {
            var content = _mapper.Map<Content>(createContentCommand);
            await _behavior.CreateContentAsync(content);
            return CreatedAtAction(
                nameof(GetByIdAsync),
                new { id = content.Id },
                _mapper.Map<BasicContentViewModel>(content));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateContentAsync(int id, UpdateContentCommand updateContentCommand)
        {
            var existingContent = await _queries.FindByIdAsync(id);
            if (existingContent == null)
            {
                return NotFound();
            }

            Content contentUpdated = _mapper.Map<Content>(existingContent);
            _mapper.Map(updateContentCommand, contentUpdated);
            await _behavior.UpdateContentAsync(contentUpdated);
            return NoContent();
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