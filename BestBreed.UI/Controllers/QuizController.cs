using BestBreed.BusinessLogic.DtoModels;
using BestBreed.BusinessLogic.Interface;
using BestBreed.DataLayer.Entities;
using BestBreed.UI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BestBreed.UI.Controllers
{
    public class QuizController : Controller
    {
        private readonly ISurveyService _surveyService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SurveyController _surveyController;

        public QuizController(ISurveyService surveyService, UserManager<ApplicationUser> userManager, SurveyController surveyController)
        {
            _surveyService = surveyService;
            _userManager = userManager;
            _surveyController = surveyController;
        }

        public async Task<IActionResult> Index()
        {
            var questions = _surveyController.GetQuestionAnswers();
            return View(questions);
        }

        [HttpPost]
        public async Task<IActionResult> SubmitSurvey(List<QuestionAnswerViewModel> viewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);

                // Тут добавьте логику для обработки ответов пользователя

                // Ваш код ...

                return RedirectToAction("SurveyResult", new { /* ... */ });
            }

            return View("Index", viewModel);
        }


        public async Task<IActionResult> SurveyResult(Guid surveyResultId)
        {
            var surveyResultDto = await _surveyService.GetSurveyResultByIdAsync(surveyResultId);
            var surveyResultViewModel = new SurveyViewModel { SurveyResult = surveyResultDto };

            return View(surveyResultViewModel);
        }
    }
}
