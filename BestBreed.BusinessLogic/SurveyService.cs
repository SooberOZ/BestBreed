using AutoMapper;
using BestBreed.BusinessLogic.DtoModels;
using BestBreed.BusinessLogic.Interface;
using BestBreed.Contracts;
using BestBreed.DataLayer.Entities;

namespace BestBreed.BusinessLogic
{
    public class SurveyService : ISurveyService
    {
        private readonly IRepository<SurveyResult> _surveyResultRepository;
        private readonly IMapper _mapper;

        public SurveyService(IRepository<SurveyResult> surveyResultRepository, IMapper mapper)
        {
            _surveyResultRepository = surveyResultRepository;
            _mapper = mapper;
        }

        public async Task StartSurveyAsync(Guid userId, Guid catId)
        {
            var surveyResult = new SurveyResult
            {
                UserId = userId,
                CatId = catId,
                IsSurveyCompleted = false
            };

            await AskQuestionAsync("Какой цвет вам нравится больше всего?", surveyResult);
            await AskQuestionAsync("Какой характер у вас?", surveyResult);

            surveyResult.IsSurveyCompleted = true;

            await _surveyResultRepository.AddAsync(surveyResult);
        }

        public async Task<SurveyResultDto> GetSurveyResultByIdAsync(Guid surveyResultId)
        {
            var surveyResultEntity = await _surveyResultRepository.GetByIdAsync(surveyResultId);
            return _mapper.Map<SurveyResultDto>(surveyResultEntity);
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
    }
}