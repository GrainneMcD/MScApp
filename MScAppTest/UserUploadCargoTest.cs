using MScApp.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MScAppTest
{
    public class UserUploadCargoTest
    {
        UserUploadCargo userUploadCargo;
        readonly string validAppUserID = "APP001";
        readonly string validEmail = "email@email.com";
        readonly string validPassword = "ValidPassword";
        readonly string validPhoneNumber = "PhoneNumber";
        readonly string validFirstName = "FirstName";
        readonly string validLastName = "LastName";
        readonly string validAddress = "123 Street Name";
        readonly string validCity = "City";
        readonly string validPostCode = "PostCode";
        readonly string validCountry = "Country";

        [Fact]
        public void UserUploadCargoConstructorTest()
        {
            userUploadCargo = new UserUploadCargo();

            Assert.NotNull(userUploadCargo);
            Assert.IsType<UserUploadCargo>(userUploadCargo);
        }
        [Fact]
        public void UserUploadCargoPropertiesTest()
        {
            userUploadCargo = new UserUploadCargo()
            {
                ID = validAppUserID,
                Email = validEmail,
                Password = validPassword,
                PhoneNumber = validPhoneNumber,
                FirstName = validFirstName,
                LastName = validLastName,
                Address = validAddress,
                City = validCity,
                PostCode = validPostCode,
                Country = validCountry
            };

            Assert.Equal(validAppUserID, userUploadCargo.ID);
            Assert.Equal(validEmail, userUploadCargo.Email);
            Assert.Equal(validPassword, userUploadCargo.Password);
            Assert.Equal(validPhoneNumber, userUploadCargo.PhoneNumber);
            Assert.Equal(validFirstName, userUploadCargo.FirstName);
            Assert.Equal(validLastName, userUploadCargo.LastName);
            Assert.Equal(validAddress, userUploadCargo.Address);
            Assert.Equal(validCity, userUploadCargo.City);
            Assert.Equal(validPostCode, userUploadCargo.PostCode);
            Assert.Equal(validCountry, userUploadCargo.Country);
        }
    }
}
