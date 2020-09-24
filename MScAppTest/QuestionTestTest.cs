using MScApp.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MScAppTest
{
    public class QuestionTestTest
    {
        MScApp.Core.QuestionTest questionTest;
        Question validQuestion;
        readonly int validQuestionID = 1;
        Test validTest;
        readonly int validTestID = 1;

        [Fact]
        public void QuestionTestConstructorTest()
        {
            questionTest = new MScApp.Core.QuestionTest();

            Assert.NotNull(questionTest);
            Assert.IsType<MScApp.Core.QuestionTest>(questionTest);
        }

        [Fact]
        public void QuestionTestPropertiesTest()
        {
            validQuestion = new Question() { ID = validQuestionID };
            validTest = new Test() { ID = validTestID };
            questionTest = new MScApp.Core.QuestionTest()
            {
                Question = validQuestion,
                QuestionID = validQuestion.ID,
                Test = validTest,
                TestID = validTest.ID
            };


            Assert.NotNull(validTest);
            Assert.IsType<Test>(validTest);
            Assert.NotNull(validQuestion);
            Assert.IsType<Question>(validQuestion);

            Assert.Equal(validTest, questionTest.Test);
            Assert.Equal(validTestID, questionTest.TestID);
            Assert.Equal(validQuestion, questionTest.Question);
            Assert.Equal(validQuestionID, questionTest.QuestionID);
        }
    }
}
