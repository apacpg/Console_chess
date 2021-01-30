using Jogo_Xadrez.Entities.Chess;
using Jogo_Xadrez.UI;
using System;

namespace Jogo_Xadrez
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ChessMatch chessMatch = new ChessMatch();

                while (!chessMatch.Finished)
                {
                    Screen.DisplayChessMatchInfo(chessMatch);
                    Screen.DisplayBoard(chessMatch.board);

                    Console.WriteLine();

                    Console.Write("Which piece to move: ");
                    ChessPosition origin = Screen.ReadChessPosition();
                    
                    Console.Write("To which position: ");
                    ChessPosition destination = Screen.ReadChessPosition();

                    chessMatch.ExcecuteMovement(origin.ToPosition(), destination.ToPosition());

                    Console.Clear();
                }
            }
            catch
            {

            }

        }
    }
}
