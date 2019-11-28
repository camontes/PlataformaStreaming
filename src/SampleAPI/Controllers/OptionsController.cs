using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Options;
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
    public class OptionsController : ControllerBase
    {
        private readonly IOptionBehavior _behavior;

        private readonly IOptionQueries _queries;

        private readonly IQuestionQueries _questionQueries;

        private readonly IMapper _mapper;

        public OptionsController(IOptionBehavior behavior, IOptionQueries queries, IQuestionQueries questionQueries, IMapper mapper)
        {
            _behavior = behavior;
            _questionQueries = questionQueries;
            _queries = queries;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<OptionViewModel>>> GetAllAsync()
        {
            return await _queries.FindAllAsync();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<OptionViewModel>> GetByIdAsync(int id)
        {
            var existingOption = await _queries.FindByIdAsync(id);
            if (existingOption == null)
            {
                return NotFound();
            }
            return existingOption;
        }

        [Route("ByQuestion/{QuestionId}")]
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<IEnumerable<OptionViewModel>>> GetAllByQuestionIdAsync(int QuestionId)
        {
            return await _queries.GetAllByQuestionIdAsync(QuestionId);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Option>> CreateOptionAsync(CreateOptionCommand createOptionCommand)
        {
            var questionId = createOptionCommand.QuestionId;
            var existingQuestion = await _questionQueries.FindByIdAsync(questionId);

            if (existingQuestion == null)
            {
                return NotFound();
            }

            List<OptionList> options = createOptionCommand.Options;
            var counter = 0;
            for (var i = 0; i < options.Count; ++i)
            {
                if (options[i].IsCorrect == true) counter++;             
            }

            if (counter > 1)
            {
                return Conflict();
            }

            for (var i = 0; i < options.Count; ++i)
            {
                Option option = new Option
                {
                    Content = options[i].Content,
                    QuestionId = createOptionCommand.QuestionId,
                    IsCorrect = options[i].IsCorrect
                };
                await _behavior.CreateOptionAsync(option);
            }

            return Ok();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateOptionAsync(int id, UpdateOptionCommand updateOptionCommand)
        {
            var existingOption = await _queries.FindByIdAsync(id);
            if (existingOption == null)
            {
                return NotFound();
            }

            Option optionUpdated = _mapper.Map<Option>(existingOption);
            _mapper.Map(updateOptionCommand, optionUpdated);
            await _behavior.UpdateOptionAsync(optionUpdated);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteOptionAsync(int id)
        {
            var existingOption = await _queries.FindByIdAsync(id);
            if (existingOption == null)
            {
                return NotFound();
            }

            Option optionDeleted = _mapper.Map<Option>(existingOption);
            await _behavior.DeleteOptionAsync(optionDeleted);
            return NoContent();
        }
    }
}
