using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MScApp.Core;

namespace MScApp.Pages.Questions
{
    [Authorize(Policy = "IsAdmin")]
    public class DetailModel : PageModel
    {
        private readonly IQuestionData QuestionData;
        public Question Question { get; set; }


        public DetailModel(IQuestionData QuestionData)
        {
            this.QuestionData = QuestionData;
        }

        public IActionResult OnGet(int questionID)
        {
            Question = QuestionData.GetByQuestionID(questionID);
            Question.QuestionBody = Question.QuestionBody.Replace("\n", "<br>");

            if (Question == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}