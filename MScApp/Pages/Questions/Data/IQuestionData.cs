using MScApp.Core;
using System.Collections.Generic;

namespace MScApp
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>
    ///     Interface for question data. Contains methods used to perform CRUD operations on the DB.
    /// </summary>
    ///-------------------------------------------------------------------------------------------------
    public interface IQuestionData
    {
        List<Question> GetQuestionsAndAnswers();
        Question GetByQuestionID(int questionID);
        void DeleteQuestion(int questionID);
        Question UpdateQuestion(Question updatedQuestion);
        Question AddQuestion(Question question);
        int Commit();
    }
}
