using BestBreed.DataLayer.Enum;

namespace BestBreed.DataLayer.Entities
{
    public class Cat : BaseEntity
    {
        public Breeds Breed { get; set; }
        public string Description { get; set; }
        public string PhotoPath { get; set; }

        public virtual ICollection<Like>? Likes { get; set; }
        public virtual ICollection<SurveyResult>? SurveyResults { get; set; }
        public virtual ICollection<Comment>? Comments { get; set; }
    }
}
