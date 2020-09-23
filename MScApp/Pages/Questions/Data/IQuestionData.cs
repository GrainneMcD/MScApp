using MScApp.Core;
using System.Collections.Generic;

namespace MScApp
{
    public interface IQuestionData
    {
        List<Question> GetQuestionsAndAnswers(int questionID);

        Question GetByQuestionID(int questionID);

        Question DeleteQuestion(int questionID);

        Question UpdateQuestion(Question updatedQuestion);

        Question AddQuestion(Question question);

        int Commit();
    }
}
