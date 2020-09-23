using Microsoft.EntityFrameworkCore;
using MScApp.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MScApp.Pages.ApTest.Data
{
    public class SqlApTestData : IApTestData
    {
        private readonly MScAppDbContext db;

        public SqlApTestData(MScAppDbContext db)
        {
            this.db = db;
        }


        public List<Question> GetQuestionsAndAnswers(int questionID)
        {
            var AllQuestions = db.Questions.Include(q => q.Answers).ToList();
            return AllQuestions;
        }


        public void SaveAnswerAttempt(List<Answer> answers, AppUser appUser, Test test)
        {
            var tempAppUser = db.Users.SingleOrDefault(user => user.Email == appUser.Email);
            foreach (var answer in answers)
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


        public List<Question> GetQuestionsByQuestionTypeID(QuestionTypeID questionTypeID)
        {
            var AllQuestions = db.Questions.Include(q => q.Answers).ToList();
            var QuestionsByQuestionType = AllQuestions.FindAll(q => q.QuestionTypeID.Equals(questionTypeID));
            return QuestionsByQuestionType;
        }

        public Test AddTest(Test test)
        {
            db.Tests.Add(test);
            return test;
        }


        public List<Test> GetTests()
        {
            return db.Tests.ToList();
        }


        public Test GetTestByID(int? testID)
        {
            var test = db.Tests.SingleOrDefault(t => t.ID == testID);
            return test;
        }


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


        public Test DeleteTest(int TestID)
        {
            var test = db.Tests.SingleOrDefault(t => t.ID == TestID);
            test.IsDeleted = true;
            return test;
        }


        public void AddQuestionsToTest(Test test, string[] checkboxes)
        {
            var questionList = GetAndParseQuestions(checkboxes);

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


        public List<Question> GetAndParseQuestions(string[] checkboxes)
        {
            List<Question> questionList = new List<Question>();

            foreach (var ID in checkboxes)
            {
                questionList.Add(db.Questions.SingleOrDefault(q => q.ID == Int32.Parse(ID)));
            }
            return questionList;
        }


        public Test UpdateTestQuestions(Test test, string[] checkboxes)
        {
            var questionList = GetAndParseQuestions(checkboxes);
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


        public int Commit()
        {
            return db.SaveChanges();
        }

        public List<QuestionTest> GetTestQuestions(int? TestID)
        {
            return db.QuestionTests.ToList().FindAll(t => t.TestID == TestID);
        }

        public bool IsQuestionOnTest(int QuestionID, int TestID)
        {
            var questionTestList = db.QuestionTests.ToList().FindAll(t => t.TestID == TestID && t.QuestionID == QuestionID);

            return questionTestList.Count > 0;
        }

        public List<AppUser> GetAllUsers()
        {
            return db.Users.ToList();
        }

        public Test AddUsersToTest(Test test, string[] checkboxes)
        {
            for (int i = 0; i < checkboxes.Length; i++)
            {
                AppUserTest userTest = new AppUserTest()
                {
                    TestID = test.ID,
                    AppUserID = checkboxes[i]
                };

                db.AppUserTests.Add(userTest);
            }
            return test;
        }

        public bool IsUserAssignedToTest(string UserID, int TestID)
        {
            var userTestList = db.AppUserTests.ToList().FindAll(t => t.TestID == TestID && t.AppUserID == UserID);

            return userTestList.Count > 0;
        }

        public Test UpdateUsersOnTest(Test test, string[] checkboxes)
        {
            var testsInDb = db.AppUserTests.ToList().FindAll(t => t.TestID == test.ID);

            if (testsInDb.Count() != 0)
            {
                for (int i = 0; i < testsInDb.Count(); i++)
                {
                    db.AppUserTests.Remove(testsInDb[i]);
                }

            }

            for (int i = 0; i < checkboxes.Length; i++)
            {
                db.AppUserTests.Add(new AppUserTest()
                {
                    AppUserID = checkboxes[i],
                    TestID = test.ID
                });
            }

            return test;
        }

        public List<AppUserTest> GetTestUsers(int? TestID)
        {
            return db.AppUserTests.ToList().FindAll(t => t.TestID == TestID);
        }

        public List<Test> GetTestIDForLoggedInAppUser(string userEmail)
        {
            var loggedInUser = db.Users.SingleOrDefault(u => u.Email == userEmail);

            var appUserTest = db.AppUserTests.ToList().FindAll(t => t.AppUserID == loggedInUser.Id);
            List<Test> testsForUser = new List<Test>();

            for (int i = 0; i < appUserTest.Count(); i++)
            {
                testsForUser.Add(db.Tests.SingleOrDefault(t => t.ID == appUserTest[i].TestID));
            }

            return testsForUser;
        }

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

        public double CalculateCorrectAnswers(List<Answer> submittedAnswers, AppUser appUser, QuestionTypeID questionTypeID, int questionCount, Test test)
        {
            int correctAnswers = 0;
            var answerBank = db.Answers.ToList();
            var tempAppUser = db.Users.SingleOrDefault(user => user.Email == appUser.Email);

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

        public void SaveTestResults(List<double> sectionResults, int testID, AppUser appUser)
        {
            var tempAppUser = db.Users.SingleOrDefault(user => user.Email == appUser.Email);

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

        public List<TestAttempt> GetTestAttempts()
        {
            return db.TestAttempts.ToList();
        }

        public void AddAppUser(List<AppUser> userList)
        {
            foreach (var user in userList)
            {
                db.Users.Add(user);
            }
        }

        public bool CheckUserTestAttempts(string email, int testID)
        {
            bool TestAlreadyTaken = false;
            var signedInUser = db.Users.SingleOrDefault(u => u.Email == email);

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



