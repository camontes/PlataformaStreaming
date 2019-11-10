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
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryBehavior _behavior;

        private readonly ICategoryQueries _queries;

        private readonly IMapper _mapper;

        public CategoriesController(ICategoryBehavior behavior, ICategoryQueries queries, IMapper mapper)
        {
            _behavior = behavior;
            _queries = queries;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<Category>>> GetAllAsync()
        {
            return await _queries.FindAllAsync();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Category>> GetByIdAsync(int id)
        {
            var existingCategory = await _queries.FindByIdAsync(id);
            if (existingCategory == null)
            {
                return NotFound();
            }
            return existingCategory;
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<Category>> CreateCategoryAsync(CreateCategoryCommand createCategoryCommand)
        {
            var category = _mapper.Map<Category>(createCategoryCommand);
            await _behavior.CreateCategoryAsync(category);
            return CreatedAtAction(
                nameof(GetByIdAsync),
                new { id = category.Id },
                _mapper.Map<BasicCategoryViewModel>(category));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateCategoryAsync(int id, UpdateCategoryCommand updateCategoryCommand)
        {
            var existingCategory = await _queries.FindByIdAsync(id);
            if (existingCategory == null)
            {
                return NotFound();
            }

            _mapper.Map(updateCategoryCommand, existingCategory);
            await _behavior.UpdateCategoryAsync(existingCategory);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteCategoryAsync(int id)
        {
            var existingCategory = await _queries.FindByIdAsync(id);
            if (existingCategory == null)
            {
                return NotFound();
            }

            await _behavior.DeleteCategoryAsync(existingCategory);
            return NoContent();
        }
    }
}