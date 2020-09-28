using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MScApp.Core;
using System.Collections.Generic;

namespace MScApp.Pages.Questions
{
    [Authorize(Policy = "IsAdmin")]
    public class ListModel : PageModel
    {
        public IQuestionData QuestionData { get; }
        public IEnumerable<Question> Questions { get; set; }

        public ListModel(IQuestionData QuestionData)
        {
            this.QuestionData = QuestionData;
        }

        public void OnGet()
        {
            Questions = QuestionData.GetQuestionsAndAnswers();
            foreach (var q in Questions)
            {
                q.QuestionBody = q.QuestionBody.Replace("\n", "<br>");
            }
        }
    }
}