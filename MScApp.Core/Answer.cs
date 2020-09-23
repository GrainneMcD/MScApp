namespace MScApp.Core
{
    public class Answer
    {
        public int ID { get; set; }
        public string AnswerBody { get; set; }
        public bool IsCorrect { get; set; }
        public Question Question { get; set; }
        public int QuestionID { get; set; }
    }
}
