using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MScApp.Core;
using MScApp.Pages.ApTest.Data;

namespace MScApp.Pages.ApTest.Pages
{
    [Authorize(Policy = "IsAdmin")]
    public class TestDeleteModel : PageModel
    {
        readonly IApTestData apTestData;

        [BindProperty]
        public Test Test { get; set; }

        public string Message { get; set; }

        public TestDeleteModel(IApTestData apTestData)
        {
            this.apTestData = apTestData;
        }

        public IActionResult OnGet(int TestID)
        {
            Test = apTestData.GetTestByID(TestID);
            return Page();
        }

        public IActionResult OnPost(int TestID)
        {
            apTestData.DeleteTest(TestID);
            apTestData.Commit();

            Message = "Test has been deleted";
            return RedirectToPage("./TestList");
        }
    }
}
