using BestBreed.BusinessLogic.DtoModels;

namespace BestBreed.BusinessLogic.Interface
{
    public interface ISurveyService
    {
        Task StartSurveyAsync(Guid userId, Guid catId);
        Task<SurveyResultDto> GetSurveyResultByIdAsync(Guid surveyResultId);
        Task<List<SurveyResultDto>> GetSurveyQuestionsAsync();
        Task<SurveyResultDto> ProcessSurveyResultsAsync(UserSurveyAnswer userSurveyAnswer);
    }
}