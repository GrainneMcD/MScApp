using System.ComponentModel.DataAnnotations;

namespace MScApp.Core
{
    public class AnswerAttempt
    {
        [Key]
        public int ID { get; set; }
        public AppUser Applicant { get; set; }
        public string ApplicantID { get; set; }
        public Answer SelctedAnswer { get; set; }
        public int AnswerID { get; set; }
        public Test Test { get; set; }

    }
}
