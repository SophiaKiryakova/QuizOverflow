using QuizOverflow.Models.Abstracts;

namespace QuizOverflow.Models
{
    public class Player : EntityBase
    {
        public string? Name { get; set; }
        public int Score { get; set; }
        public bool IsHintUsed { get; set; }
    }
}
