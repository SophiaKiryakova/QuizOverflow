using QuizOverflow.Models.Abstracts;

namespace QuizOverflow.Models
{
    public class GamePlayer : EntityBase
    {
        public int GameId { get; set; }
        public Game Game { get; set; }

        public int PlayerId { get; set; }
        public Player Player { get; set; }
    }
}
