namespace BestBreed.BusinessLogic.DtoModels
{
    public class CommentDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid CatId { get; set; }
        public string Text { get; set; }
    }
}