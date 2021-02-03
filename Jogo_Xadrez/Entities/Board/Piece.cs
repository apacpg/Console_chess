namespace Jogo_Xadrez.Entities.Board
{
    public abstract class Piece
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

        public void DecreaseMoveNumber()
        {
            movNumber--;
        }

        public abstract bool[,] PossibleMovements();

        public bool HasAvailableMovement()
        {
            bool[,] mat = PossibleMovements();
            for(int i = 0; i < mat.GetLength(0); i++)
            {
                for(int j = 0; j < mat.GetLength(1); j++)
                {
                    if (mat[i, j])
                        return true;
                }
            }

            return false;
        }

        public bool CanMoveToPosition(Position pos)
        {
            return PossibleMovements()[pos.Line, pos.Column];
        }
    }
}
