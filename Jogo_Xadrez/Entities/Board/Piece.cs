namespace Jogo_Xadrez.Entities.Board
{
    public class Piece
    {
        public Position position { get; set; }
        public Color color { get; protected set; }
        public int movNumber { get; protected set; }
        public GameBoard board { get; protected set; }

        public Piece(Color color, GameBoard board)
        {
            this.position = null;
            this.color = color;
            this.movNumber = 0;
            this.board = board;
        }

        public override string ToString()
        {
            return "p";
        }

        public void IncreaseMoveNumber()
        {
            this.movNumber++;
        }
    }
}
