using AutoMapper;
using BestBreed.BusinessLogic.DtoModels;
using BestBreed.BusinessLogic.Interface;
using BestBreed.Contracts;
using BestBreed.DataLayer;
using BestBreed.DataLayer.Entities;
using Newtonsoft.Json;

namespace BestBreed.BusinessLogic
{
    public class SurveyService : ISurveyService
    {
        private readonly IRepository<SurveyResult> _surveyResultRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<BestBreedContext> _unitOfWork;

        public SurveyService(
            IRepository<SurveyResult> surveyResultRepository,
            IMapper mapper,
            IUnitOfWork<BestBreedContext> unitOfWork)
        {
            _surveyResultRepository = surveyResultRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public List<SurveyQuestionModel> LoadSurveyQuestionsFromJson(string jsonFilePath)
        {
            var json = File.ReadAllText(jsonFilePath);
            return JsonConvert.DeserializeObject<List<SurveyQuestionModel>>(json);
        }

        public async Task StartSurveyAsync(Guid userId)
        {
            var questions = await GetSurveyQuestionsAsync(userId);

            var surveyResult = new SurveyResult
            {
                UserId = userId,
                IsSurveyCompleted = false,
                QuestionAnswers = questions.First().QuestionAnswers
            };

            await _surveyResultRepository.AddAsync(surveyResult);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<SurveyResultDto>> GetSurveyQuestionsAsync(Guid userId)
        {
            return await GetSurveyQuestionsAsync(userId);
        }

        public async Task<SurveyResultDto> GetSurveyResultByIdAsync(Guid surveyResultId)
        {
            var surveyResultEntity = await _surveyResultRepository.GetByIdAsync(surveyResultId);
            return _mapper.Map<SurveyResultDto>(surveyResultEntity);
        }

        public async Task<SurveyResultDto> ProcessSurveyResultsAsync(SurveyResultDto userSurveyResult)
        {
            //TODO: сделать логику 

            return userSurveyResult;
        }

        private async Task AskQuestionAsync(string questionText, SurveyResult surveyResult)
        {
            int answerId = await GetUserAnswerAsync(questionText);

            surveyResult.QuestionAnswers.Add(surveyResult.QuestionAnswers.Count + 1, answerId);
        }

        private async Task<int> GetUserAnswerAsync(string questionText)
        {
            Console.WriteLine(questionText);
            Console.WriteLine("1. Вариант ответа 1");
            Console.WriteLine("2. Вариант ответа 2");
            Console.Write("Выберите номер ответа: ");

            int selectedAnswer = int.Parse(Console.ReadLine());

            return selectedAnswer;
        }

        public async Task SaveSurveyResultAsync(SurveyResultDto surveyResultDto)
        {
            var surveyResultEntity = _mapper.Map<SurveyResult>(surveyResultDto);

            await _surveyResultRepository.AddAsync(surveyResultEntity);

            await _unitOfWork.SaveChangesAsync();
        }
    }

}