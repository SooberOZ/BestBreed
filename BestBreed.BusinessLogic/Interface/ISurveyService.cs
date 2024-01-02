using BestBreed.BusinessLogic.DtoModels;

namespace BestBreed.BusinessLogic.Interface
{
    public interface ISurveyService
    {
        List<SurveyQuestionModel> LoadSurveyQuestionsFromJson(string jsonFilePath);
        Task StartSurveyAsync(Guid userId);
        Task<SurveyResultDto> GetSurveyResultByIdAsync(Guid surveyResultId);
        Task<List<SurveyResultDto>> GetSurveyQuestionsAsync(Guid userId);
        Task<SurveyResultDto> ProcessSurveyResultsAsync(SurveyResultDto userSurveyResult);
        Task SaveSurveyResultAsync(SurveyResultDto surveyResultDto);
    }
}