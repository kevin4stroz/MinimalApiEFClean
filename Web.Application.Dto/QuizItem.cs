namespace Web.Application.Dto
{
    public class QuizItem
    {
        public string Question { get; set; }
        public List<string> Choices { get; set; }
        public int AnswerIndex { get; set; }
        public int Score { get; set; }

        public int? CategoryId { get; set; }

        public QuizItem(string question, List<string> choices, int answerIndex, int score, int? categoryId = null)
        {
            this.Question = question;
            this.Choices = choices;
            this.AnswerIndex = answerIndex;
            this.Score = score;
            CategoryId = categoryId;
        }
    }
}
