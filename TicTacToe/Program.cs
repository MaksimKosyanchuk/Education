using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Media;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class Program
    {

        static Symbols symbols = new Symbols();

        static void Main(string[] args)
        {
            Console.WriteLine("TicTacToe by Maks");
            GamePlay();
        }

        private static void GamePlay()
        {
            for (int i = 0; i< 9; i++)
            {
                Move();
                if (CheckWin())
                {
                    symbols.ShowBoard();
                    Console.WriteLine($"Player {symbols.Player} won!");
                    Console.ReadLine();
                    return;
                }
                symbols.ShowBoard();
                ChangePlayer();
            }
            Draw();
        }

        public static void Move()
        {
            while (true)
            {
                var index = InputIndex();

                if (CheckCorrectIndex(index))
                {
                    return;
                }
            }
        }

        public static List<int> InputIndex()
        {
            while (true)
            {
                string[] IndexList;
                var NewIndexList = new List<int>();
                try
                {
                    Console.WriteLine($"Player {symbols.Player}, enter your index: ");
                    string UserIndex = Console.ReadLine();
                    IndexList = UserIndex.Split(' ');
                    for (int i = 0; i < IndexList.Length; i++)
                    {
                        NewIndexList.Add(Int32.Parse(IndexList[i]));
                    }
                    return NewIndexList;
                }
                catch
                {
                    Console.WriteLine("Error: Enter only integer!");
                }
            }
        }

        public static bool CheckCorrectIndex(List<int> index) 
        {
            int index_1 = index[0];
            int index_2 = index[1];
            int count_1 = 0;
            int count_2 = 0;
            for (int i = 1; i<4; i++)
            {
                if (index_1 == i)
                {
                    count_1++;
                }
                if (index_2 ==i)
                {
                    count_2++;
                }
            }
            if (count_1 == 0 && count_2 == 0) 
            {
                Console.WriteLine("Error: Enter integer in range 1-3!");
                return false;
            }
            index[0] -= 1;
            index[1] -= 1;
            return symbols.Fulling(index);
        }

        public static bool CheckWin()
        {
            List<List<string>> board = symbols.SymbolsList;
            int count = 0;
            for (int i = 0; i < board.Count; i++)
            {
                for (int j = 0; j < board[0].Count; j++)
                {
                    if (board[i][j] == board[i][0] && board[i][0] != " ")
                    {
                        count++;
                    }
                }
                if (count == 3)
                {
                    return true;
                }
                count = 0;
            }

            for (int i = 0; i < board.Count; i++)
            {
                for (int j = 0; j < board[0].Count; j++)
                {
                    if (board[j][i] == board[0][i] && board[0][i] != " ")
                    {
                        count++;
                    }
                }
                if (count == 3)
                {
                    return true;
                }
                count = 0;
            }

            for (int i = 0; i < board.Count; i++)
            {
                if (board[i][i] == board[0][0] && board[0][0] != " ")
                {
                    count++;
                }
            }
            if (count == 3)
            {
                return true;
            }

            count = 0;
            for (int i = 0; i < board.Count; i++)
            {
                int len = board[i].Count -1;
                if (board[i][len-i] == board[0][len] && board[0][len -i] != " ")
                {
                    count++;
                }
            }
            if (count == 3)
            {
                return true;
            }
            return false;
        }

        public static void ChangePlayer()
        {
            if (symbols.Player == "X")
            {
                symbols.Player = "0";
                return;
            }
            symbols.Player = "X";
        }

        public static void Draw()
        {
            Console.WriteLine("Draw!");
            Console.ReadLine();
        }
    }
}
