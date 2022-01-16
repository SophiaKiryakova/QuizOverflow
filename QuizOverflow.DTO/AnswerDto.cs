namespace QuizOverflow.DTO
{
    public class AnswerDto : DtoBase
    {
        public string? Name { get; set; }
        public bool IsCorrect { get; set; }

        public int QuestionId { get; set; }
        public QuestionDto? Question { get; set; }
    }
}
