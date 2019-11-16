using SampleAPI.Domain.Models;
using SampleAPI.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPI.Infrastructure.Repositories
{
    public class UserCourseRepository : IUserCourseRepository
    {
        protected readonly ApplicationDbContext _context;

        public UserCourseRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task CreateUserCourseAsync(UserCourse usercourse)
        {
            _context.UsersCourses.Add(usercourse);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRatingUserCourseAsync(UserCourse usercourse)
        {
            _context.UsersCourses.Update(usercourse);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserCourseAsync(UserCourse usercourse)
        {
            _context.UsersCourses.Remove(usercourse);
            await _context.SaveChangesAsync();
        }
    }
}
