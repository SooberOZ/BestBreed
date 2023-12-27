using BestBreed.BusinessLogic;
using BestBreed.BusinessLogic.Interface;
using BestBreed.UI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BestBreed.UI.Controllers
{
    public class QuizController : Controller
    {
        private readonly ISurveyService _surveyService;

        public QuizController(ISurveyService surveyService)
        {
            _surveyService = surveyService;
        }

        public IActionResult Index()
        {
            // Загружаем вопросы для опроса
            var questions = _surveyService.GetSurveyQuestions();
            var viewModel = new SurveyViewModel { Questions = questions };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> SubmitSurvey(SurveyViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                // Обработка ответов пользователя
                var surveyResult = _surveyService.ProcessSurveyResults(viewModel.Answers);

                // Сохраняем результат опроса в базу данных
                await _surveyService.SaveSurveyResult(surveyResult);

                // Перенаправляем пользователя на страницу с результатами
                return RedirectToAction("SurveyResult", new { surveyResultId = surveyResult.Id });
            }

            // Если модель недействительна, возвращаем пользователя на страницу опроса
            return View("Index", viewModel);
        }

        public IActionResult SurveyResult(Guid surveyResultId)
        {
            // Загружаем результат опроса для отображения
            var surveyResultDto = _surveyService.GetSurveyResultByIdAsync(surveyResultId);
            var surveyResultViewModel = new SurveyResultViewModel { SurveyResult = surveyResultDto };

            return View(surveyResultViewModel);
        }
    }
}
