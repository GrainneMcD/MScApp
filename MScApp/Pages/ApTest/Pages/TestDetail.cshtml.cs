using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MScApp.Core;
using MScApp.Pages.ApTest.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MScApp.Pages.ApTest.Pages
{
    [Authorize(Policy = "IsAdmin")]
    public class TestDetailModel : PageModel
    {
        readonly IApTestData apTestData;
        readonly IQuestionData questionData;

        [BindProperty]
        public Test Test { get; set; }
        public List<QuestionTest> QuestionTests { get; set; }
        public QuestionTest QuestionTest { get; set; }
        public List<Question> QuestionsInTest { get; set; }
        public int ApplicantsOnTestCount { get; set; }
        public List<AppUserTest> ApplicantsOnTest { get; set; }
        [TempData]
        public string Message { get; set; }


        public TestDetailModel(IApTestData apTestData, IQuestionData questionData)
        {
            this.apTestData = apTestData;
            this.questionData = questionData;
        }

        public void OnGet(int TestID)
        {
            QuestionsInTest = new List<Question>();

            Test = apTestData.GetTestByID(TestID);
            QuestionTests = apTestData.GetTestQuestions(TestID);


            for (int i = 0; i < QuestionTests.Count(); i++)
            {
                QuestionsInTest.Add(questionData.GetByQuestionID(QuestionTests[i].QuestionID));
            }

            foreach (var q in QuestionsInTest)
            { q.QuestionBody = q.QuestionBody.Replace("\n", "<br>"); }

            ApplicantsOnTest = apTestData.GetApplicantsAssignedToTestByID(TestID);
            ApplicantsOnTestCount = ApplicantsOnTest.Count();

        }

        public FileContentResult OnPost(int TestID)
        {
            ApplicantsOnTest = apTestData.GetApplicantsAssignedToTestByID(TestID);
            return ExportTestReminderToCSV(ApplicantsOnTest);
        }

        public FileContentResult ExportTestReminderToCSV(List<AppUserTest> ApplicantsOnTest)
        {

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("ApplicantID,FirstName,LastName,Email,TestName,TestDay,TestDate,TestTime,\n");

            foreach (var AppTest in ApplicantsOnTest)
            {
                AppTest.AppUser = apTestData.GetAppUserByID(AppTest.AppUserID);
                AppTest.Test = apTestData.GetTestByID(AppTest.TestID);

                stringBuilder.Append(AppTest.AppUserID + ",");
                stringBuilder.Append(AppTest.AppUser.FirstName + ",");
                stringBuilder.Append(AppTest.AppUser.LastName + ",");
                stringBuilder.Append(AppTest.AppUser.Email + ",");
                stringBuilder.Append(AppTest.Test.TestName + ",");
                stringBuilder.Append(AppTest.Test.Date.ToString("dddd") + ",");
                stringBuilder.Append(AppTest.Test.Date.ToString("dd MMMM yyyy") + ",");
                stringBuilder.Append(AppTest.Test.Time.ToString("hh: mm tt") + "\n");
            }

            return File(Encoding.UTF8.GetBytes(stringBuilder.ToString()), "text/csv", "TestReminder.csv");
        }
    }
}
