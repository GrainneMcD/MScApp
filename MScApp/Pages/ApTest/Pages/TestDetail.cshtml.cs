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
    public class TestDetailModel : PageModel
    {
        readonly IApTestData apTestData;
        readonly IQuestionData questionData;

        [BindProperty]
        public Test Test { get; set; }
        public List<QuestionTest> QuestionTests { get; set; }
        public QuestionTest QuestionTest { get; set; }
        public List<Question> QuestionsInTest { get; set; }
        public int ApplicantsOnTest { get; set; }
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

            ApplicantsOnTest = apTestData.GetApplicantsAssignedToTestByID(TestID).Count();

        }
    }
}
