using Microsoft.EntityFrameworkCore;
using MScApp.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MScApp.Pages.ApTest.Data
{
    public class SqlApTestData : IApTestData
    {
        /// <summary>   The database. </summary>
        private readonly MScAppDbContext db;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Constructor. </summary>
        ///
        /// <param name="db">   The database. </param>
        ///-------------------------------------------------------------------------------------------------
        public SqlApTestData(MScAppDbContext db)
        {
            this.db = db;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets questions and answers. </summary>
        ///
        /// <returns>   The questions and answers as List. </returns>
        ///-------------------------------------------------------------------------------------------------
        public List<Question> GetQuestionsAndAnswers()
        {
            var AllQuestions = db.Questions.Include(q => q.Answers).ToList();
            return AllQuestions;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Saves an answer attempt for each question the applicant answers. </summary>
        ///
        /// <param name="submittedAnswers"> The answers. </param>
        /// <param name="applicant">        The applicant. </param>
        /// <param name="test">             The test. </param>
        ///-------------------------------------------------------------------------------------------------
        public void SaveAnswerAttempt(List<Answer> submittedAnswers, AppUser applicant, Test test)
        {
            var tempAppUser = db.Users.SingleOrDefault(user => user.Email == applicant.Email);

            foreach (var answer in submittedAnswers)
            {
                var tempAnswer = db.Answers.SingleOrDefault(a => a.AnswerBody == answer.AnswerBody);

                AnswerAttempt answerAttempt = new AnswerAttempt
                {
                    AnswerID = tempAnswer.ID,
                    Applicant = tempAppUser,
                    ApplicantID = tempAppUser.Id,
                    Test = test
                };

                db.AnswerAttempts.Add(answerAttempt);
            }
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets questions by question type identifier. </summary>
        ///
        /// <param name="questionTypeID">   Identifier for the question type. </param>
        ///
        /// <returns>   The questions by question type identifier as a List. </returns>
        ///-------------------------------------------------------------------------------------------------
        public List<Question> GetQuestionsByQuestionTypeID(QuestionTypeID questionTypeID)
        {
            var AllQuestions = db.Questions.Include(q => q.Answers).ToList();
            var QuestionsByQuestionType = AllQuestions.FindAll(q => q.QuestionTypeID.Equals(questionTypeID));
            return QuestionsByQuestionType;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Adds a test to db. </summary>
        ///
        ///  <param name="newTest"> The test to be added. </param>
        ///
        /// <returns>   Test that was added. </returns>
        ///-------------------------------------------------------------------------------------------------
        public Test AddTest(Test newTest)
        {
            db.Tests.Add(newTest);
            return newTest;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets all the tests in the db. </summary>
        ///
        ///  <returns>   The tests as List </returns>
        ///-------------------------------------------------------------------------------------------------
        public List<Test> GetTests()
        {
            return db.Tests.ToList();
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets test by identifier. </summary>
        ///
        /// <param name="testID">   Identifier for the test. </param>
        ///
        /// <returns>   The test by identifier. </returns>
        ///-------------------------------------------------------------------------------------------------
        public Test GetTestByID(int? testID)
        {
            var test = db.Tests.SingleOrDefault(t => t.ID == testID);
            return test;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Updates the test described by updatedTest. </summary>
        ///
        /// <param name="updatedTest">  The updated test. </param>
        ///
        /// <returns>  The updatedTest as it is held in the db  </returns>
        ///-------------------------------------------------------------------------------------------------
        public Test UpdateTest(Test updatedTest)
        {
            var state = db.Entry(updatedTest).State;
            var testInDb = db.Tests.SingleOrDefault(t => t.ID == updatedTest.ID);

            testInDb.ID = updatedTest.ID;
            testInDb.TestName = updatedTest.TestName;
            testInDb.Date = updatedTest.Date;
            testInDb.Time = updatedTest.Time;
            testInDb.IsDisabled = updatedTest.IsDisabled;

            state = EntityState.Modified;
            return testInDb;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Deletes the test described by TestID. </summary>
        ///
        ///  <param name="TestID">   Identifier for the test. </param>
        ///-------------------------------------------------------------------------------------------------
        public void DeleteTest(int TestID)
        {
            var test = db.Tests.SingleOrDefault(t => t.ID == TestID);
            test.IsDeleted = true;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Gets question IDs from checkboxes as strings then parses them to ints. Get all questions in db
        ///     that match the parsed IDs.
        /// </summary>
        ///
        /// <param name="questionCheckboxes">   The question IDs in string form to be parsed. </param>
        ///
        /// <returns>   List of Questions that corresponds to parsed IDs. </returns>
        ///-------------------------------------------------------------------------------------------------
        public List<Question> GetAndParseQuestions(string[] questionCheckboxes)
        {
            List<Question> questionList = new List<Question>();

            foreach (var ID in questionCheckboxes)
            {
                questionList.Add(db.Questions.SingleOrDefault(q => q.ID == Int32.Parse(ID)));
            }
            return questionList;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Adds parsed questions IDs to a Test. </summary>
        ///
        /// <param name="test">                 The test. </param>
        /// <param name="questionCheckboxes">   The question IDs in string form to be parsed first. </param>
        ///-------------------------------------------------------------------------------------------------
        public void AddQuestionsToTest(Test test, string[] questionCheckboxes)
        {
            var questionList = GetAndParseQuestions(questionCheckboxes);

            for (int i = 0; i < questionList.Count(); i++)
            {
                QuestionTest questionTest = new QuestionTest()
                {
                    Test = test,
                    QuestionID = questionList[i].ID
                };

                db.QuestionTests.Add(questionTest);
            }
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Updates the test questions. </summary>
        ///
        /// <param name="test">                 The test. </param>
        /// <param name="questionCheckboxes">   The question IDs in string form to be parsed first. </param>
        ///
        /// <returns>   The Test that was updated. </returns>
        ///-------------------------------------------------------------------------------------------------
        public Test UpdateTestQuestions(Test test, string[] questionCheckboxes)
        {
            var questionList = GetAndParseQuestions(questionCheckboxes);
            var testsInDb = db.QuestionTests.ToList().FindAll(t => t.TestID == test.ID);

            if (testsInDb.Count() != 0)
            {
                for (int i = 0; i < testsInDb.Count(); i++)
                {
                    db.QuestionTests.Remove(testsInDb[i]);
                }

            }
            for (int i = 0; i < questionList.Count(); i++)
            {
                db.QuestionTests.Add(new QuestionTest()
                {
                    QuestionID = questionList[i].ID,
                    TestID = test.ID
                });
            }

            return test;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Commits all changes made to the db </summary>
        ///
        /// <returns>   An int. </returns>
        ///-------------------------------------------------------------------------------------------------
        public int Commit()
        {
            return db.SaveChanges();
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets all data from QuestionTests table by test identifier. </summary>
        ///
        /// <param name="TestID">   Identifier for the test. </param>
        ///
        /// <returns>   The test questions to List. </returns>
        ///-------------------------------------------------------------------------------------------------
        public List<QuestionTest> GetTestQuestions(int? TestID)
        {
            return db.QuestionTests.ToList().FindAll(t => t.TestID == TestID);
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Query if Question is assigned to Test. </summary>
        ///
        /// <param name="QuestionID">   Identifier for the question. </param>
        /// <param name="TestID">       Identifier for the test. </param>
        ///
        /// <returns>   True if question is assigned to test, false if not. </returns>
        ///-------------------------------------------------------------------------------------------------
        public bool IsQuestionOnTest(int QuestionID, int TestID)
        {
            var questionTestList = db.QuestionTests.ToList().FindAll(t => t.TestID == TestID && t.QuestionID == QuestionID);

            return questionTestList.Count > 0;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets all AppUsers from table. </summary>
        ///
        /// <returns>   All AppUsers as List. </returns>
        ///-------------------------------------------------------------------------------------------------
        public List<AppUser> GetAllAppUsers()
        {
            return db.Users.ToList();
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Adds applicants to a test. </summary>
        ///
        /// <param name="test">         The test. </param>
        /// <param name="applicantCheckboxes">   The applicants' IDs in string form. </param>
        ///
        /// <returns>  The test applicants were added to. </returns>
        ///-------------------------------------------------------------------------------------------------
        public Test AddApplicantsToTest(Test test, string[] applicantCheckboxes)
        {
            for (int i = 0; i < applicantCheckboxes.Length; i++)
            {
                AppUserTest userTest = new AppUserTest()
                {
                    TestID = test.ID,
                    AppUserID = applicantCheckboxes[i]
                };

                db.AppUserTests.Add(userTest);
            }
            return test;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Query if applicant is assigned to test. </summary>
        /// 
        /// <param name="applicantID">  Identifier for applicant. </param>
        /// <param name="TestID">       Identifier for the test. </param>
        ///
        /// <returns>   True if applicant is assigned to test, false if not. </returns>
        ///-------------------------------------------------------------------------------------------------
        public bool IsApplicantAssignedToTest(string applicantID, int TestID)
        {
            var userTestList = db.AppUserTests.ToList().FindAll(t => t.TestID == TestID && t.AppUserID == applicantID);

            return userTestList.Count > 0;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Updates the applicants assigned to a test. </summary>
        ///
        /// <param name="test">         The test. </param>
        /// <param name="applicantCheckboxes">   The applicants' IDs in string form. </param>
        ///
        /// <returns>  Test which had applicants updated. </returns>
        ///-------------------------------------------------------------------------------------------------
        public Test UpdateApplicantsAssignedToTest(Test test, string[] applicantCheckboxes)
        {
            var testsInDb = db.AppUserTests.ToList().FindAll(t => t.TestID == test.ID);

            if (testsInDb.Count() != 0)
            {
                for (int i = 0; i < testsInDb.Count(); i++)
                {
                    db.AppUserTests.Remove(testsInDb[i]);
                }
            }

            for (int i = 0; i < applicantCheckboxes.Length; i++)
            {
                db.AppUserTests.Add(new AppUserTest()
                {
                    AppUserID = applicantCheckboxes[i],
                    TestID = test.ID
                });
            }

            return test;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets all applicants assigned to a test. </summary>
        ///
        /// <param name="TestID">   Identifier for the test. </param>
        ///
        /// <returns>   The applicants assigned to test as List. </returns>
        ///-------------------------------------------------------------------------------------------------
        public List<AppUserTest> GetApplicantsAssignedToTestByID(int? TestID)
        {
            return db.AppUserTests.ToList().FindAll(t => t.TestID == TestID);
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets test identifier that logged in applicant is assigned to. </summary>
        ///
        /// <remarks>   Grainne, 25/09/2020. </remarks>
        ///
        /// <param name="applicantEmail">    The email address for logged in applicant. </param>
        ///
        /// <returns>   List of tests that logged in applicant is assigned to. </returns>
        ///-------------------------------------------------------------------------------------------------
        public List<Test> GetTestIDForLoggedInApplicant(string applicantEmail)
        {
            var loggedInUser = db.Users.SingleOrDefault(u => u.Email == applicantEmail);

            var appUserTest = db.AppUserTests.ToList().FindAll(t => t.AppUserID == loggedInUser.Id);
            List<Test> testsForUser = new List<Test>();

            for (int i = 0; i < appUserTest.Count(); i++)
            {
                testsForUser.Add(db.Tests.SingleOrDefault(t => t.ID == appUserTest[i].TestID));
            }

            return testsForUser;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets question list for test by question type. </summary>
        ///
        /// <param name="TestID">           Identifier for the test. </param>
        /// <param name="questionTypeID">   Identifier for the question type. </param>
        ///
        /// <returns>   The question list for test by question type. </returns>
        ///-------------------------------------------------------------------------------------------------
        public List<Question> GetQuestionListForTestByQuestionType(int TestID, QuestionTypeID questionTypeID)
        {
            List<Question> testQuestions = new List<Question>();
            var tempQs = GetTestQuestions(TestID);

            for (int i = 0; i < tempQs.Count; i++)
            {
                testQuestions.Add(db.Questions.Include(a => a.Answers).SingleOrDefault(q => q.ID == tempQs[i].QuestionID));
            }
            return testQuestions.FindAll(q => q.QuestionTypeID == questionTypeID);

        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Calculates the correct answers. </summary>
        ///
        /// <param name="submittedAnswers"> The submitted answers. </param>
        /// <param name="applicant">        The applicant. </param>
        /// <param name="questionTypeID">   Identifier for the question type. </param>
        /// <param name="questionCount">    Number of questions. </param>
        /// <param name="test">             The test. </param>
        ///
        /// <returns>   A double value to serve as % score for that test section. </returns>
        ///-------------------------------------------------------------------------------------------------
        public double CalculateCorrectAnswers(List<Answer> submittedAnswers, AppUser applicant, QuestionTypeID questionTypeID, int questionCount, Test test)
        {
            int correctAnswers = 0;
            var answerBank = db.Answers.ToList();
            var tempAppUser = db.Users.SingleOrDefault(user => user.Email == applicant.Email);

            foreach (var submitedA in submittedAnswers)
            {
                var tempAnswer = answerBank.SingleOrDefault(a => a.AnswerBody == submitedA.AnswerBody);
                if (tempAnswer.IsCorrect)
                {
                    correctAnswers++;
                }
            }
            return (double)correctAnswers / (double)questionCount * 100;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Saves a test result and calculates if the test is a pass or fail. </summary>
        ///
        /// <param name="sectionResults">   The section results. </param>
        /// <param name="testID">           Identifier for the test. </param>
        /// <param name="applicant">        The applicant. </param>
        ///-------------------------------------------------------------------------------------------------
        public void SaveTestResults(List<double> sectionResults, int testID, AppUser applicant)
        {
            var tempAppUser = db.Users.SingleOrDefault(user => user.Email == applicant.Email);

            bool testPass = false;
            int sectionPassCount = 0;
            for (int i = 0; i < sectionResults.Count(); i++)
            {
                if (sectionResults[i] >= 50) { sectionPassCount++; }
            }
            if (sectionPassCount == 3) { testPass = true; }

            TestAttempt testAttempt = new TestAttempt()
            {
                AppUserID = tempAppUser.Id,
                TestID = testID,
                Section1Result = sectionResults.ElementAt(0),
                Section2Result = sectionResults.ElementAt(1),
                Section3Result = sectionResults.ElementAt(2),
                IsPass = testPass

            };
            db.TestAttempts.Add(testAttempt);
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets all test attempts. </summary>
        ///
        /// <returns>   The test attempts as List. </returns>
        ///-------------------------------------------------------------------------------------------------
        public List<TestAttempt> GetTestAttempts()
        {
            return db.TestAttempts.ToList();
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Adds new applicants to db. </summary>
        ///
        /// <param name="appUserList">  List of applicants to be created. </param>
        ///-------------------------------------------------------------------------------------------------
        public void AddNewApplicant(List<AppUser> appUserList)
        {
            foreach (var user in appUserList)
            {
                db.Users.Add(user);
            }
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Checks if applicant has already submitted results for test. </summary>
        ///
        /// <param name="applicantEmail">   The email of logged in applicant. </param>
        /// <param name="testID">           Identifier for the test. </param>
        ///
        /// <returns name="TestAlreadyTaken">   True if it succeeds, false if it fails. </returns>
        ///-------------------------------------------------------------------------------------------------
        public bool CheckIfApplicantHasSubmittedTestAttempt(string applicantEmail, int testID)
        {
            bool TestAlreadyTaken = false;
            var signedInUser = db.Users.SingleOrDefault(u => u.Email == applicantEmail);

            var allTestAttempts = GetTestAttempts();

            for (int i = 0; i < allTestAttempts.Count(); i++)
            {
                if (allTestAttempts[i].AppUserID.Equals(signedInUser.Id) && allTestAttempts[i].TestID == testID)
                {
                    TestAlreadyTaken = true;
                }
            }
            return TestAlreadyTaken;
        }
    }
}



