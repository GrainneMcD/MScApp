using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MScApp.Core;
using MScApp.Pages.ApTest.Data;

namespace MScApp.Areas.Identity.Pages.Account
{
    public class BulkRegisterModel : PageModel
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IApTestData apTestData;

        [BindProperty]
        public IFormFile UserFile { get; set; }
        [TempData]
        public string Message { get; set; }
        public List<AppUser> AppUsers { get; set; }

        public BulkRegisterModel(UserManager<AppUser> userManager, IApTestData apTestData)
        {
            _userManager = userManager;
            this.apTestData = apTestData;
        }

        public void OnGet()
        {
            AppUsers = apTestData.GetAllAppUsers();
        }


        public void OnPost()
        {
            List<UserUploadCargo> records;
            List<AppUser> usersToAdd = new List<AppUser>();
            var file = UserFile;

            if (!(file is null))
            {
                var reader = new StreamReader(file.OpenReadStream());
                var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

                records = csv.GetRecords<UserUploadCargo>().ToList();

                foreach (var record in records)
                {
                    var appUser = new AppUser
                    {
                        Id = record.ID,
                        UserName = record.Email,
                        NormalizedUserName = record.Email.ToUpper(),
                        Email = record.Email,
                        NormalizedEmail = record.Email.ToUpper(),
                        FirstName = record.FirstName,
                        LastName = record.LastName,
                        PhoneNumber = record.PhoneNumber,
                        Address = record.Address,
                        City = record.City,
                        Country = record.Country,
                        PostCode = record.PostCode,
                    };

                    var passwordHasher = new PasswordHasher<AppUser>();
                    var hashedPassword = passwordHasher.HashPassword(appUser, record.Password);

                    appUser.PasswordHash = hashedPassword;
                    appUser.SecurityStamp = Guid.NewGuid().ToString();
                    usersToAdd.Add(appUser);
                }
                apTestData.AddNewApplicant(usersToAdd);
                apTestData.Commit();

                foreach (var user in usersToAdd)
                {
                    _ = _userManager.AddClaimAsync(user,
                    new System.Security.Claims.Claim("FullName",
                    user.FirstName + " " + user.LastName));
                }
            }
            else
            {
                throw new ArgumentNullException(nameof(file));
            }

            RedirectToPage("BulkRegister");
            TempData["Message"] = "All applicants have been successfully created";
        }
    }
}
