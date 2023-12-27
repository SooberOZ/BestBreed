using BestBreed.UI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BestBreed.UI.Controllers
{
    [Route("Survey")]
    public class SurveyController : Controller
    {
        [Route("Index")]
        public IActionResult Index()
        {
            List<QuestionAnswerViewModel> questionAnswers = GetQuestionAnswers();

            return View(questionAnswers);
        }

        private List<QuestionAnswerViewModel> GetQuestionAnswers()
        {
            List<QuestionAnswerViewModel> questionAnswers = new List<QuestionAnswerViewModel>
        {
            new QuestionAnswerViewModel
            {
                QuestionNumber = 1,
                QuestionText = "Какая характеристика важнее для вас?",
                PossibleAnswers = new List<string> { "Внешний вид", "Характер", "Размер", "Уход" },
                SelectedAnswer = 0
            },
        };

            return questionAnswers;
        }
    }
}
