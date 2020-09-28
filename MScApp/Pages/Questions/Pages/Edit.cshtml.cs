using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MScApp.Core;
using System.Collections.Generic;

namespace MScApp.Pages.Questions
{
    [Authorize(Policy = "IsAdmin")]
    public class EditModel : PageModel
    {
        public bool newQuestion;
        private readonly IQuestionData questionData;
        private readonly IHtmlHelper htmlHelper;

        [BindProperty]
        public Question Question { get; set; }
        [BindProperty]
        public Answer Answer { get; set; }
        public IEnumerable<SelectListItem> QuestionTypes { get; set; }
        [TempData]
        public string Message { get; set; }


        public EditModel(IQuestionData questionData, IHtmlHelper htmlHelper)
        {
            this.questionData = questionData;
            this.htmlHelper = htmlHelper;
        }


        public IActionResult OnGet(int? questionID)
        {

            QuestionTypes = htmlHelper.GetEnumSelectList<QuestionTypeID>();

            if (questionID.HasValue)
            {
                Question = questionData.GetByQuestionID(questionID.Value);

            }
            else
            {
                Question = new Question();
                Question.Answers.Add(new Answer());
                Question.Answers.Add(new Answer());
                Question.Answers.Add(new Answer());
                Question.Answers.Add(new Answer());

                newQuestion = true;
            }

            if (Question == null)
            {
                return RedirectToPage("./List");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                QuestionTypes = htmlHelper.GetEnumSelectList<QuestionTypeID>();
                return Page();
            }


            if (Question.ID > 0)
            {
                questionData.UpdateQuestion(Question);
                TempData["Message"] = "Question has been successfully updated";
            }
            else
            {
                questionData.AddQuestion(Question);
                TempData["Message"] = "Question has been successfully created";
            }

            questionData.Commit();

            return RedirectToPage("./Detail", new { QuestionID = Question.ID });
        }
    }
}