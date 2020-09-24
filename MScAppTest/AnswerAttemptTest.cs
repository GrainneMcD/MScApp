using MScApp.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MScAppTest
{
    public class AnswerAttemptTest
    {
        private AnswerAttempt answerAttempt;
        private AppUser validApplicant;
        private Answer validAnswer;
        readonly int validAnswerID = 1;
        private Test validTest;
        readonly string validApplicantID = "APP001";
        readonly int validAnswerAttemptID = 1;


        [Fact]
        public void AnswerAttemptPropertiesTest()
        {
            validApplicant = new AppUser() { Id = validApplicantID };
            validAnswer = new Answer() { ID = validAnswerID };
            validTest = new Test();

            answerAttempt = new AnswerAttempt()
            {
                ID = validAnswerAttemptID,
                AnswerID = validAnswer.ID,
                Applicant = validApplicant,
                ApplicantID = validApplicant.Id,
                SelctedAnswer = validAnswer,
                Test = validTest
            };

            Assert.NotNull(answerAttempt.Applicant);
            Assert.NotNull(answerAttempt.SelctedAnswer);
            Assert.NotNull(answerAttempt.Test);

            Assert.Equal(validAnswerAttemptID, answerAttempt.ID);
            Assert.Equal(validApplicant, answerAttempt.Applicant);
            Assert.Equal(validApplicantID, answerAttempt.ApplicantID);
            Assert.Equal(validAnswer, answerAttempt.SelctedAnswer);
            Assert.Equal(validAnswerID, answerAttempt.AnswerID);
            Assert.Equal(validTest, answerAttempt.Test);

        }

        [Fact]
        public void AnswerAttempConstructorTest()
        {
            answerAttempt = new AnswerAttempt();

            Assert.NotNull(answerAttempt);
            Assert.IsType<AnswerAttempt>(answerAttempt);
        }
    }
}
