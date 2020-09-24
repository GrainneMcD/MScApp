using MScApp.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MScAppTest
{
    public class QuestionTest
    {
        Question question;
        readonly int validQuestionID = 1;
        readonly string validQuestionBody = "Question Body?";
        List<Answer> answers;
        readonly QuestionTypeID validQuestionType1 = QuestionTypeID.Written_and_Verbal_Reasoning;
        readonly QuestionTypeID validQuestionType2 = QuestionTypeID.Diagrammatic_Reasoning;
        readonly QuestionTypeID validQuestionType3 = QuestionTypeID.Symbolic_Manipulation;
        QuestionType questionType;
        readonly bool deletedTrue = true;
        readonly bool deletedFalse = false;
        IList<MScApp.Core.QuestionTest> questionTests;

        [Fact]
        public void QuestionConstructorTest()
        {
            question = new Question();

            Assert.NotNull(question);
            Assert.IsType<Question>(question);
        }

        [Fact]
        public void QuestionPropertiesTest()
        {
            answers = new List<Answer>();
            questionType = new QuestionType();

            question = new Question()
            {
                ID = validQuestionID,
                QuestionBody = validQuestionBody,
                QuestionType = questionType,
                Answers = answers
            };
            Assert.NotNull(question.Answers);
            Assert.IsType<List<Answer>>(question.Answers);

            Assert.Equal(validQuestionID, question.ID);
            Assert.Equal(validQuestionBody, question.QuestionBody);
            Assert.Equal(answers, question.Answers);
            Assert.Equal(questionType, question.QuestionType);
        }
        [Fact]
        public void QuestionTypeTest()
        {
            question = new Question() { QuestionTypeID = QuestionTypeID.Written_and_Verbal_Reasoning };
            Assert.Equal(validQuestionType1, question.QuestionTypeID);

            question = new Question() { QuestionTypeID = QuestionTypeID.Diagrammatic_Reasoning };
            Assert.Equal(validQuestionType2, question.QuestionTypeID);

            question = new Question() { QuestionTypeID = QuestionTypeID.Symbolic_Manipulation };
            Assert.Equal(validQuestionType3, question.QuestionTypeID);
        }

        [Fact]
        public void QuestionIsDeletedTrueTest()
        {
            question = new Question()
            {
                IsDeleted = deletedTrue
            };

            Assert.True(question.IsDeleted);
        }

        [Fact]
        public void QuestionIsDeletedTrueFalse()
        {
            question = new Question()
            {
                IsDeleted = deletedFalse
            };

            Assert.False(question.IsDeleted);
        }
        [Fact]
        public void GetSetQuestionTests()
        {
            questionTests = new List<MScApp.Core.QuestionTest>
            {
                new MScApp.Core.QuestionTest() { }
            };
            question = new Question
            {
                QuestionTests = questionTests
            };

            Assert.NotNull(question.QuestionTests);
            Assert.Equal(questionTests, question.QuestionTests);
        }
    }
}
