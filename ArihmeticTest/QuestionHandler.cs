using System;

namespace ArihmeticTest
{
    public class QuestionHandler
    {
        public static void Handler(Level level)
        {
            UserAnswer Answer= new UserAnswer();
            Answer.Start = DateTime.Now;

            for (int i = 1; i < 6; i++)
            {
                Question Question = QuestionGenerator.Generator(level);
                bool iterator = true;
                while (iterator)
                {
                    Console.WriteLine(Question.ToString());
                    string UserAnswer = Console.ReadLine().Trim();
                    if (float.TryParse(UserAnswer, out float answer))
                    {
                        iterator = false;
                        if (answer == Question.GetAnswer())
                        {
                            Answer.NumberAnswer += 1;
                            Console.WriteLine("Correct!");
                        }
                        else
                        {
                            Console.WriteLine("InCorrect Answer!");
                        }
                    }
                    else
                        Console.WriteLine("Input only float or numbers");
                }
            }
            Answer.End = DateTime.Now;
            Answer.Time = (Answer.Start - Answer.End).ToString().Substring(1, 8);
            Console.WriteLine($"Number of your ccorrect answer: {Answer.NumberAnswer}!");
            if (DoYouWantToSave())
            {
                FileSaver.SaveFile(Answer);
            }
        }

        private static bool DoYouWantToSave()
        {
            while (true)
            {
                Console.WriteLine("Do you want to save a result to file?");
                string UserChoice = Console.ReadLine().ToLower();
                if (UserChoice == "y" || UserChoice == "yes")
                {
                    return true;
                }
                else if (UserChoice == "n" || UserChoice == "no")
                {
                    return false;
                }
                Console.WriteLine("Enter 'yes' or 'no'");
            }
        }
    }
}
