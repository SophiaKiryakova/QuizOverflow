using QuizOverflow.Models.Abstracts;

namespace QuizOverflow.Models
{
    public class Answer : EntityBase
    {
        public string? Name { get; set; }
        public bool IsCorrect { get; set; }

        public int QuestionId { get; set; }
        public Question? Question { get; set; }
    }
}
