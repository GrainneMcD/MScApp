using MScApp.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MScAppTest
{
    public class TestAttemptTest
    {
        TestAttempt testAttempt;
        readonly int validTestAttemptID = 1;
        readonly string validAppUserID = "APP001";
        readonly int validTestID = 1;
        readonly double validSection1Result = 50.0;
        readonly double validSection2Result = 50.0;
        readonly double validSection3Result = 50.0;
        readonly bool testPassTrue = true;
        readonly bool testPassFalse = false;

        [Fact]
        public void TestAttemptConstructorTest()
        {
            testAttempt = new TestAttempt();

            Assert.NotNull(testAttempt);
            Assert.IsType<TestAttempt>(testAttempt);
        }

        [Fact]
        public void TestAttemptPropertiesTest()
        {
            testAttempt = new TestAttempt()
            {
                ID = validTestAttemptID,
                AppUserID = validAppUserID,
                TestID = validTestID,
                Section1Result = validSection1Result,
                Section2Result = validSection2Result,
                Section3Result = validSection3Result,
            };

            Assert.Equal(validTestID, testAttempt.ID);
            Assert.Equal(validAppUserID, testAttempt.AppUserID);
            Assert.Equal(validTestID, testAttempt.TestID);
            Assert.Equal(validSection1Result, testAttempt.Section1Result);
            Assert.Equal(validSection2Result, testAttempt.Section2Result);
            Assert.Equal(validSection3Result, testAttempt.Section3Result);
        }

        [Fact]

        public void TestIsPassTrueTest()
        {
            testAttempt = new TestAttempt()
            {
                IsPass = testPassTrue
            };

            Assert.True(testAttempt.IsPass);
        }

        [Fact]
        public void TestIsPassFalseTest()
        {
            testAttempt = new TestAttempt()
            {
                IsPass = testPassFalse
            };

            Assert.False(testAttempt.IsPass);
        }
    }
}
