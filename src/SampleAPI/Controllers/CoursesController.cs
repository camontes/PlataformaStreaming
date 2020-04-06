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
    public class CoursesController : ControllerBase
    {
        private readonly ICourseBehavior _behavior;

        private readonly ICourseQueries _queries;

        private readonly IContentQueries _contentQueries;

        private readonly IQuestionQueries _questionQueries;

        private readonly IOptionQueries _optionQueries;

        private readonly ISubjectQueries _subjectQueries;

        private readonly ICategoryQueries _categoryQueries;

        private readonly IUserQueries _userQueries;

        private readonly IMapper _mapper;

        IHostingEnvironment _env;

        public CoursesController(ICourseBehavior behavior,
                                IContentQueries contentQueries,
                                ICourseQueries queries,
                                ISubjectQueries subjectQueries,
                                IUserQueries userQueries,
                                ICategoryQueries categoryQueries,
                                IOptionQueries optionQueries,
                                IQuestionQueries questionQueries,
                                IMapper mapper,
                                IHostingEnvironment environment
                                )
        {
            _behavior = behavior;
            _queries = queries;
            _contentQueries = contentQueries;
            _optionQueries = optionQueries;
            _subjectQueries = subjectQueries;
            _categoryQueries = categoryQueries;
            _questionQueries = questionQueries;
            _userQueries = userQueries;
            _mapper = mapper;
            _env = environment;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [Authorize]
        public async Task<ActionResult<IEnumerable<CourseViewModel>>> GetAllAsync()
        {
            return await _queries.FindAllAsync();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [Authorize]
        public async Task<ActionResult<CourseViewModel>> GetByIdAsync(int id)
        {
            var existingCourse = await _queries.FindByIdAsync(id);
            if (existingCourse == null)
            {
                return NotFound("el curso no existe");
            }
            return existingCourse;
        }

        [Route("ByCategory/{CategoryId}")]
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [Authorize]
        public async Task<ActionResult<IEnumerable<CourseViewModel>>> GetAllByCategoryIdAsync(int CategoryId)
        {
            return await _queries.GetAllByCategoryIdAsync(CategoryId);
        }

        [Route("ByUsername/{username}")]
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [Authorize("teacher:api")]
        public async Task<ActionResult<IEnumerable<CourseViewModel>>> GetAllByUsernameAsync(string username)
        {
            return await _queries.GetAllByUsernameAsync(username);
        }



        [EnableCors("_myAllowSpecificOrigins")]
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [Authorize("teacher:api")]
        public async Task<ActionResult<CourseViewModel>> CreateCourseAsync(CreateCourseCommand createCourseCommand)
        {

            var categoryId = createCourseCommand.CategoryId;
            var username = createCourseCommand.Username;
            var existingCategory = await _categoryQueries.FindByIdAsync(categoryId);

            if (existingCategory == null)
            {
                return NotFound("No se puede crear el curso porque la categoria no existe");
            }
            var existingUser = await _userQueries.FindByUsernameAsync(username);

            if (existingUser == null)
            {
                return NotFound("No se puede crear el curso porque el usuario no existe");
            }


            Course course = _mapper.Map<Course>(createCourseCommand);
            await _behavior.CreateCourseAsync(course);

            var createdCourse = await _queries.FindByIdAsync(course.Id);
            return createdCourse;
        }

        [Route("SavePhoto")]
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [Authorize("teacher:api")]
        public async Task<ActionResult<string>> SaveCoursePhotoAsync(IFormFile photo)
        {
            if (photo != null && photo.Length > 0)
            {
                var imagePath = @"/Images/Courses/";
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
                var filePath =  Path.Combine(imagePath, filename);

                using (FileStream fileStream = new FileStream(fullpath, FileMode.Create))
                {
                    await photo.CopyToAsync(fileStream);
                }

                return filePath;
            }

            return "";

        }

        [EnableCors("_myAllowSpecificOrigins")]
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(409)]
        [Authorize("teacher:api")]
        public async Task<ActionResult<CourseViewModel>> UpdateCourseAsync(int id, UpdateCourseCommand updateCourseCommand)
        {
            var existingCourse = await _queries.FindByIdAsync(id);
            if (existingCourse == null)
            {
                return NotFound("el curso no existe");
            }

            if (existingCourse.IsPublished)
            {
                return Conflict("no se puede actualizar un curso que ya esta publicado");
            }

            var categoryId = updateCourseCommand.CategoryId;
            var exisingCategory =await  _categoryQueries.FindByIdAsync(categoryId);

            if(exisingCategory == null)
            {
                return NotFound("la categoria no existe");
            }

            Course courseUpdated = _mapper.Map<Course>(existingCourse);
            _mapper.Map(updateCourseCommand, courseUpdated);
            await _behavior.UpdateCourseAsync(courseUpdated, existingCourse.Photo);

            var courseViewModel = await _queries.FindByIdAsync(courseUpdated.Id);

            return (courseViewModel);
        }


        //validate can be posted
        [EnableCors("_myAllowSpecificOrigins")]
        [Route("CourseCanBePosted/{id}")]
        [HttpGet]
        [ProducesResponseType(204)]
        [ProducesResponseType(200)]
        [ProducesResponseType(409)]
        [ProducesResponseType(404)]
        [Authorize("teacher:api")]
        public async Task<ActionResult<CourseViewModel>> CourseCanBePostedAsync(int id)
        {
            var existingCourse = await _queries.FindByIdAsync(id);

            if (existingCourse == null)
            {
                return NotFound("Curso no encontrado");
            }

            var existingSubjects = await _subjectQueries.GetAllByCourseIdAsync(id);

            if (existingSubjects.Count == 0)
            {
                return NoContent();
            }

            for (var i = 0; i < existingSubjects.Count; i++)
            {
                var subjectId = existingSubjects[i].Id;
                var existingContents = await _contentQueries.GetAllBySubjectIdAsync(subjectId);

                if (existingContents.Count == 0)
                {
                    return NoContent();
                }
            }

            //validate if exist questions and options of course

            var existingquestions = await _questionQueries.GetAllByCourseIdAsync(id);
            if (existingquestions.Count < 5)
            {
                return NoContent();
            }
            for (var i = 0; i < existingquestions.Count; i++)
            {
                var optionId = existingquestions[i].Id;
                var existingOptions = await _optionQueries.GetAllByQuestionIdAsync(optionId);

                if (existingOptions.Count < 4)
                {
                    return NoContent();
                }
            }

            var courseViewModel = await _queries.FindByIdAsync(existingCourse.Id);
            return (courseViewModel);
        }


        //validar si se puede publicar el curso
        [Route("PostCourse/{id}")]
        [HttpPut]
        [ProducesResponseType(204)]
        [ProducesResponseType(200)]
        [ProducesResponseType(409)]
        [ProducesResponseType(404)]
        [Authorize("teacher:api")]
        public async Task<ActionResult<CourseViewModel>> PostCourseAsync(int id)
        {
            var existingCourse = await _queries.FindByIdAsync(id);

            if (existingCourse == null)
            {
                return NotFound("Curso no encontrado");
            }

            Course courseUpdated = _mapper.Map<Course>(existingCourse);
            await _behavior.UpdatePostCourseAsync(courseUpdated);

            var courseViewModel = await _queries.FindByIdAsync(courseUpdated.Id);
            return (courseViewModel);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(409)]
        [Authorize("teacher:api")]
        public async Task<IActionResult> DeleteCourseAsync(int id)
        {
            var existingCourse = await _queries.FindByIdAsync(id);
            if (existingCourse == null)
            {
                return NotFound("el curso no existe");
            }
            if (existingCourse.IsPublished)
            {
                return Conflict("no se puede borrar un curso que ya esta publicado");
            }

            Course courseDeleted = _mapper.Map<Course>(existingCourse);
            await _behavior.DeleteCourseAsync(courseDeleted);
            return NoContent();
        }
    }
}