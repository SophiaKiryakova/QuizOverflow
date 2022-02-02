using QuizOverflow.Models.Abstracts;

namespace QuizOverflow.Models
{
    public class GameQuestion : EntityBase
    {
        public int GameId { get; set; }
        public Game Game { get; set; }

        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
