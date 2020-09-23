namespace MScApp.Core
{
    public class TestAttempt
    {
        public int ID { get; set; }
        public string AppUserID { get; set; }
        public int TestID { get; set; }
        public double Section1Result { get; set; }
        public double Section2Result { get; set; }
        public double Section3Result { get; set; }
        public bool IsPass { get; set; }
    }
}
