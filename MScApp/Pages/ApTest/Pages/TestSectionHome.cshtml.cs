using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MScApp.Core;
using MScApp.Pages.ApTest.Data;
using System.Collections.Generic;

namespace MScApp.Pages.ApTest.Pages
{
    public class TestSectionHomeModel : PageModel
    {
        public IApTestData ApTestData { get; set; }

        [BindProperty]
        public QuestionTypeID QuestionTypeID { get; set; }
        public string TestCategoryTitle { get; set; }
        public Test Test { get; set; }
        public int TestID { get; set; }
        public List<double> Results { get; set; }

        public TestSectionHomeModel(IApTestData ApTestData)
        {
            this.ApTestData = ApTestData;
        }
        public void OnGet(QuestionTypeID QuestionTypeID, int TestID)
        {

            Test = ApTestData.GetTestByID(TestID);
            this.QuestionTypeID = QuestionTypeID;
            this.TestCategoryTitle = QuestionTypeID.GetTestCategoryTitle();

        }

        public IActionResult OnPost(QuestionTypeID QuestionTypeID)
        {

            switch (QuestionTypeID)
            {
                case QuestionTypeID.Written_and_Verbal_Reasoning:
                    {
                        return RedirectToPage("./ApTest/", new
                        {
                            TestID,
                            QuestionTypeID = QuestionTypeID.Diagrammatic_Reasoning
                        });
                    }

                case QuestionTypeID.Diagrammatic_Reasoning:
                    {
                        return RedirectToPage("./ApTest/", new
                        {
                            TestID,
                            QuestionTypeID = QuestionTypeID.Symbolic_Manipulation
                        });
                    }

                default:
                    {
                        return Page();
                    }

            }


        }
    }
}
