using Microsoft.EntityFrameworkCore;
using MScApp.Core;
using System.Collections.Generic;
using System.Linq;

namespace MScApp
{
    public class SqlQuestionData : IQuestionData
    {
        public MScAppDbContext db;

        public SqlQuestionData(MScAppDbContext db)
        {
            this.db = db;
        }

        public Question GetByQuestionID(int questionID)
        {
            var question = db.Questions.Include(a => a.Answers).SingleOrDefault(q => q.ID == questionID);
            return question;

        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public List<Question> GetQuestionsAndAnswers(int questionID)
        {
            var AllQuestions = db.Questions.Include(q => q.Answers).ToList();
            return AllQuestions;
        }

        public Question UpdateQuestion(Question updatedQuestion)
        {
            var state = db.Entry(updatedQuestion).State;
            var questioninDB = db.Questions.Include(a => a.Answers).SingleOrDefault(q => q.ID == updatedQuestion.ID);

            questioninDB.ID = updatedQuestion.ID;
            questioninDB.QuestionBody = updatedQuestion.QuestionBody;
            questioninDB.Answers = updatedQuestion.Answers;
            questioninDB.QuestionType = updatedQuestion.QuestionType;
            questioninDB.QuestionTypeID = updatedQuestion.QuestionTypeID;

            state = EntityState.Modified;
            return questioninDB;
        }

        public Question AddQuestion(Question question)
        {
            db.Questions.Add(question);
            return question;
        }

        public Question DeleteQuestion(int questionID)
        {
            var question = db.Questions.SingleOrDefault(q => q.ID == questionID);
            question.IsDeleted = true;
            return question;
        }
    }
}
