using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Symbols
    {
        public string Player = "X";

        public List<List<string>> SymbolsList = new List<List<string>>();

        public string board;

        public Symbols()
        {
            List<string> symbols_1 = new List<string>();
            List<string> symbols_2 = new List<string>();
            List<string> symbols_3 = new List<string>();


            symbols_1.Add(" ");
            symbols_1.Add(" ");
            symbols_1.Add(" ");

            symbols_2.Add(" ");
            symbols_2.Add(" ");
            symbols_2.Add(" ");

            symbols_3.Add(" ");
            symbols_3.Add(" ");
            symbols_3.Add(" ");
            SymbolsList.Add(symbols_1);
            SymbolsList.Add(symbols_2);
            SymbolsList.Add(symbols_3);

            ShowBoard();
        }

        public bool Fulling(List<int> index)
        {
            if (SymbolsList[index[0]][index[1]] != " ")
            {
                Console.WriteLine("Error: This index is busy!");
                return false;
            }
            SymbolsList[index[0]][index[1]] = Player;
            return true;
        }

        public void ShowBoard()
        {
            board = $"┌─────┬─────┬─────┐\r\n│  {SymbolsList[0][0]}  │  {SymbolsList[0][1]}  │  {SymbolsList[0][2]}  │\r\n├─────┼─────┼─────┤\r\n│  {SymbolsList[1][0]}  │  {SymbolsList[1][1]}  │  {SymbolsList[1][2]}  │\r\n├─────┼─────┼─────┤\r\n│  {SymbolsList[2][0]}  │  {SymbolsList[2][1]}  │  {SymbolsList[2][2]}  │\r\n└─────┴─────┴─────┘";
            Console.WriteLine(board);
        }
    }

}
