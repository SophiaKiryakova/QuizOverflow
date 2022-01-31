using Microsoft.EntityFrameworkCore;
using QuizOverflow.Data.Contracts;
using QuizOverflow.Models;

namespace QuizOverflow.Services.Services
{
    internal class PlayerService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PlayerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CreatePlayer(string playerName)
        {
            var player = new Player
            {
                Name = playerName
            };

            _unitOfWork.PlayerRepository.Create(player);
        }

        public async Task<Player> GetPlayer(string playerName)
        {
            var player = await _unitOfWork.PlayerRepository
                .GetWhere(p => p.Name == playerName)
                .FirstOrDefaultAsync();

            return player;
        }
    }
}
