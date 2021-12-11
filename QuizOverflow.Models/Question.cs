using QuizOverflow.Models.Abstracts;

namespace QuizOverflow.Models
{
    public class Question : EntityBase
    {
        public string? Name { get; set; }
        public int Points { get; set; }

        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        public IEnumerable<Answer>? Answers { get; set; }
    }
}
