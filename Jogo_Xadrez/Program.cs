using Jogo_Xadrez.Entities.Board;
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
                    try
                    {
                        Console.Clear();

                        Screen.PrintChessMacth(chessMatch);

                        Console.Write("Which piece to move: ");
                        ChessPosition origin = Screen.ReadChessPosition();

                        chessMatch.ValidOriginPosition(origin.ToPosition());

                        bool[,] possiblePositions = chessMatch.board.GetPiece(origin.ToPosition().Line, origin.ToPosition().Column).PossibleMovements();

                        Screen.PrintChessMacth(chessMatch, possiblePositions);

                        Console.Write("To which position: ");
                        ChessPosition destination = Screen.ReadChessPosition();

                        chessMatch.ValidDestinationPosition(origin.ToPosition(), destination.ToPosition());

                        chessMatch.ExcecutePlay(origin.ToPosition(), destination.ToPosition());

                    }
                    catch (BoardException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.Write("Press ENTER to continue");
                        Console.ReadLine();
                    }

                }
            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
