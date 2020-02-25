using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
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

        private readonly IUserCourseQueries _userCourseQueries;

        private readonly IQuestionQueries _questionQueries;

        private readonly IMapper _mapper;

        public OptionsController(IOptionBehavior behavior,
            IOptionQueries queries,
            IQuestionQueries questionQueries,
            IUserCourseQueries userCourseQueries,
            IMapper mapper)
        {
            _behavior = behavior;
            _questionQueries = questionQueries;
            _queries = queries;
            _mapper = mapper;
            _userCourseQueries = userCourseQueries;
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
                return NotFound("La opcion no existe");
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
        [ProducesResponseType(409)]
        public async Task<ActionResult<Option>> CreateOptionAsync(CreateOptionCommand createOptionCommand)
        {
            var questionId = createOptionCommand.QuestionId;
            var existingQuestion = await _questionQueries.FindByIdAsync(questionId);

            if (existingQuestion == null)
            {
                return NotFound("La pregunta no existe");
            }

            List<OptionList> options = createOptionCommand.Options;
            var counter = 0;
            for (var i = 0; i < options.Count; ++i)
            {
                if (options[i].IsCorrect == true) counter++;             
            }

            if (counter > 1)
            {
                return Conflict("Solo se admite una pregunta verdadera");
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

        [Route("ValidateExam")]
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<int>> ValidateAnswerExam(AnswersExam answersExam)
        {
            var existingUserCourse = await _userCourseQueries.FindByIdAsync(answersExam.userCourseId);

            if (existingUserCourse == null)
            {
                return NotFound("La matricula no existe");
            }
            int correctAnswers = 0;

            for (var i = 0; i < answersExam.options.Count; i++)
            {
                var options = await _queries.FindByIdAsync(answersExam.options[i]);

                if (options == null)
                {
                    return NotFound("La opcion no existe");
                }

                if (options.IsCorrect)
                {
                    correctAnswers += 1;
                }
            }
            return correctAnswers;
        }

        [HttpPut]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(409)]
        public async Task<IActionResult> UpdateOptionAsync(CreateOptionCommand createOptionCommand)
        {
            var questionId = createOptionCommand.QuestionId;
            var existingQuestion = await _questionQueries.FindByIdAsync(questionId);

            if (existingQuestion == null)
            {
                return NotFound("La pregunta no existe");
            }

            List<OptionList> options = createOptionCommand.Options;
            var counter = 0;
            for (var i = 0; i < options.Count; ++i)
            {
                if (options[i].IsCorrect == true) counter++;
            }

            if (counter > 1)
            {
                return Conflict("Solo se admite una pregunta verdadera");
            }

            var existingOptionsByQuestionId = await _queries.GetAllByQuestionIdAsync(questionId);

            if(existingOptionsByQuestionId == null)
            {
                return NotFound("La pregunta no tiene opciones, es posible que ya no existan");
            }

            for (var i = 0; i < existingOptionsByQuestionId.Count; ++i)
            {
                OptionViewModel option = existingOptionsByQuestionId[i];
                Option optionUpdated = _mapper.Map<Option>(option);
                _mapper.Map(options[i], optionUpdated);
                await _behavior.UpdateOptionAsync(optionUpdated);
            }

            return Ok();
        }

        [EnableCors("_myAllowSpecificOrigins")]
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(409)]
        public async Task<ActionResult<List<int>>> DeleteOptionAsync(int id)
        {
            List<int> idOptions = new List<int>();

            var existingQuestion = await _questionQueries.FindByIdAsync(id);
            if (existingQuestion == null)
            {
                return NotFound("La pregunta no existe");
            }
            var existingOptionsByQuestionId = await _queries.GetAllByQuestionIdAsync(id);

            if (existingOptionsByQuestionId.Count == 0)
            {
                return NotFound("La pregunta no tiene opciones, es posible que ya no existan");
            }

            for (var i = 0; i < existingOptionsByQuestionId.Count; ++i)
            {
                OptionViewModel option = existingOptionsByQuestionId[i];
                idOptions.Add(option.Id);
                Option optionUpdated = _mapper.Map<Option>(option);
                await _behavior.DeleteOptionAsync(optionUpdated);
            }
            return idOptions;
        }
    }
}
