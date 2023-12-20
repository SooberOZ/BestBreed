using BestBreed.DataLayer.Enum;

namespace BestBreed.BusinessLogic.DtoModels
{
    public class CatDto
    {
        public Guid Id { get; set; }
        public Breeds Breed { get; set; }
        public string Description { get; set; }
        public string PhotoPath { get; set; }
    }
}