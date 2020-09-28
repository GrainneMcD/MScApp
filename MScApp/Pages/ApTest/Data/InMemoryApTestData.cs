using MScApp.Core;
using System;
using System.Collections.Generic;

namespace MScApp.Pages.ApTest.Data
{
    public class InMemoryApTestData : IApTestData
    {
        public Test AddApplicantsToTest(Test test, string[] applicantCheckboxes)
        {
            throw new NotImplementedException();
        }

        public void AddNewApplicant(List<AppUser> userList)
        {
            throw new NotImplementedException();
        }

        public void AddQuestionsToTest(Test test, string[] questionCheckboxes)
        {
            throw new NotImplementedException();
        }

        public Test AddTest(Test test)
        {
            throw new NotImplementedException();
        }

        public double CalculateCorrectAnswers(List<Answer> submittedAnswers, AppUser applicant, QuestionTypeID questionTypeID, int questionCount, Test test)
        {
            throw new NotImplementedException();
        }

        public bool CheckIfApplicantHasSubmittedTestAttempt(string applicantEmail, int testID)
        {
            throw new NotImplementedException();
        }

        public int Commit()
        {
            throw new NotImplementedException();
        }

        public void DeleteAppUser(AppUser appUser)
        {
            throw new NotImplementedException();
        }

        public void DeleteAppUser(string appUserID)
        {
            throw new NotImplementedException();
        }

        public void DeleteTest(int TestID)
        {
            throw new NotImplementedException();
        }

        public List<AppUser> GetAllAppUsers()
        {
            throw new NotImplementedException();
        }

        public List<Question> GetAndParseQuestions(string[] questionCheckboxes)
        {
            throw new NotImplementedException();
        }

        public List<AppUserTest> GetApplicantsAssignedToTestByID(int? TestID)
        {
            throw new NotImplementedException();
        }

        public AppUser GetAppUserByID(string userID)
        {
            throw new NotImplementedException();
        }

        public List<Question> GetQuestionListForTestByQuestionType(int TestID, QuestionTypeID questionTypeID)
        {
            throw new NotImplementedException();
        }

        public List<Question> GetQuestionsAndAnswers()
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

        public List<Test> GetTestIDForLoggedInApplicant(string applicantEmail)
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

        public bool IsApplicantAssignedToTest(string applicantID, int TestID)
        {
            throw new NotImplementedException();
        }

        public bool IsQuestionOnTest(int QuestionID, int TestID)
        {
            throw new NotImplementedException();
        }

        public void SaveAnswerAttempt(List<Answer> answers, AppUser applicant, Test test)
        {
            throw new NotImplementedException();
        }

        public void SaveTestResults(List<double> sectionResults, int testID, AppUser applicant)
        {
            throw new NotImplementedException();
        }

        public Test UpdateApplicantsAssignedToTest(Test test, string[] applicantCheckboxes)
        {
            throw new NotImplementedException();
        }

        public AppUser UpdateAppUser(AppUser updatedAppUser)
        {
            throw new NotImplementedException();
        }

        public Test UpdateTest(Test updatedTest)
        {
            throw new NotImplementedException();
        }

        public Test UpdateTestQuestions(Test test, string[] questionCheckboxes)
        {
            throw new NotImplementedException();
        }
    }
}
