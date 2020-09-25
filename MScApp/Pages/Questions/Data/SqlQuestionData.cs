using Microsoft.EntityFrameworkCore;
using MScApp.Core;
using System.Collections.Generic;
using System.Linq;

namespace MScApp
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   A SQL implementation of the question data interface. </summary>
    /// -------------------------------------------------------------------------------------------------
    public class SqlQuestionData : IQuestionData
    {
        public MScAppDbContext db;

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Constructor. </summary>
        ///
        /// <param name="db">   The database. </param>
        ///-------------------------------------------------------------------------------------------------
        public SqlQuestionData(MScAppDbContext db)
        {
            this.db = db;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets all questions from the db by question identifier. </summary>
        /// 
        /// <param name="questionID">   Identifier for the question. </param>
        ///
        /// <returns>   The question by question identifier. </returns>
        ///-------------------------------------------------------------------------------------------------
        public Question GetByQuestionID(int questionID)
        {
            var question = db.Questions.Include(a => a.Answers).SingleOrDefault(q => q.ID == questionID);
            return question;

        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Commits all changes made to the db </summary>
        ///
        ///  <returns>   An int. </returns>
        ///-------------------------------------------------------------------------------------------------
        public int Commit()
        {
            return db.SaveChanges();
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets all questions and answers from db. </summary>
        ///
        /// <param name="questionID">   Identifier for the question. </param>
        ///
        /// <returns>   The questions and answers as List. </returns>
        ///-------------------------------------------------------------------------------------------------
        public List<Question> GetQuestionsAndAnswers()
        {
            var AllQuestions = db.Questions.Include(q => q.Answers).ToList();
            return AllQuestions;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Updates the question described by updatedQuestion. </summary>
        ///
        /// <param name="updatedQuestion">  The updated question. </param>
        ///
        /// <returns>   The updatedQuestion as it is held in the db </returns>
        ///-------------------------------------------------------------------------------------------------
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

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Adds a new question to db. </summary>
        /// 
        /// <param name="question"> The question to be added. </param>
        ///
        /// <returns>   The Question that was added. </returns>
        ///-------------------------------------------------------------------------------------------------
        public Question AddQuestion(Question question)
        {
            db.Questions.Add(question);
            return question;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Deletes the question described by questionID. </summary>
        ///
        /// <param name="questionID">   Identifier for the question. </param>
        /// -------------------------------------------------------------------------------------------------

        public void DeleteQuestion(int questionID)
        {
            var question = db.Questions.SingleOrDefault(q => q.ID == questionID);
            question.IsDeleted = true;
        }
    }
}
