using QuizOverflow.Models;

namespace QuizOverflow.Data.Contracts
{
    public interface IUnitOfWork
    {
        IGenericRepository<Answer> AnswerRepository { get; }
        IGenericRepository<Category> CategoryRepository { get; }
        IGenericRepository<HighScore> HighScoresRepository { get; }
        IGenericRepository<Player> PlayerRepository { get; }
        IGenericRepository<Question> QuestionRepository { get; }
    }
}
