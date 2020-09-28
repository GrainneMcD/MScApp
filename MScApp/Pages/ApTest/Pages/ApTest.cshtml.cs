using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using MScApp.Core;
using MScApp.Pages.ApTest.Data;
using System;
using System.Collections.Generic;

namespace MScApp.Pages.Questions.Pages
{
    public class ApTestModel : PageModel
    {
        public IApTestData ApTestData { get; set; }

        [BindProperty]
        public List<Question> Questions { get; set; }
        [BindProperty]
        public Question Question { get; set; }
        public Test Test { get; set; }

        public int TimeLimitInMinutes = 15;
        public string SectionTimeUpMessage = "Your time for this section is up. All selected results will be submitted";

        public string TestCategoryTitle { get; set; }
        public int QuestionID { get; set; }

        [BindProperty]
        public List<Answer> Answers { get; set; }
        [BindProperty]
        public Answer Answer { get; set; }

        public List<double> Results { get; set; }


        public ApTestModel(IApTestData ApTestData)
        {
            this.ApTestData = ApTestData;
        }


        public void OnGet(QuestionTypeID QuestionTypeID, int TestID)
        {
            Questions = ApTestData.GetQuestionListForTestByQuestionType(TestID, QuestionTypeID);
            Test = ApTestData.GetTestByID(TestID);
            this.TestCategoryTitle = QuestionTypeID.GetTestCategoryTitle();

        }

        public IActionResult OnPost(List<Answer> answers, QuestionTypeID QuestionTypeID, int TestID)
        {
            Results = new List<double>();

            Test = ApTestData.GetTestByID(TestID);
            AppUser appUser = new AppUser
            {
                Email = User.Identity.Name,
            };
            ApTestData.SaveAnswerAttempt(answers, appUser, Test);

            if (answers.Count > 0)
            {
                ApTestData.Commit();
            }

            switch (QuestionTypeID)
            {
                case QuestionTypeID.Written_and_Verbal_Reasoning:
                    {
                        TempData["Section1ResultString"] = ApTestData.CalculateCorrectAnswers(answers, appUser, QuestionTypeID, Questions.Count, Test).ToString();

                        return RedirectToPage("./TestSectionHome/", new { TestID, QuestionTypeID = QuestionTypeID.Diagrammatic_Reasoning });
                    }

                case QuestionTypeID.Diagrammatic_Reasoning:
                    {
                        TempData["Section2ResultString"] = ApTestData.CalculateCorrectAnswers(answers, appUser, QuestionTypeID, Questions.Count, Test).ToString();

                        return RedirectToPage("./TestSectionHome/", new { TestID, QuestionTypeID = QuestionTypeID.Symbolic_Manipulation });
                    }

                case QuestionTypeID.Symbolic_Manipulation:
                    {
                        TempData["Section3ResultString"] = ApTestData.CalculateCorrectAnswers(answers, appUser, QuestionTypeID, Questions.Count, Test).ToString();
                        Results.Add(Double.Parse(TempData["Section1ResultString"].ToString()));
                        Results.Add(Double.Parse(TempData["Section2ResultString"].ToString()));
                        Results.Add(Double.Parse(TempData["Section3ResultString"].ToString()));

                        ApTestData.SaveTestResults(Results, TestID, appUser);
                        ApTestData.Commit();

                        return RedirectToPage("./TestComplete/");

                    }
                default:
                    {
                        return Page();
                    }

            }


        }
    }
}
