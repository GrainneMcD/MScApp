using MScApp.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MScAppTest
{
    public class QuestionTypeTest
    {
        QuestionType questionType;
        List<Question> questions;
        readonly string validQuestionTypeName1 = "Written and Verbal Reasoning";
        readonly QuestionTypeID validQuestionType1 = QuestionTypeID.Written_and_Verbal_Reasoning;
        readonly string validQuestionTypeName2 = "Diagrammatic Reasoning";
        readonly QuestionTypeID validQuestionType2 = QuestionTypeID.Diagrammatic_Reasoning;
        readonly string validQuestionTypeName3 = "Symbolic Manipulation";
        readonly QuestionTypeID validQuestionType3 = QuestionTypeID.Symbolic_Manipulation;

        [Fact]
        public void QuestionTypeConstructorTest()
        {
            questionType = new QuestionType();

            Assert.NotNull(questionType);
            Assert.IsType<Question>(questionType);
        }

        [Fact]
        public void QuestionTypePropertiesTest()
        {
            questions = new List<Question>();
            questionType = new QuestionType()
            {
                Questions = questions,
                QuestionTypeID = validQuestionType1,
                QuestionTypeName = validQuestionTypeName1
            };
            Assert.NotNull(questionType.Questions);
            Assert.IsType<List<Question>>(questionType.Questions);

            Assert.Equal(questions, questionType.Questions);
            Assert.Equal(validQuestionTypeName1, questionType.QuestionTypeName);
            Assert.Equal(validQuestionType1, questionType.QuestionTypeID);

        }

        [Fact]
        public void QuestionTypeIDTest()
        {
            questionType = new QuestionType() { QuestionTypeID = QuestionTypeID.Written_and_Verbal_Reasoning };
            Assert.Equal(validQuestionType1, questionType.QuestionTypeID);

            questionType = new QuestionType() { QuestionTypeID = QuestionTypeID.Diagrammatic_Reasoning };
            Assert.Equal(validQuestionType2, questionType.QuestionTypeID);

            questionType = new QuestionType() { QuestionTypeID = QuestionTypeID.Symbolic_Manipulation };
            Assert.Equal(validQuestionType3, questionType.QuestionTypeID);
        }
    }
}
