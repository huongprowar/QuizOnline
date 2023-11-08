using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PRN231_Project_QuizOnline_Web.Models;
using System.Security.Claims;

namespace PRN231_Project_QuizOnline_Web.Controllers
{
	public class LoginController : Controller
	{
		protected static string URL_LOGIN = "http://localhost:5177/api/User/Login";
		public IActionResult Index()
		{
			return View();
		}
		
	}
}
