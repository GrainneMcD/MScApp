using System;
using System.Collections.Generic;

namespace MScApp.Core
{
    public class Test
    {
        public int ID { get; set; }
        public string TestName { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsDisabled { get; set; }

        public IList<QuestionTest> QuestionTests { get; set; }
        public IList<AppUserTest> AppUserTests { get; set; }

        public Test()
        {
            IsDeleted = false;
            IsDisabled = true;
        }
    }
}
