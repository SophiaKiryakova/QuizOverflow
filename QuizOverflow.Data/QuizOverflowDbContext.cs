using Microsoft.EntityFrameworkCore;
using QuizOverflow.Models;

namespace QuizOverflow.Data
{
    public class QuizOverflowDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=QuizOverflowDb;Trusted_Connection=True;");
        }

        DbSet<Answer> Answers { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<HighScore> HighScores { get; set; }
        DbSet<Player> Players { get; set; }
        DbSet<Question> Questions { get; set; }
    }
}
