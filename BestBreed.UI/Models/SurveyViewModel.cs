using BestBreed.BusinessLogic.DtoModels;

namespace BestBreed.UI.Models
{
    public class SurveyViewModel
    {
        public List<SurveyResultDto> Questions { get; set; }
        public Dictionary<int, int> Answers { get; set; }
        public SurveyResultDto SurveyResult { get; set; }
    }
}