using System;
using System.Collections.Generic;

namespace QuizOnlineWeb.DTO
{

	public partial class UserDTO
	{
		public int UserId { get; set; }

		public string? Username { get; set; }

		public string? Password { get; set; }

		public string? FirstName { get; set; }

		public string? LastName { get; set; }

		public int Role { get; set; }

	}
	public class LoginUserDTO
	{
		public string username { get; set;}
		public string password { get; set;}
	}
}