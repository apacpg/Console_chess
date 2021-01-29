using Jogo_Xadrez.Entities.Board;
using System;

namespace Jogo_Xadrez.UI
{
    public class Screen
    {
        public static void DisplayBoard(GameBoard board)
        {
            for(int i = 0; i < board.lines; i++)
            {
                Console.Write(board.lines - i + "| ");
                for(int j = 0; j < board.columns; j++)
                {
                    PrintPieceCharacter(board.GetPiece(i,j));
                    Console.Write(" ");
                }
                Console.Write("\n");
            }

            for(int k = 0; k < 2; k++)
            {
                Console.Write("   ");

                for(int l = 0; l < board.columns; l++)
                {
                    if (k == 0)
                        Console.Write("__");
                    else
                        Console.Write(string.Format("{0} ",(char)('a' + l)));
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            ConsoleColor aux = Console.ForegroundColor;
            Console.Write(string.Format("    White | "));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Black");
            Console.ForegroundColor = aux;

            Console.WriteLine();
        }

        private static void PrintPieceCharacter(Piece piece)
        {
            if (piece == null)
                Console.Write("-");
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                
                if(piece.color == Color.Black)
                    Console.ForegroundColor = ConsoleColor.Green;
                
                Console.Write(piece);
                Console.ForegroundColor = aux;
            }
        }
    }
}
