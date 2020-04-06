using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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

        IHostingEnvironment _env;

        public CategoriesController(ICategoryBehavior behavior,
            ICategoryQueries queries,
            IMapper mapper,
            IHostingEnvironment environment
            )
        {
            _behavior = behavior;
            _queries = queries;
            _mapper = mapper;
            _env = environment;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Category>>> GetAllAsync()
        {
            return await _queries.FindAllAsync();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [Authorize("admin:api")]
        public async Task<ActionResult<Category>> GetByIdAsync(int id)
        {
            var existingCategory = await _queries.FindByIdAsync(id);
            if (existingCategory == null)
            {
                return NotFound();
            }
            return existingCategory;
        }

        [Route("SavePhoto")]
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [Authorize("admin:api")]
        public async Task<ActionResult<string>> SaveCoursePhotoAsync(IFormFile photo)
        {
            if (photo != null && photo.Length > 0)
            {
                var imagePath = @"/Images/Categories/";
                var uploadPath = "C:\\Users\\juanCarlos\\source\\repos\\StreamingReact\\public" + imagePath;
                //var uploadPath = "C:\\Users\\Camilo Lopez\\Documents\\Universidad\\Proyecto de grado\\RepoFrontend\\PlataformaFrontend\\StreamingReact\\public" + imagePath;

                //Create Directory
                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }
                //Create Uniq file name
                var uniqFileName = Guid.NewGuid().ToString();
                var filename = Path.GetFileName(uniqFileName + "." + photo.FileName.Split(".")[1].ToLower());
                string fullpath = uploadPath + filename;

                //imagePath = imagePath + @"/";
                var filePath = Path.Combine(imagePath, filename);

                using (FileStream fileStream = new FileStream(fullpath, FileMode.Create))
                {
                    await photo.CopyToAsync(fileStream);
                }

                return filePath;
            }

            return "";

        }
        [EnableCors("_myAllowSpecificOrigins")]
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [Authorize("admin:api")]
        public async Task<ActionResult<Category>> CreateCategoryAsync(CreateCategoryCommand createCategoryCommand)
        {
            var category = _mapper.Map<Category>(createCategoryCommand);
            await _behavior.CreateCategoryAsync(category);

            var existingCategory = await _queries.FindByIdAsync(category.Id);

            return existingCategory;
        }

        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [Authorize("admin:api")]
        public async Task<ActionResult<Category>> UpdateCategoryAsync(int id, UpdateCategoryCommand updateCategoryCommand)
        {
            var existingCategory = await _queries.FindByIdAsync(id);
            var photo = existingCategory.Photo;

            if (existingCategory == null)
            {
                return NotFound();
            }

            _mapper.Map(updateCategoryCommand, existingCategory);
            await _behavior.UpdateCategoryAsync(existingCategory, photo);

            var category = await _queries.FindByIdAsync(id);

            return category;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [Authorize("admin:api")]
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