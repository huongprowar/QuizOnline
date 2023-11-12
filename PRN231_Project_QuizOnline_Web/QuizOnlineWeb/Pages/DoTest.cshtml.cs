using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using QuizOnlineWeb.DTO;

namespace QuizOnlineWeb.Pages
{
    public class DoTestModel : PageModel
    {
		static string URL_SUBMITTEST = "http://localhost:5177/submit/";
        public List<ResponseQuestionDTO> questionDTOs { get; set; } = new List<ResponseQuestionDTO> {};
        [BindProperty]
        public List<string> Answers { get;set; }
		[BindProperty]
		public string TestCode { get; set; }
		public async Task<IActionResult> OnGetAsync(List<ResponseQuestionDTO> listQuestion)
        {
            //questionDTOs = TempData["listQuestion"];
            var data = TempData["listQuestion"] as string;
			TestCode = TempData["TestCode"] as string;
			questionDTOs = JsonConvert.DeserializeObject<List<ResponseQuestionDTO>>(data);

			return Page();
        }        
        public async Task<IActionResult> OnPostSubmitTest()
        {
			List<RequestAnswerDTO> listQuestion = new List<RequestAnswerDTO>();
			foreach(var answer in Answers)
			{
				string[] answerArr = answer.Split("+");
				RequestAnswerDTO answerDTO = listQuestion.FirstOrDefault(x => x.QuestionId == Convert.ToInt32(answerArr[0]));
				if(answerDTO != null)
				{
					answerDTO.ListAnswerId.Add(Convert.ToInt32(answerArr[1]));
					continue;
				}
				else
				{
					answerDTO = new RequestAnswerDTO()
					{
						QuestionId = Convert.ToInt32(answerArr[0]),
						ListAnswerId = new List<int>() { int.Parse(answerArr[1]) }
					};
					listQuestion.Add(answerDTO);
				}

			}

			using (HttpClient client = new HttpClient())
			{
                int id = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
                var url = URL_SUBMITTEST + TestCode + $"?userId={id}";
				using (HttpResponseMessage res = await client.PostAsJsonAsync(url, listQuestion))
				{
					using (HttpContent content = res.Content)
					{
						string data = content.ReadAsStringAsync().Result;

						int resultId = JsonConvert.DeserializeObject<int>(data);

						return Redirect($"/ResultDetail?ResultID={resultId}");
					}
					//return new RedirectToPageResult("DoTest", listQuestion);
				}
			}
			
		}
    }
}
