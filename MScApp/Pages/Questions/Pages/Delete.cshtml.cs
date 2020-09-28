using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MScApp.Core;

namespace MScApp.Pages.Questions
{
    [Authorize(Policy = "IsAdmin")]
    public class DeleteModel : PageModel
    {
        private readonly IQuestionData questionData;
        public Question Question { get; set; }

        public DeleteModel(IQuestionData questionData)
        {
            this.questionData = questionData;
        }

        public IActionResult OnGet(int questionID)
        {
            Question = questionData.GetByQuestionID(questionID);
            Question.QuestionBody = Question.QuestionBody.Replace("\n", "<br>");

            if (Question == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost(int questionID)
        {
            questionData.DeleteQuestion(questionID);
            questionData.Commit();
            TempData["Message"] = "Question has successfully been deleted";

            return RedirectToPage("./List");
        }
    }
}