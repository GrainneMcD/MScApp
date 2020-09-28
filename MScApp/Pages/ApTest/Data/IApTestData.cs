using MScApp.Core;
using System.Collections.Generic;

namespace MScApp.Pages.ApTest.Data
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   Interface for data surrounding Tests. </summary>
    ///-------------------------------------------------------------------------------------------------
    public interface IApTestData
    {
        List<Question> GetQuestionsAndAnswers();
        List<Question> GetQuestionsByQuestionTypeID(QuestionTypeID questionTypeID);
        void SaveAnswerAttempt(List<Answer> answers, AppUser applicant, Test test);
        AppUser GetAppUserByID(string userID);
        void DeleteAppUser(string appUserID);
        AppUser UpdateAppUser(AppUser updatedAppUser);
        double CalculateCorrectAnswers(List<Answer> submittedAnswers, AppUser applicant, QuestionTypeID questionTypeID, int questionCount, Test test);
        List<Test> GetTests();
        Test GetTestByID(int? testID);
        Test AddTest(Test test);
        Test UpdateTest(Test updatedTest);
        List<Question> GetAndParseQuestions(string[] questionCheckboxes);
        void AddQuestionsToTest(Test test, string[] questionCheckboxes);
        Test UpdateTestQuestions(Test test, string[] questionCheckboxes);
        void DeleteTest(int TestID);
        List<QuestionTest> GetTestQuestions(int? TestID);
        bool IsQuestionOnTest(int QuestionID, int TestID);
        List<AppUser> GetAllAppUsers();
        Test AddApplicantsToTest(Test test, string[] applicantCheckboxes);
        bool IsApplicantAssignedToTest(string applicantID, int TestID);
        Test UpdateApplicantsAssignedToTest(Test test, string[] applicantCheckboxes);
        List<AppUserTest> GetApplicantsAssignedToTestByID(int? TestID);
        List<Test> GetTestIDForLoggedInApplicant(string applicantEmail);
        List<Question> GetQuestionListForTestByQuestionType(int TestID, QuestionTypeID questionTypeID);
        void SaveTestResults(List<double> sectionResults, int testID, AppUser applicant);
        List<TestAttempt> GetTestAttempts();
        void AddNewApplicant(List<AppUser> userList);
        bool CheckIfApplicantHasSubmittedTestAttempt(string applicantEmail, int testID);
        int Commit();

    }
}
