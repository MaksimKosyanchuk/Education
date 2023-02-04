using System;

namespace ArihmeticTest
{
    internal class QuestionGenerator
    {
        public static Question Generator(Level level)
        {
            Random rnd = new Random();
            int FirstNumber = rnd.Next(level.Min, level.Max);
            int SecondNumber = rnd.Next(level.Min, level.Max);
            int index = rnd.Next(level.Operands.Count);
            string Operand = level.Operands[index];
            float Answer;

            switch (Operand)
            {
                case "+":
                    Answer = FirstNumber + SecondNumber;
                    break;
                case "-":
                    Answer = FirstNumber - SecondNumber;
                    break;
                case "*":
                    Answer = FirstNumber * SecondNumber;
                    break;
                case "/":
                    Answer = FirstNumber / SecondNumber;
                    break;
                case "^":
                    SecondNumber = 2;
                    Answer = FirstNumber * FirstNumber;
                    break;
                case "%":
                    Answer = FirstNumber/100 * SecondNumber;
                    break;
                default:
                    Answer = 0;
                    break;
            }

            string QuestionText = $"{FirstNumber} {Operand} {SecondNumber}";

            return new Question(QuestionText, Answer);
        }
    }
}
