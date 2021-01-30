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

                    bool[,] possiblePositions = chessMatch.board.GetPiece(origin.ToPosition().Line, origin.ToPosition().Column).PossibleMovements();
                    
                    Console.Clear();
                    Screen.DisplayChessMatchInfo(chessMatch);
                    Screen.DisplayBoard(chessMatch.board, possiblePositions);

                    Console.WriteLine();

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
