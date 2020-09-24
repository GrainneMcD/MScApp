using MScApp.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MScAppTest
{
    public class TestTest
    {
        Test test;
        readonly int validTestID = 1;
        readonly string validTestName = "Test Name";
        DateTime validTestDate;
        DateTime validTestTime;
        readonly bool testDeletedTrue = true;
        readonly bool testDeletedFalse = false;
        readonly bool testDisabledTrue = true;
        readonly bool testDisabledFalse = false;
        IList<MScApp.Core.QuestionTest> questionTests;
        IList<MScApp.Core.AppUserTest> appUserTests;

        [Fact]
        public void TestConstructorTest()
        {
            test = new Test();

            Assert.NotNull(test);
            Assert.IsType<Test>(test);
        }

        [Fact]
        public void TestPropertiesTest()
        {
            validTestDate = new DateTime();
            validTestTime = new DateTime();

            test = new Test()
            {
                ID = validTestID,
                TestName = validTestName,
                Date = validTestDate,
                Time = validTestTime,
            };

            Assert.IsType<DateTime>(validTestDate);
            Assert.IsType<DateTime>(validTestTime);
            Assert.Equal(validTestID, test.ID);
            Assert.Equal(validTestName, test.TestName);
            Assert.Equal(validTestDate, test.Date);
            Assert.Equal(validTestTime, test.Time);

        }

        [Fact]
        public void TestDisabledTrueTest()
        {
            test = new Test()
            {
                IsDisabled = testDisabledTrue
            };

            Assert.True(test.IsDisabled);
        }

        [Fact]
        public void TestDisabledFalseTest()
        {
            test = new Test()
            {
                IsDisabled = testDisabledFalse
            };

            Assert.False(test.IsDisabled);
        }

        [Fact]
        public void TestDeletedTrueTest()
        {
            test = new Test()
            {
                IsDeleted = testDeletedTrue
            };

            Assert.True(test.IsDeleted);
        }

        [Fact]
        public void TestDeletedFalseTest()
        {
            test = new Test()
            {
                IsDisabled = testDeletedFalse
            };

            Assert.False(test.IsDeleted);
        }

        [Fact]
        public void GetSetQuestionTests()
        {
            questionTests = new List<MScApp.Core.QuestionTest>
            {
                new MScApp.Core.QuestionTest() { }
            };
            test = new Test()
            {
                QuestionTests = questionTests
            };

            Assert.NotNull(test.QuestionTests);
            Assert.Equal(questionTests, test.QuestionTests);
        }

        [Fact]
        public void GetSetAppUserTests()
        {
            appUserTests = new List<MScApp.Core.AppUserTest>
            {
                new MScApp.Core.AppUserTest() { }
            };
            test = new Test
            {
                AppUserTests = appUserTests
            };

            Assert.NotNull(test.AppUserTests);
            Assert.Equal(appUserTests, test.AppUserTests);
        }
    }
}
