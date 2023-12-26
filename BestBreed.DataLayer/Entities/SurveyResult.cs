namespace BestBreed.DataLayer.Entities
{
    public class SurveyResult : BaseEntity
    {
        public Guid UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public Dictionary<int, int> QuestionAnswers { get; set; } = new Dictionary<int, int>();
        public bool IsSurveyCompleted { get; set; }


        public Guid CatId { get; set; }
        public virtual Cat Cat { get; set; }
    }
}
