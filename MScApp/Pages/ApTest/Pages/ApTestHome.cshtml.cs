using Microsoft.AspNetCore.Mvc.RazorPages;
using MScApp.Core;
using MScApp.Pages.ApTest.Data;
using System.Collections.Generic;

namespace MScApp.Pages.Questions.Pages
{
    public class ApTestHomeModel : PageModel
    {
        public IEnumerable<Question> Questions { get; set; }
        public IApTestData ApTestData { get; set; }
        public string QuestionTypeID { get; set; }
        public Question Question { get; set; }
        public Test Test { get; set; }
        public List<Test> Tests { get; set; }
        public bool TestTaken { get; set; }
            
        public ApTestHomeModel(IApTestData ApTestData)
        {
            this.ApTestData = ApTestData;
        }

        public void OnGet(int QuestionID)
        {
            Tests = ApTestData.GetTestIDForLoggedInAppUser(User.Identity.Name);
            Questions = ApTestData.GetQuestionsAndAnswers(QuestionID);

        }
    }
}
