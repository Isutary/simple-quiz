using System.Collections.Generic;

namespace FormsApp
{
    class Question
    {
        public string QuestionText { get; }
        public List<string> Answers { get; }
        public int CorrectAnswer { get; }
        public Question(string QuestionText, List<string> Answers, int CorrectAnswer)
        {
            this.QuestionText = QuestionText;
            this.Answers = Answers;
            this.CorrectAnswer = CorrectAnswer;
        }
    }
}
