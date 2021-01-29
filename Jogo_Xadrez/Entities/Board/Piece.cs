namespace Jogo_Xadrez.Entities.Board
{
    public class Piece
    {
        public Position position { get; set; }
        public Color color { get; protected set; }
        public int movNumber { get; protected set; }
        public Board board { get; protected set; }

        public Piece(Position position, Color color, Board board)
        {
            this.position = position;
            this.color = color;
            this.movNumber = 0;
            this.board = board;
        }
    }
}
