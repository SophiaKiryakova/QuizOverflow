using QuizOverflow.Models.Abstracts;

namespace QuizOverflow.Models
{
    public class HighScore : EntityBase
    {
        public string? PlayerName { get; set; }
        public int? Score { get; set; }
    }
}
