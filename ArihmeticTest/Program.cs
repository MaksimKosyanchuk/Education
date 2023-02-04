using System;
using System.Collections.Generic;

namespace ArihmeticTest
{
    internal class Program
    {
        private static Level FirstLevel;
        private static Level SecondLevel;
        private static Level ThirdLevel;

        static void Main(string[] args)
        {
            LevelsSpawner();
            var CurrentLevel = InputLevelNumber();
            QuestionHandler.Handler(CurrentLevel);
        }

        private static Level InputLevelNumber()
        {
            string level;
            while (true)
            {
                Console.WriteLine("Enter the number level(1-3):");
                level = Console.ReadLine().Trim();
                if (level != "1" && level != "2" && level != "3")
                {
                    Console.WriteLine("Error!");
                    continue;
                }
                break;
            }
            switch (level)
            {
                case "1":
                    return FirstLevel;
                case "2":
                    return SecondLevel;
                case "3":
                    return ThirdLevel;
                default:
                    return FirstLevel;
            }
        }

        private static void LevelsSpawner()
        {
            FirstLevel = new Level(2, 9, new List<string>() { "+", "-", "*"});
            SecondLevel = new Level(11, 29, new List<string>() { "^" });
            ThirdLevel = new Level(2, 9, new List<string>() { "/", "%" });
        }
    }
}
