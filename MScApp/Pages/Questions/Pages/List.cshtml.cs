using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using MScApp.Core;
using System.Collections.Generic;

namespace MScApp.Pages.Questions
{
    [Authorize(Policy = "IsAdmin")]
    public class ListModel : PageModel
    {

        private readonly IConfiguration config;

        public IEnumerable<Question> Questions { get; set; }
        public IQuestionData QuestionData { get; }
        public int QuestionID { get; set; }

        public ListModel(IConfiguration config, IQuestionData QuestionData)
        {
            this.config = config;
            this.QuestionData = QuestionData;
        }

        public void OnGet()
        {
            Questions = QuestionData.GetQuestionsAndAnswers(QuestionID);
        }
    }
}