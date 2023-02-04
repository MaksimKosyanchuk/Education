using System;
using System.IO;

namespace ArihmeticTest
{
    public class FileSaver
    {
        public static void SaveFile(UserAnswer Answer)
        {
            var UserName = InputUserName();
            StreamWriter sr = new StreamWriter("Results.txt");
            var text = $"({Answer.Time}) {UserName}: Your number of correct answers: {Answer.NumberAnswer} (Start: {Answer.Start}, End: {Answer.End})";
            sr.WriteLine(text);
            sr.Close();
            Console.WriteLine("Save done!");
        }

        private static string InputUserName()
        {
            Console.WriteLine("Enter your name: ");
            return Console.ReadLine().Trim();
        }
    }
}
