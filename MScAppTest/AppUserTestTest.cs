using MScApp.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MScAppTest
{
    public class AppUserTestTest
    {
        MScApp.Core.AppUserTest appUserTest;
        AppUser validAppUser;
        readonly string validAppUserID = "APP001";
        Test validTest;
        readonly int validTestID = 1;

        [Fact]
        public void AppUserTestConstructorTest()
        {
            appUserTest = new MScApp.Core.AppUserTest();

            Assert.NotNull(appUserTest);
            Assert.IsType<MScApp.Core.AppUserTest>(appUserTest);
        }

        [Fact]
        public void AppUserTestPropertiesTest()
        {
            validAppUser = new AppUser() { Id = validAppUserID };
            validTest = new Test() { ID = validTestID };
            appUserTest = new MScApp.Core.AppUserTest()
            {
                AppUser = validAppUser,
                AppUserID = validAppUser.Id,
                Test = validTest,
                TestID = validTest.ID
            };


            Assert.NotNull(validTest);
            Assert.IsType<Test>(validTest);
            Assert.NotNull(validAppUser);
            Assert.IsType<AppUser>(validAppUser);

            Assert.Equal(validTest, appUserTest.Test);
            Assert.Equal(validTestID, appUserTest.TestID);
            Assert.Equal(validAppUser, appUserTest.AppUser);
            Assert.Equal(validAppUserID, appUserTest.AppUserID);

        }
    }
}
