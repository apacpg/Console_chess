using Jogo_Xadrez.Entities.Board;

namespace Jogo_Xadrez.Entities.Chess
{
    public class King : Piece
    {
        public King(Color color, GameBoard board) : base(color, board) { }

        public override string ToString()
        {
            return "K";
        }

        private bool CanMove(Position pos)
        {
            Piece possDestination = board.GetPiece(pos);
            
            if (possDestination == null)
                return true;

            if (possDestination.color != this.color)
                return true;
            else
                return false;
        }

        public override bool[,] PossibleMovements()
        {
            bool[,] movements = new bool[board.lines, board.columns];

            int top, botton, left, right;
            
            top = this.position.Line - 1;
            botton = this.position.Line + 1;
            left = this.position.Column - 1;
            right = this.position.Column + 1;

            for (int i = top; i < botton  + 1; i++)
            {
                for(int j = left; j < right; j++)
                {
                    Position pos = new Position(i, j);
                    if (board.ValidPosition(pos) && CanMove(pos))
                    {
                        movements[i, j] = true;
                    }
                }
            }
            
            return movements;
        }
    }
}
