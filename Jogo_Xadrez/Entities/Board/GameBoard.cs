namespace Jogo_Xadrez.Entities.Board
{
    public class GameBoard
    {
        public int lines { get; protected set; }
        public int columns { get; protected set; }
        
        private Piece[,] pieces;

        public GameBoard(int lines, int columns)
        {
            this.lines = lines;
            this.columns = columns;
            this.pieces = new Piece[this.lines, this.columns];
        }

        public Piece GetPiece(int line, int column)
        {
            return pieces[line, column];
        }

        public Piece GetPiece(Position pos)
        {
             
            return pieces[pos.Line, pos.Column];
        }

        public bool ExistPiece(Position pos)
        {
            ValidatePosition(pos);
            return GetPiece(pos) != null;
        }

        public bool ValidPosition(Position pos)
        {
            if (pos.Column < 0 || pos.Column > (this.columns - 1) || pos.Line < 0 || pos.Line > (this.lines - 1))
                return false;

            return true;
        }

        public void ValidatePosition(Position pos)
        {
            if (!ValidPosition(pos))
                throw new BoardException("Invalid position!");
        }

        public void PlacePiece(Piece piece, Position pos)
        {
            if (ExistPiece(pos))
                throw new BoardException("There is already a piece in this position!");

            pieces[pos.Line, pos.Column] = piece;
            piece.position = pos;
        }
    }
}
