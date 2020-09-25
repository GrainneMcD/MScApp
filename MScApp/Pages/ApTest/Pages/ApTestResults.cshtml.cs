using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using MScApp.Core;
using MScApp.Pages.ApTest.Data;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MScApp.Pages.ApTest.Pages
{
    public class ApTestResultsModel : PageModel
    {
        private readonly IConfiguration config;
        public IApTestData ApTestData { get; set; }
        public List<AppUser> AppUsers { get; set; }
        public AppUser AppUser { get; set; }
        public List<Test> Tests { get; set; }
        public Test Test { get; set; }
        public List<TestAttempt> TestAttempts { get; set; }
        public TestAttempt TestAttempt { get; set; }


        public ApTestResultsModel(IConfiguration config, IApTestData ApTestData)
        {
            this.config = config;
            this.ApTestData = ApTestData;
        }

        public void OnGet()
        {
            AppUsers = ApTestData.GetAllAppUsers();
            Tests = ApTestData.GetTests();
            TestAttempts = ApTestData.GetTestAttempts();

        }

        public FileContentResult OnPost()
        {
            return DownloadResultsDataToCSV();

        }

        public FileContentResult DownloadResultsDataToCSV()
        {
            TestAttempts = ApTestData.GetTestAttempts();

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("AppUserID,TestName,WrittenAndVerbalReasoningScore,DiagrammaticReasoningScore,SymbolicManipulationScore,Pass\n");

            foreach (var testAttempt in TestAttempts)
            {
                stringBuilder.Append(testAttempt.AppUserID + ",");
                stringBuilder.Append(GetTestName(testAttempt.TestID) + ",");
                stringBuilder.Append(testAttempt.Section1Result.ToString() + ",");
                stringBuilder.Append(testAttempt.Section2Result.ToString() + ",");
                stringBuilder.Append(testAttempt.Section3Result.ToString() + ",");
                stringBuilder.Append(testAttempt.IsPass.ToString() + "\n");
            }

            return File(Encoding.UTF8.GetBytes(stringBuilder.ToString()), "text/csv", "UserResults.csv");
        }

        public string GetTestName(int testID)
        {
            var test = ApTestData.GetTestByID(testID);
            return test.TestName;
        }
    }
}