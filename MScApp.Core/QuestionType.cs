using System.Collections.Generic;

namespace MScApp.Core
{
    public class QuestionType
    {
        public QuestionTypeID QuestionTypeID { get; set; }
        public string QuestionTypeName { get; set; }
        public List<Question> Questions { get; set; }
    }
}
