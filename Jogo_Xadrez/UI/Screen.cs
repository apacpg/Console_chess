using Jogo_Xadrez.Entities.Board;
using System;

namespace Jogo_Xadrez.UI
{
    public class Screen
    {
        public static void DisplayBoard(Board board)
        {
            for(int i = 0; i < board.lines; i++)
            {
                for(int j = 0; j < board.columns; j++)
                {
                    string character = GetPieceCharacter(board.GetPiece(i,j));
                    Console.Write("{0} ", character);
                }
                Console.Write("\n");
            }
        }

        private static string GetPieceCharacter(Piece piece)
        {
            if (piece == null)
                return "-";
            else
            {
                return piece.ToString();
            }
        }
    }
}
