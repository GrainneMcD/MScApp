using MScApp.Core;
using System;
using Xunit;
using System.Diagnostics.CodeAnalysis;

namespace MScAppTest
{
    public class AnswerTest
    {
        private Answer answer;
        Question question;
        readonly int answerID = 1;
        readonly string validAnswerBody = "Answer Body";
        readonly string invalidAnswerBody = "";
        readonly bool correctAnswer = true;
        readonly bool incorrectAnswer = false;
        readonly int questionID = 1;


        [Fact]
        public void AnswerPropertiesTest()
        {
            question = new Question() { ID = questionID };
            answer = new Answer()
            {
                ID = answerID,
                AnswerBody = validAnswerBody,
                IsCorrect = correctAnswer,
                Question = question,
                QuestionID = 1
            };

            Assert.NotNull(answer);
            Assert.Equal(validAnswerBody, answer.AnswerBody);
            Assert.Equal(answerID, answer.ID);
            Assert.Equal(question, answer.Question);
            Assert.NotNull(answer.Question);
            Assert.Equal(questionID, answer.QuestionID);
            Assert.True(answer.IsCorrect);
        }

        [Fact]
        public void AnswerConstructorTest()
        {
            answer = new Answer();
            Assert.IsType<Answer>(answer);
            Assert.NotNull(answer);
        }
    }
}
