using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MScApp.Core;
using MScApp.Pages.ApTest.Data;
using System.Collections.Generic;

namespace MScApp.Pages.ApTest.Pages
{
    [Authorize(Policy = "IsAdmin")]
    public class TestUserManageModel : PageModel
    {
        readonly IApTestData apTestData;
        [BindProperty]
        public Test Test { get; set; }
        public AppUser AppUser { get; set; }
        public List<AppUser> AppUsers { get; set; }

        public string Message { get; set; }

        public TestUserManageModel(IApTestData apTestData
)
        {
            this.apTestData = apTestData;
        }

        public void OnGet(int? TestID)
        {
            Test = apTestData.GetTestByID(TestID);
            AppUsers = apTestData.GetAllUsers();
        }

        public IActionResult OnPost(string[] userCheckboxes)
        {
            var TestUsers = apTestData.GetTestUsers(Test.ID);
            if (TestUsers.Count == 0)
            {
                apTestData.AddUsersToTest(Test, userCheckboxes);
                TempData["Message"] = "Users Added to Test";
            }
            else
            {
                apTestData.UpdateUsersOnTest(Test, userCheckboxes);
                TempData["Message"] = "Test Users Updated";
            }

            apTestData.Commit();

            return RedirectToPage("./TestDetail", new { TestID = Test.ID });
        }

        public bool IsUserAssignedToTest(string UserID, int TestID)
        {
            return apTestData.IsUserAssignedToTest(UserID, TestID);
        }
    }
}
