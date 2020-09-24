using Microsoft.AspNetCore.Identity;
using MScApp.Core;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Xunit;

namespace MScAppTest
{
    public class AppUserTest
    {
        AppUser appUser;
        readonly string validFirstName = "FirstName";
        readonly string validLastName = "LastName";
        readonly string validAddress = "123 StreetName";
        readonly string validCity = "CityName";
        readonly string validPostCode = "PostCode";
        readonly string validCountry = "Country";
        readonly bool adminTrue = true;
        readonly bool adminFalse = false;
        IList<MScApp.Core.AppUserTest> appUserTests;
        readonly string validEmail = "Email@email.com";
        readonly string validUsername = "Email@email.com";
        readonly string validPhoneNumber = "PhoneNumber";
        readonly string hashedPassword = "PasswordHash";

        [Fact]
        public void AppUserConstructorTest()
        {
            appUser = new AppUser();

            Assert.NotNull(appUser);
            Assert.IsType<AppUser>(appUser);
        }

        [Fact]
        public void GetSetAppUserTests()
        {
            appUserTests = new List<MScApp.Core.AppUserTest>
            {
                new MScApp.Core.AppUserTest() { }
            };
            appUser = new AppUser
            {
                AppUserTests = appUserTests
            };

            Assert.NotNull(appUser.AppUserTests);
            Assert.Equal(appUserTests, appUser.AppUserTests);
        }

        [Fact]
        public void AppUserPropertiesTest()
        {
            appUser = new AppUser()
            {
                //Identity properties
                Email = validEmail,
                PasswordHash = hashedPassword,
                PhoneNumber = validPhoneNumber,
                UserName = validUsername,

                //AppUser class properties
                FirstName = validFirstName,
                LastName = validLastName,
                Address = validAddress,
                City = validCity,
                PostCode = validPostCode,
                Country = validCountry,
            };

            //Checking Identity properties
            Assert.Equal(validEmail, appUser.Email);
            Assert.Equal(hashedPassword, appUser.PasswordHash);
            Assert.Equal(validPhoneNumber, appUser.PhoneNumber);
            Assert.Equal(validUsername, appUser.UserName);
            //Ensuring email and username are the same
            Assert.Equal(validUsername, appUser.Email);
            Assert.Equal(validEmail, appUser.UserName);

            //Checking extended AppUser class properties
            Assert.Equal(validFirstName, appUser.FirstName);
            Assert.Equal(validLastName, appUser.LastName);
            Assert.Equal(validAddress, appUser.Address);
            Assert.Equal(validCity, appUser.City);
            Assert.Equal(validPostCode, appUser.PostCode);
            Assert.Equal(validCountry, appUser.Country);

        }

        [Fact]
        public void AppUserAdminTest()
        {
            appUser = new AppUser()
            {
                IsAdmin = adminTrue
            };
            Assert.True(appUser.IsAdmin);
        }

        [Fact]
        public void AppUserApplicantTest()
        {
            appUser = new AppUser()
            {
                IsAdmin = adminFalse
            };
            Assert.False(appUser.IsAdmin);
        }

    }
}
