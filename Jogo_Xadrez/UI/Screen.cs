﻿using Jogo_Xadrez.Entities.Board;
using Jogo_Xadrez.Entities.Chess;
using System;

namespace Jogo_Xadrez.UI
{
    public class Screen
    {
        public static void PrintChessMatch(ChessMatch match)
        {
            Console.Clear();

            DisplayChessMatchInfo(match);
            DisplayBoard(match.board);
            Console.WriteLine();
            DisplayCapturedPieces(match);
            if (match.check && !match.Finished)
            {
                Console.WriteLine();
                Console.WriteLine("You are in check!");
            }
            if (match.Finished)
            {
                Console.Clear();
                DisplayChessMatchInfo(match);
                DisplayBoard(match.board);
                Console.WriteLine();
                DisplayCapturedPieces(match);
                Console.WriteLine("CHECKMATE!");
                Console.WriteLine("WINNER: {0}", match.currentPlayer.ToString().ToUpper());
            }
        }

        public static void PrintChessMatch(ChessMatch match, bool[,] possiblePositions)
        {
            Console.Clear();

            DisplayChessMatchInfo(match);
            DisplayBoard(match.board, possiblePositions);
            Console.WriteLine();
            DisplayCapturedPieces(match);
            if (match.check)
            {
                Console.WriteLine();
                Console.WriteLine("You are in check!");
            }
        }

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

        public static void DisplayBoard(GameBoard board, bool[,] possiblePositions)
        {
            ConsoleColor backGroundCol = Console.BackgroundColor;
            ConsoleColor possibleMovCol = ConsoleColor.DarkGray;

            for (int i = 0; i < board.lines; i++)
            {
                Console.Write(board.lines - i + "| ");
                for (int j = 0; j < board.columns; j++)
                {
                    if(possiblePositions[i, j])
                    {
                        Console.BackgroundColor = possibleMovCol;
                    }
                    PrintPieceCharacter(board.GetPiece(i, j));
                    Console.BackgroundColor = backGroundCol;
                    Console.Write(" ");
                }
                Console.Write("\n");
            }

            for (int k = 0; k < 2; k++)
            {
                Console.Write("   ");

                for (int l = 0; l < board.columns; l++)
                {
                    if (k == 0)
                        Console.Write("__");
                    else
                        Console.Write(string.Format("{0} ", (char)('a' + l)));
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

        public static void DisplayCapturedPieces(ChessMatch match)
        {
            var blackPieces = match.CapturedPieces(Color.Black);
            var withePieces = match.CapturedPieces(Color.White);

            ConsoleColor basic = Console.ForegroundColor;
            

            Console.Write("White: ");
            foreach (Piece piece in withePieces)
                Console.Write(piece.ToString());
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Black: ");
            foreach (Piece piece in blackPieces)
                Console.Write(piece.ToString());
            Console.WriteLine();

            Console.ForegroundColor = basic;

            Console.WriteLine();
        }

        public static void DisplayChessMatchInfo(ChessMatch chessMatch)
        {
            Console.WriteLine(string.Format("Turn: {0}", chessMatch.turn));
            Console.Write(string.Format("Current player: "));
            
            ConsoleColor aux = Console.ForegroundColor;
            
            if(chessMatch.currentPlayer == Color.White)
                Console.Write(string.Format("White\n"));

            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Black\n");
                Console.ForegroundColor = aux;
            }

            Console.WriteLine();

        }

        public static ChessPosition ReadChessPosition()
        {
            string input = Console.ReadLine();
            input = input.Trim().ToLower();
            
            char column = input[0];
            int line = (int)char.GetNumericValue(input[1]);

            return new ChessPosition(line, column);
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
