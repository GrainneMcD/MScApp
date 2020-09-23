using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MScApp.Core;
using MScApp.Pages.ApTest.Data;
using System.Collections.Generic;
using System.Linq;

namespace MScApp.Pages.ApTest.Pages
{
    [Authorize(Policy = "IsAdmin")]
    public class TestEditModel : PageModel
    {
        private readonly IApTestData apTestData;
        public bool newTest;

        [BindProperty]
        public Test Test { get; set; }
        public List<QuestionTest> QuestionTests { get; private set; }
        public QuestionTest QuestionTest { get; set; }

        public List<Question> Questions { get; set; }
        public int UsersAssignedToTest { get; private set; }

        [TempData]
        public string Message { get; set; }

        public TestEditModel(IApTestData apTestData)
        {
            this.apTestData = apTestData;
        }

        public IActionResult OnGet(int? TestID, int questionID)
        {
            Questions = apTestData.GetQuestionsAndAnswers(questionID);
            UsersAssignedToTest = apTestData.GetTestUsers(TestID).Count();

            if (TestID.HasValue)
            {
                Test = apTestData.GetTestByID(TestID.Value);
            }
            else
            {
                Test = new Test();

                newTest = true;
            }

            if (Test == null)
            {
                return RedirectToPage("./TestList");
            }
            return Page();
        }

        public IActionResult OnPost(string[] checkboxes)
        {
            if (Test.ID > 0)
            {
                apTestData.UpdateTest(Test);
                apTestData.UpdateTestQuestions(Test, checkboxes);
                TempData["Message"] = "Test has been created";
            }
            else
            {
                var CreatedTest = apTestData.AddTest(Test);
                apTestData.Commit();

                apTestData.AddQuestionsToTest(CreatedTest, checkboxes);
                TempData["Message"] = "Test has been updated";
            }

            apTestData.Commit();

            return RedirectToPage("./TestDetail", new { TestID = Test.ID });
        }

        public bool IsQuestionOnTest(int QuestionID, int TestID)
        {
            return apTestData.IsQuestionOnTest(QuestionID, TestID);
        }
    }
}
