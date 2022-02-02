using QuizOverflow.Data.Contracts;
using QuizOverflow.Models;

namespace QuizOverflow.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IQuizOverflowDbContext _context;

        private IGenericRepository<Answer> _answerRepository;
        private IGenericRepository<Category> _categoryRepository;
        private IGenericRepository<HighScore> _highScoreRepository;
        private IGenericRepository<Player> _playerRepository;
        private IGenericRepository<Question> _questionRepository;
        private IGenericRepository<Game> _gameRepository;

        public UnitOfWork(IQuizOverflowDbContext context)
        {
            _context = context;
        }

        public IGenericRepository<Answer> AnswerRepository
        {
            get { return _answerRepository ?? (_answerRepository = new GenericRepository<Answer>(_context)); }
        }

        public IGenericRepository<Category> CategoryRepository
        {
            get { return _categoryRepository ?? (_categoryRepository = new GenericRepository<Category>(_context)); }
        }

        public IGenericRepository<HighScore> HighScoresRepository
        {
            get { return _highScoreRepository ?? (_highScoreRepository = new GenericRepository<HighScore>(_context)); }
        }

        public IGenericRepository<Player> PlayerRepository
        {
            get { return _playerRepository ?? (_playerRepository = new GenericRepository<Player>(_context)); }
        }

        public IGenericRepository<Question> QuestionRepository
        {
            get { return _questionRepository ?? (_questionRepository = new GenericRepository<Question>(_context)); }
        }

        public IGenericRepository<Game> GameRepository
        {
            get { return _gameRepository ?? (_gameRepository = new GenericRepository<Game>(_context)); }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
