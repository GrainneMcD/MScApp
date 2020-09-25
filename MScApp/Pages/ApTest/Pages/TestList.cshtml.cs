using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MScApp.Core;
using MScApp.Pages.ApTest.Data;
using System.Collections.Generic;
using System.Linq;

namespace MScApp.Pages.ApTest.Pages
{
    [Authorize(Policy = "IsAdmin")]
    public class TestListModel : PageModel
    {
        readonly IApTestData apTestData;

        public IEnumerable<Test> Tests { get; set; }
        public int UsersAssignedToTest { get; private set; }
        [BindProperty]
        public Test Test { get; set; }


        public TestListModel(IApTestData apTestData)
        {
            this.apTestData = apTestData;
        }

        public void OnGet()
        {
            Tests = apTestData.GetTests();

        }

        public int GetUsers(int TestID)
        {
            return apTestData.GetApplicantsAssignedToTestByID(TestID).Count();

        }
    }
}
