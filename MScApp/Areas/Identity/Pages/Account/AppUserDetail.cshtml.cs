using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MScApp.Core;
using MScApp.Pages.ApTest.Data;


namespace MScApp.Areas.Identity.Pages.Account
{
    public class AppUserDetailModel : PageModel
    {
        readonly IApTestData apTestData;
        [BindProperty]
        public AppUser AppUser { get; set; }
        public List<Test> TestsApplicantIsAssignedTo { get; set; }
        [TempData]
        public string Message { get; set; }
        [TempData]
        public bool IsAdmin { get; set; }

        public AppUserDetailModel(IApTestData apTestData)
        {
            this.apTestData = apTestData;
        }
        public void OnGet(string UserID)
        {
            IsAdmin = true;
            AppUser = apTestData.GetAppUserByID(UserID);

            if (!AppUser.IsAdmin)
            {
                IsAdmin = false;
                TestsApplicantIsAssignedTo = apTestData.GetTestIDForLoggedInApplicant(AppUser.Email);

            }
        }

        public IActionResult OnPost(string UserID)
        {

            apTestData.UpdateAppUser(AppUser);
            apTestData.Commit();

            if (IsAdmin)
            {
                TempData["Message"] = "Admin's details have been updated";
            }
            else
            {
                TempData["Message"] = "Applicant's details have been updated";
            }

            return RedirectToPage("AppUserDetail/", UserID);

        }
    }
}
