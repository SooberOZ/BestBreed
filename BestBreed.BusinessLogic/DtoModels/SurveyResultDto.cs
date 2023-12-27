namespace BestBreed.BusinessLogic.DtoModels
{
    public class SurveyResultDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid CatId { get; set; }
        public bool IsSurveyCompleted { get; set; }
        public Dictionary<int, int> QuestionAnswers { get; set; }
    }
}