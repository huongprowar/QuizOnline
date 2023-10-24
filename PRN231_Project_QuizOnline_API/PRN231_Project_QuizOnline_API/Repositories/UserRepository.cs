using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PRN231_Project_QuizOnline_API.Models;
using Repositories.Base;
using System.Collections.ObjectModel;

namespace PRN231_Project_QuizOnline_API.Repositories
{
	public class UserRepository 
	{
		private readonly QuizOnlineContext _context;
		public UserRepository()
		{
			_context = new QuizOnlineContext();
		}
		public async Task<User> Login(string username, string password)
		{
			return await _context.Users.FirstOrDefaultAsync(x => x.Username.Equals(username) && x.Password.Equals(password));
		}
		public async Task<User> Register(string username, string password, string firstName, string lastName)
		{
			User user = await _context.Users.FirstOrDefaultAsync(x => x.Username.Equals(username));
			if (user != null)
			{
				return null;
			}
			User newUser = new User()
			{
				Username = username,
				Password = password,
				FirstName = firstName,
				LastName = lastName,
				Role=1
			};
			_context.Users.Add(newUser);
			_context.SaveChangesAsync();
			return newUser;
		}

	}
}
