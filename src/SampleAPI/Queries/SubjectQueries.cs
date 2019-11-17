using Microsoft.EntityFrameworkCore;
using SampleAPI.Domain;
using SampleAPI.Infrastructure;
using SampleAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPI.Queries
{
    public class SubjectQuerys : ISubjectQueries
    {
        protected readonly ApplicationDbContext _context;

        public SubjectQuerys(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<SubjectViewModel>> FindAllAsync()
        {
            return await _context.Subjects.AsNoTracking()
                .Include(c => c.Course)
                .Select(c => new SubjectViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    IsActive = c.IsActive,
                    CourseId = c.CourseId,
                    CourseName = c.Course.Name,
                    CreatedAt = c.CreatedAt,
                    UpdatedAt = c.UpdatedAt
                })
                .ToListAsync();
        }

        public async Task<SubjectViewModel> FindByIdAsync(int id)
        {
            return await _context.Subjects.AsNoTracking()
                .Include(c => c.Course)
                .Select(c => new SubjectViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    IsActive = c.IsActive,
                    CourseId = c.CourseId,
                    CourseName = c.Course.Name,
                    CreatedAt = c.CreatedAt,
                    UpdatedAt = c.UpdatedAt
                })
                .FirstOrDefaultAsync(subject => subject.Id == id);
        }

        //public async task<list<courseviewmodel>> getallbycategoryidasync(int categoryid)
        //{
        //    return await _context.courses.asnotracking()
        //        .include(c => c.category)
        //        .select(c => new courseviewmodel
        //        {
        //            id = c.id,
        //            name = c.name,
        //            description = c.description,
        //            isactive = c.isactive,
        //            categoryid = c.categoryid,
        //            categoryname = c.category.name,
        //            createdat = c.createdat,
        //            updatedat = c.updatedat
        //        })
        //        .where(course => course.categoryid == categoryid).tolistasync();
    }
}