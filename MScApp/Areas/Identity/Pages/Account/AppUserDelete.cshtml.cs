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
    public class AppUserDeleteModel : PageModel
    {
        readonly IApTestData apTestData;
        [BindProperty]
        public AppUser AppUser { get; set; }
        
        public AppUserDeleteModel(IApTestData apTestData)
        {
            this.apTestData = apTestData;
        }
        public void OnGet(string UserID)
        {
            AppUser = apTestData.GetAppUserByID(UserID);
        }

        public IActionResult OnPost(string UserID)
        {
            apTestData.DeleteAppUser(UserID);
            apTestData.Commit();

            TempData["Message"] = "AppUser has been successfully deleted";
            return RedirectToPage("./BulkRegister");
        }
    }
}
