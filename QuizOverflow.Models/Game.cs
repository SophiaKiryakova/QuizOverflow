using QuizOverflow.Models.Abstracts;

namespace QuizOverflow.Models
{
    public class Game : EntityBase
    {
        public DateTime DatePlayedOn { get; set; }
        List<GamePlayer> GamesPlayers { get; set; }
        List<GameQuestion> GamesQuestions { get; set; }
    }
}
