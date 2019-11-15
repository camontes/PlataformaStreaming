﻿using Microsoft.EntityFrameworkCore;
using SampleAPI.Domain;
using SampleAPI.Infrastructure;
using SampleAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPI.Queries
{
    public class UserCourseQuerys : IUserCourseQueries
    {
        protected readonly ApplicationDbContext _context;

        public UserCourseQuerys(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<UserCourseViewModel>> FindAllAsync()
        {
            return await _context.UsersCourses.AsNoTracking()
                .Include(c => c.Course)
                .Include(c => c.User)
                .Select(c => new UserCourseViewModel
                {
                    Id = c.Id,
                    CourseId = c.CourseId,
                    CourseName = c.Course.Name,
                    Username = c.Username,
                    IsEnd = c.IsEnd,
                    CreatedAt = c.CreatedAt,
                    UpdatedAt = c.UpdatedAt
                })
                .ToListAsync();
        }

        public async Task<UserCourseViewModel> FindByIdAsync(int id)
        {
            return await _context.UsersCourses.AsNoTracking()
                .Include(c => c.Course)
                .Include(c => c.User)
                .Select(c => new UserCourseViewModel
                {
                    Id = c.Id,
                    CourseId = c.CourseId,
                    CourseName = c.Course.Name,
                    Username = c.Username,
                    IsEnd = c.IsEnd,
                    CreatedAt = c.CreatedAt,
                    UpdatedAt = c.UpdatedAt
                })
                .FirstOrDefaultAsync(usercourse => usercourse.Id == id);
        }

        public async Task<List<UserCourseViewModel>> FindAllByUsernameAsync(string username)
        {
            return await _context.UsersCourses.AsNoTracking()
                .Include(c => c.Course)
                .Include(c => c.User)
                .Select(c => new UserCourseViewModel
                {
                    Id = c.Id,
                    CourseId = c.CourseId,
                    CourseName = c.Course.Name,
                    Username = c.Username,
                    IsEnd = c.IsEnd,
                    CreatedAt = c.CreatedAt,
                    UpdatedAt = c.UpdatedAt
                })
                .Where(user => user.Username == username).ToListAsync();
        }

        public async Task<List<UserCourseViewModel>> FindAllByCourseIdAsync(int courseid)
        {
            return await _context.UsersCourses.AsNoTracking()
                .Include(c => c.Course)
                .Include(c => c.User)
                .Select(c => new UserCourseViewModel
                {
                    Id = c.Id,
                    CourseId = c.CourseId,
                    CourseName = c.Course.Name,
                    Username = c.Username,
                    IsEnd = c.IsEnd,
                    CreatedAt = c.CreatedAt,
                    UpdatedAt = c.UpdatedAt
                })
                .Where(course => course.CourseId == courseid).ToListAsync();
        }

    }
}