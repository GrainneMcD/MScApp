using MScApp.Core;
using System;
using System.Collections.Generic;

namespace MScApp
{
    public class InMemoryQuestionData : IQuestionData
    {
        public Question AddQuestion(Question question)
        {
            throw new NotImplementedException();
        }

        public int Commit()
        {
            return 0;
        }

        public void DeleteQuestion(int questionID)
        {
            throw new NotImplementedException();
        }

        public Question GetByQuestionID(int questionID)
        {
            throw new NotImplementedException();
        }

        public List<Question> GetQuestionsAndAnswers()
        {
            throw new NotImplementedException();
        }


        public Question UpdateQuestion(Question updatedQuestion)
        {
            throw new NotImplementedException();
        }
    }
}
