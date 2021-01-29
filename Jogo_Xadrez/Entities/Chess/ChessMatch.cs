using Jogo_Xadrez.Entities.Board;
using Jogo_Xadrez.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jogo_Xadrez.Entities.Chess
{
    public class ChessMatch
    {
        public GameBoard board { get; private set; }
        private int turn;
        private Color currentPlayer;

        public ChessMatch()
        {
            this.board = new GameBoard(8, 8);
            SetUpBoard();
            this.turn = 1;
            this.currentPlayer = Color.White;
        }

        public void ExcecuteMovement(Position origin, Position destination)
        {
            if(board.ExistPiece(origin) && board.GetPiece(origin).color == currentPlayer)
            {
                Piece piece = board.RemovePiece(origin);
                Piece capturedPiece = board.RemovePiece(destination);
                board.PlacePiece(piece, destination);
                piece.IncreaseMoveNumber();


                turn++;
                currentPlayer = Color.Black;
            }
        }

        private void SetUpBoard()
        {
            PlacePieces(Color.White);
            PlacePieces(Color.Black);
        }

        private void PlacePieces(Color piecesColor)
        {
            if(piecesColor == Color.Black)
            {
                board.PlacePiece(new Tower(piecesColor, board), new ChessPosition(8, 'a').ToPosition());
                board.PlacePiece(new Horse(piecesColor, board), new ChessPosition(8, 'b').ToPosition());
                board.PlacePiece(new Bishop(piecesColor, board), new ChessPosition(8, 'c').ToPosition());
                board.PlacePiece(new King(piecesColor, board), new ChessPosition(8, 'd').ToPosition());
                board.PlacePiece(new Queen(piecesColor, board), new ChessPosition(8, 'e').ToPosition());
                board.PlacePiece(new Bishop(piecesColor, board), new ChessPosition(8, 'f').ToPosition());
                board.PlacePiece(new Horse(piecesColor, board), new ChessPosition(8, 'g').ToPosition());
                board.PlacePiece(new Tower(piecesColor, board), new ChessPosition(8, 'h').ToPosition());

                for (int j = 0; j < board.columns; j++)
                    board.PlacePiece(new Pawn(piecesColor, board), new ChessPosition(7, (char)('a' + j)).ToPosition());
            }
            else
            {
                board.PlacePiece(new Tower(piecesColor, board), new ChessPosition(1, 'a').ToPosition());
                board.PlacePiece(new Horse(piecesColor, board), new ChessPosition(1, 'b').ToPosition());
                board.PlacePiece(new Bishop(piecesColor, board), new ChessPosition(1, 'c').ToPosition());
                board.PlacePiece(new Queen(piecesColor, board), new ChessPosition(1, 'd').ToPosition());
                board.PlacePiece(new King(piecesColor, board), new ChessPosition(1, 'e').ToPosition());
                board.PlacePiece(new Bishop(piecesColor, board), new ChessPosition(1, 'f').ToPosition());
                board.PlacePiece(new Horse(piecesColor, board), new ChessPosition(1, 'g').ToPosition());
                board.PlacePiece(new Tower(piecesColor, board), new ChessPosition(1, 'h').ToPosition());

                for (int j = 0; j < board.columns; j++)
                    board.PlacePiece(new Pawn(piecesColor, board), new ChessPosition(2, (char)('a' + j)).ToPosition());
            }
        }
    }
}
