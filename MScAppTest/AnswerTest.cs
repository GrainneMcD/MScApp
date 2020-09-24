using MScApp.Core;
using System;
using Xunit;
using System.Diagnostics.CodeAnalysis;

namespace MScAppTest
{
    public class AnswerTest
    {
        private Answer answer;
        Question validQuestion;
        readonly int validAnswerID = 1;
        readonly string validAnswerBody = "Answer Body";
        readonly bool correctAnswer = true;
        readonly bool incorrectAnswer = false;
        readonly int validQuestionID = 1;


        [Fact]
        public void AnswerPropertiesTest()
        {
            validQuestion = new Question() { ID = validQuestionID };
            answer = new Answer()
            {
                ID = validAnswerID,
                AnswerBody = validAnswerBody,
                Question = validQuestion,
                QuestionID = 1
            };

            Assert.Equal(validAnswerBody, answer.AnswerBody);
            Assert.Equal(validAnswerID, answer.ID);
            Assert.NotNull(answer.Question);
            Assert.Equal(validQuestion, answer.Question);
            Assert.Equal(validQuestionID, answer.QuestionID);

        }
        [Fact]
        public void AnswerIsCorrectTrueTest()
        {
            answer = new Answer()
            {
                IsCorrect = correctAnswer
            };
            Assert.True(answer.IsCorrect);
        }

        [Fact]
        public void AnswerISCorrectFalseTest()
        {
            answer = new Answer()
            {
                IsCorrect = incorrectAnswer
            };
            Assert.False(answer.IsCorrect);
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
