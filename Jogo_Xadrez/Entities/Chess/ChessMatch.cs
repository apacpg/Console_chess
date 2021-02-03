using Jogo_Xadrez.Entities.Board;
using System.Collections.Generic;

namespace Jogo_Xadrez.Entities.Chess
{
    public class ChessMatch
    {
        public GameBoard board { get; private set; }
        public int turn { get; private set; }
        public Color currentPlayer { get; private set; }
        public bool Finished { get; private set; }
        private HashSet<Piece> pieces;
        private HashSet<Piece> captured;

        public ChessMatch()
        {
            this.board = new GameBoard(8, 8);
            this.pieces = new HashSet<Piece>();
            this.captured = new HashSet<Piece>();
            this.turn = 1;
            this.Finished = false;
            this.currentPlayer = Color.White;
            SetUpBoard();
        }

        public void ExcecuteMovement(Position origin, Position destination)
        {
            if(board.ExistPiece(origin) && board.GetPiece(origin).color == currentPlayer)
            {
                Piece piece = board.GetPiece(origin);
                if (CanMove(piece, destination))
                {
                    piece = board.RemovePiece(origin);
                    Piece capturedPiece = board.RemovePiece(destination);
                    if (capturedPiece != null)
                        captured.Add(capturedPiece);
                    board.PlacePiece(piece, destination);
                    piece.IncreaseMoveNumber();
                }
            }
        }

        public void ExcecutePlay(Position origin, Position destination)
        {
            ExcecuteMovement(origin, destination);
            NextTurn();
        }

        private bool CanMove(Piece piece , Position destination)
        {
            if (piece.PossibleMovements()[destination.Line, destination.Column])
                return true;

            return false;
        }

        public void ValidOriginPosition(Position pos)
        {
            if (board.GetPiece(pos) == null)
                throw new BoardException("There is no piece at the selected position.");
            if (board.GetPiece(pos).color != currentPlayer)
                throw new BoardException("This piece doesnt belong to you.");
            if (!board.GetPiece(pos).HasAvailableMovement())
                throw new BoardException("This piece cannot move.");
        }

        public void ValidDestinationPosition(Position origin, Position destination)
        {
            if (!board.GetPiece(origin).CanMoveToPosition(destination))
                throw new BoardException("Invalid position for the piece");
        }

        private void NextTurn()
        {
            turn++;

            if (currentPlayer == Color.White)
                currentPlayer = Color.Black;
            else
                currentPlayer = Color.White;
        }

        private void SetUpBoard()
        {
            PlacePieces(Color.White);
            PlacePieces(Color.Black);
        }
        
        public HashSet<Piece> CapturedPieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach(Piece x in captured)
            {
                if(x.color == color)
                {
                    aux.Add(x);
                }
            }

            return aux;
        }

        public HashSet<Piece> PiecesInGame(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in pieces)
            {
                if (x.color == color)
                {
                    aux.Add(x);
                }
            }

            aux.ExceptWith(CapturedPieces(color));

            return aux;
        }

        private void PlacePiece(char column, int line, Piece piece)
        {
            board.PlacePiece(piece, new ChessPosition(line, column).ToPosition());
            pieces.Add(piece);
        }

        private void PlacePieces(Color piecesColor)
        {
            if(piecesColor == Color.Black)
            {
                PlacePiece('a', 8, new Tower(piecesColor, board));
                PlacePiece('b', 8, new Horse(piecesColor, board));
                PlacePiece('c', 8, new Bishop(piecesColor, board));
                PlacePiece('d', 8, new King(piecesColor, board));
                PlacePiece('e', 8, new Queen(piecesColor, board));
                PlacePiece('f', 8, new Bishop(piecesColor, board));
                PlacePiece('g', 8, new Horse(piecesColor, board));
                PlacePiece('h', 8, new Tower(piecesColor, board));
                
                for (int j = 0; j < board.columns; j++)
                    PlacePiece((char)('a' + j), 7, new Pawn(piecesColor, board));
            }
            else
            {
                PlacePiece('a', 1, new Tower(piecesColor, board));
                PlacePiece('b', 1, new Horse(piecesColor, board));
                PlacePiece('c', 1, new Bishop(piecesColor, board));
                PlacePiece('d', 1, new King(piecesColor, board));
                PlacePiece('e', 1, new Queen(piecesColor, board));
                PlacePiece('f', 1, new Bishop(piecesColor, board));
                PlacePiece('g', 1, new Horse(piecesColor, board));
                PlacePiece('h', 1, new Tower(piecesColor, board));

                for (int j = 0; j < board.columns; j++)
                    PlacePiece((char)('a' + j), 2, new Pawn(piecesColor, board));
            }
        }
    }
}
