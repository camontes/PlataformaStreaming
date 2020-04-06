using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionBehavior _behavior;

        private readonly IQuestionQueries _queries;

        private readonly ICourseQueries _courseQueries;

        private readonly IOptionQueries _optionQueries;

        private readonly IMapper _mapper;

        public QuestionsController(IQuestionBehavior behavior,
            IQuestionQueries queries,
            ICourseQueries courseQueries,
            IOptionQueries optionQueries,
            IMapper mapper)
        {
            _behavior = behavior;
            _queries = queries;
            _mapper = mapper;
            _courseQueries = courseQueries;
            _optionQueries = optionQueries;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [Authorize]
        public async Task<ActionResult<IEnumerable<QuestionViewModel>>> GetAllAsync()
        {
            return await _queries.FindAllAsync();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [Authorize("teacher:api")]
        public async Task<ActionResult<QuestionViewModel>> GetByIdAsync(int id)
        {
            var existingQuestion = await _queries.FindByIdAsync(id);
            if (existingQuestion == null)
            {
                return NotFound("La pregunta no existe");
            }
            return existingQuestion;
        }

        [Route("ByCourse/{CourseId}")]
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [Authorize("teacher:api")]
        public async Task<ActionResult<IEnumerable<QuestionViewModel>>> GetAllByCourseIdAsync(int CourseId)
        {
            return await _queries.GetAllByCourseIdAsync(CourseId);
        }

        [Route("QuestionExam/{CourseId}")]
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [Authorize]
        public async Task<ActionResult<IEnumerable<QuestionViewModel>>> GetQuestionExamAsync(int CourseId)
        {
            List<QuestionViewModel> questionsExam = new List<QuestionViewModel>();
            List<QuestionViewModel> randomizedList = new List<QuestionViewModel>();

            var questions = await _queries.GetAllByCourseIdAsync(CourseId);

            for(var i = 0; i < questions.Count; i++)
            {
                var options = await _optionQueries.GetAllByQuestionIdAsync(questions[i].Id);

                if (options.Count != 0)
                {
                    questionsExam.Add(questions[i]);
                }
            }

            //questions random with options
            Random rnd = new Random();
            while (questionsExam.Count > 0)
            {
                int index = rnd.Next(0, questionsExam.Count); //pick a random item from the master list
                randomizedList.Add(questionsExam[index]); //place it at the end of the randomized list
                questionsExam.RemoveAt(index);
            }
            return randomizedList.GetRange(0, 5);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [Authorize("teacher:api")]
        public async Task<ActionResult<QuestionViewModel>> CreateQuestionAsync(CreateQuestionCommand createQuestionCommand)
        {
            var courseId = createQuestionCommand.CourseId;
            var existingCourse = await _courseQueries.FindByIdAsync(courseId);

            if (existingCourse == null)
            {
                return NotFound();
            }

            Question question = _mapper.Map<Question>(createQuestionCommand);
            await _behavior.CreateQuestionAsync(question);

            var questionViewModel = await _queries.FindByIdAsync(question.Id);

            return (questionViewModel);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [Authorize("teacher:api")]
        public async Task<ActionResult<QuestionViewModel>> UpdateQuestionAsync(int id, UpdateQuestionCommand updateQuestionCommand)
        {
            var existingQuestion = await _queries.FindByIdAsync(id);
            if (existingQuestion == null)
            {
                return NotFound();
            }

            Question questionUpdated = _mapper.Map<Question>(existingQuestion);
            _mapper.Map(updateQuestionCommand, questionUpdated);
            await _behavior.UpdateQuestionAsync(questionUpdated);

            var questionViewModel = await _queries.FindByIdAsync(questionUpdated.Id);

            return (questionViewModel);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [Authorize("teacher:api")]
        public async Task<IActionResult> DeleteQuestionAsync(int id)
        {
            var existingQuestion = await _queries.FindByIdAsync(id);
            if (existingQuestion == null)
            {
                return NotFound();
            }

            Question questionDeleted = _mapper.Map<Question>(existingQuestion);
            await _behavior.DeleteQuestionAsync(questionDeleted);
            return NoContent();
        }
    }
}
