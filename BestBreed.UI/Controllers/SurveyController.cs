using BestBreed.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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

        public List<QuestionAnswerViewModel> GetQuestionAnswers()
        {

             string jsonContent = System.IO.File.ReadAllText("D:\\Visual Studio\\BestBreed\\BestBreed\\BestBreed.UI\\Questions\\Questions.json");

             List<QuestionAnswerViewModel> questionAnswers = JsonConvert.DeserializeObject<List<QuestionAnswerViewModel>>(jsonContent);

             return questionAnswers;

        }
    }
}
