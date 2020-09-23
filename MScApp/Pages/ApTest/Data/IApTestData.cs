using MScApp.Core;
using System.Collections.Generic;

namespace MScApp.Pages.ApTest.Data
{
    public interface IApTestData
    {
        List<Question> GetQuestionsAndAnswers(int questionID);

        List<Question> GetQuestionsByQuestionTypeID(QuestionTypeID questionTypeID);

        void SaveAnswerAttempt(List<Answer> answers, AppUser appUser, Test test);

        double CalculateCorrectAnswers(List<Answer> submittedAnswers, AppUser appUser, QuestionTypeID questionTypeID, int questionCount, Test test);

        List<Test> GetTests();

        Test GetTestByID(int? testID);

        Test AddTest(Test test);

        Test UpdateTest(Test updatedTest);

        List<Question> GetAndParseQuestions(string[] checkboxes);

        void AddQuestionsToTest(Test test, string[] checkboxes);

        Test UpdateTestQuestions(Test test, string[] checkboxes);

        Test DeleteTest(int TestID);

        List<QuestionTest> GetTestQuestions(int? TestID);

        bool IsQuestionOnTest(int QuestionID, int TestID);

        List<AppUser> GetAllUsers();

        Test AddUsersToTest(Test test, string[] checkboxes);

        bool IsUserAssignedToTest(string UserID, int TestID);

        Test UpdateUsersOnTest(Test test, string[] checkboxes);

        List<AppUserTest> GetTestUsers(int? TestID);

        List<Test> GetTestIDForLoggedInAppUser(string userEmail);

        List<Question> GetQuestionListForTestByQuestionType(int TestID, QuestionTypeID questionTypeID);

        void SaveTestResults(List<double> sectionResults, int testID, AppUser appUser);

        List<TestAttempt> GetTestAttempts();

        void AddAppUser(List<AppUser> userList);

        bool CheckUserTestAttempts(string email, int testID);

        int Commit();

    }
}
