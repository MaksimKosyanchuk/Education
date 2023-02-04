using System.Collections.Generic;

namespace ArihmeticTest
{
    public class Level
    {
        public int Min;
        public int Max;
        public List<string> Operands;

        public Level(int min, int max, List<string> operands) 
        {
            Min = min;
            Max = max;
            Operands = operands;
        }
    }
}
