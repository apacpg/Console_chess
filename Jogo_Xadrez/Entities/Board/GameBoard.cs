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

        public void PlacePiece(Piece piece, Position pos)
        {
            pieces[pos.Line, pos.Column] = piece;
            piece.position = pos;
        }
    }
}
