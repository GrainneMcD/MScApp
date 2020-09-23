using CsvHelper.Configuration.Attributes;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MScApp.Core
{
    public class AppUser : IdentityUser<string>
    {

        [DataType(DataType.Text)]
        public string FirstName { get; set; }
        [DataType(DataType.Text)]
        public string LastName { get; set; }


        public string Address { get; set; }
        public string City { get; set; }
        [DataType(DataType.PostalCode)]
        public string PostCode { get; set; }
        public string Country { get; set; }

        public bool IsAdmin { get; set; }

        public IList<AppUserTest> AppUserTests { get; set; }

        public AppUser()
        {
            EmailConfirmed = true;
            
        }
    }
}
