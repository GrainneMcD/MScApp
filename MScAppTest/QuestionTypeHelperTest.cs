using MScApp.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MScAppTest
{
    public class QuestionTypeHelperTest
    {
        readonly QuestionTypeID validQuestionTypeID1 = QuestionTypeID.Written_and_Verbal_Reasoning;
        readonly string validQuestionTypeName1 = "Written and Verbal Reasoning";
        readonly QuestionTypeID validQuestionTypeID2 = QuestionTypeID.Diagrammatic_Reasoning;
        readonly string validQuestionTypeName2 = "Diagrammatic Reasoning";
        readonly QuestionTypeID validQuestionTypeID3 = QuestionTypeID.Symbolic_Manipulation;
        readonly string validQuestionTypeName3 = "Symbolic Manipulation";

        [Fact]
        public void QuestionTypeHelperGetTestCategoryTest()
        {
            var actualQuestionTypeID1 = QuestionTypeHelper.GetTestCategoryTitle(validQuestionTypeID1);
            Assert.Equal(validQuestionTypeName1, actualQuestionTypeID1);

            var actualQuestionTypeID2 = QuestionTypeHelper.GetTestCategoryTitle(validQuestionTypeID2);
            Assert.Equal(validQuestionTypeName2, actualQuestionTypeID2);

            var actualQuestionTypeID3 = QuestionTypeHelper.GetTestCategoryTitle(validQuestionTypeID3);
            Assert.Equal(validQuestionTypeName3, actualQuestionTypeID3);

        }

    }
}
