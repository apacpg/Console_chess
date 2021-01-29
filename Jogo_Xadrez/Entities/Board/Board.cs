namespace Jogo_Xadrez.Entities.Board
{
    public class Board
    {
        public int lines { get; protected set; }
        public int columns { get; protected set; }
        
        private Piece[,] pieces;

        public Board(int lines, int columns)
        {
            this.lines = lines;
            this.columns = columns;
            this.pieces = new Piece[this.lines, this.columns];
        }
    }
}
