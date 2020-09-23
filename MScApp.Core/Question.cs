using System.Collections.Generic;

namespace MScApp.Core
{
    public class Question
    {
        public int ID { get; set; }
        public string QuestionBody { get; set; }
        public List<Answer> Answers { get; set; }
        public QuestionTypeID QuestionTypeID { get; set; }
        public QuestionType QuestionType { get; set; }

        public bool IsDeleted { get; set; }

        public IList<QuestionTest> QuestionTests { get; set; }

        public Question()
        {
            Answers = new List<Answer>();
            IsDeleted = false;
        }
    }
}
