using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PRN231_Project_QuizOnline_API.Models;

namespace PRN231_Project_QuizOnline_API.Repositories
{
	public class CourseRepository 
	{
		private readonly QuizOnlineContext _context;
        public CourseRepository()
        {
            _context = new QuizOnlineContext();
        }
        public async Task<List<Course>> GetAllCourseAsync()
        {
            return await _context.Courses.ToListAsync();
        }
    }
}
