using MScApp.Core;
using System;
using System.Collections.Generic;

namespace MScApp.Pages.ApTest.Data
{
    public class InMemoryApTestData : IApTestData
    {
        public void AddAppUser(List<AppUser> userList)
        {
            throw new NotImplementedException();
        }

        public void AddQuestionsToTest(Test test, string[] checkboxes)
        {
            throw new NotImplementedException();
        }

        public Test AddTest(Test test)
        {
            throw new NotImplementedException();
        }

        public Test AddUsersToTest(Test test, string[] checkboxes)
        {
            throw new NotImplementedException();
        }

        public double CalculateCorrectAnswers(List<Answer> submittedAnswers, AppUser appUser, QuestionTypeID questionTypeID, int questionCount, Test test)
        {
            throw new NotImplementedException();
        }

        public bool CheckUserTestAttempts(string email, int testID)
        {
            throw new NotImplementedException();
        }

        public int Commit()
        {
            throw new NotImplementedException();
        }

        public Test DeleteTest(int TestID)
        {
            throw new NotImplementedException();
        }

        public List<AppUser> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public List<Question> GetAndParseQuestions(string[] checkboxes)
        {
            throw new NotImplementedException();
        }

        public List<Question> GetQuestionListForTestByQuestionType(int TestID, QuestionTypeID questionTypeID)
        {
            throw new NotImplementedException();
        }

        public List<Question> GetQuestionsAndAnswers(int questionID)
        {
            throw new NotImplementedException();
        }

        public List<Question> GetQuestionsByQuestionTypeID(QuestionTypeID questionTypeID)
        {
            throw new NotImplementedException();
        }

        public List<TestAttempt> GetTestAttempts()
        {
            throw new NotImplementedException();
        }

        public Test GetTestByID(int? testID)
        {
            throw new NotImplementedException();
        }

        public List<Test> GetTestIDForLoggedInAppUser(string userEmail)
        {
            throw new NotImplementedException();
        }

        public List<QuestionTest> GetTestQuestions(int? TestID)
        {
            throw new NotImplementedException();
        }

        public List<Test> GetTests()
        {
            throw new NotImplementedException();
        }

        public List<AppUserTest> GetTestUsers(int? TestID)
        {
            throw new NotImplementedException();
        }

        public bool IsQuestionOnTest(int QuestionID, int TestID)
        {
            throw new NotImplementedException();
        }

        public bool IsUserAssignedToTest(string UserID, int TestID)
        {
            throw new NotImplementedException();
        }

        public void SaveAnswerAttempt(List<Answer> answers, AppUser appUser, Test test)
        {
            throw new NotImplementedException();
        }

        public void SaveTestResults(List<double> sectionResults, int testID, AppUser appUser)
        {
            throw new NotImplementedException();
        }

        public Test UpdateTest(Test updatedTest)
        {
            throw new NotImplementedException();
        }

        public Test UpdateTestQuestions(Test test, string[] checkboxes)
        {
            throw new NotImplementedException();
        }

        public Test UpdateUsersOnTest(Test test, string[] checkboxes)
        {
            throw new NotImplementedException();
        }
    }
}
