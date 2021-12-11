using QuizOverflow.Models.Abstracts;

namespace QuizOverflow.Models
{
    public class Category : EntityBase
    {
        public string? Name { get; set; }
        public IEnumerable<Question>? Questions { get; set; }

    }
}
