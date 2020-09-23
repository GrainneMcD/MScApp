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

            if (Question == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost(int questionID)
        {
            Question = questionData.DeleteQuestion(questionID);
            questionData.Commit();

            if (Question == null)
            {
                return RedirectToPage("./NotFound");
            }
            TempData["Message"] = $"Question Number :{Question.ID} deleted";
            return RedirectToPage("./List");
        }
    }
}