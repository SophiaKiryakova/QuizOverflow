namespace QuizOverflow.DTO
{
    public class QuestionDto : DtoBase
    {
        public string? Name { get; set; }
        public int Points { get; set; }
        public int CategoryId { get; set; }
        public IEnumerable<AnswerDto>? Answers { get; set; }
    }
}