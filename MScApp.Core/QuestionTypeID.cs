namespace MScApp.Core
{
    public enum QuestionTypeID : int
    {
        Written_and_Verbal_Reasoning = 0,
        Diagrammatic_Reasoning = 1,
        Symbolic_Manipulation = 2

    }
    public static class QuestionTypeHelper
    {

        public static string GetTestCategoryTitle(this QuestionTypeID questionTypeID)
        {
            switch (questionTypeID)
            {
                case QuestionTypeID.Written_and_Verbal_Reasoning:
                    {
                        return "Written and Verbal Reasoning";
                    }

                case QuestionTypeID.Diagrammatic_Reasoning:
                    {
                        return "Diagrammatic Reasoning";
                    }

                case QuestionTypeID.Symbolic_Manipulation:
                    {
                        return "Symbolic Manipulation";
                    }
                default:
                    {
                        return "";
                    }
            }
        }
    }


}
