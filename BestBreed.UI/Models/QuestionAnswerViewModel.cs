namespace BestBreed.UI.Models
{
    public class QuestionAnswerViewModel
    {
        public int QuestionNumber { get; set; }
        public string QuestionText { get; set; }
        public List<string> PossibleAnswers { get; set; }
        public int SelectedAnswer { get; set; }
    }
}