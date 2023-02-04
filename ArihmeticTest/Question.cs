namespace ArihmeticTest
{
    public class Question
    {
        private string Text;
        private float Answer;

        public Question(string questionText, float questionAnswer)
        {
            Text = questionText;
            Answer = questionAnswer;
        }

        public override string ToString() => Text;
        public float GetAnswer() => Answer;

    }
}
