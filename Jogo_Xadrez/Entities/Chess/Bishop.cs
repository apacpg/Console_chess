using Jogo_Xadrez.Entities.Board;

namespace Jogo_Xadrez.Entities.Chess
{
    public class Bishop : Piece
    {
        public Bishop(Color color, GameBoard board) : base(color, board) { }

        private bool CanMove(Position pos)
        {
            Piece possDestination = board.GetPiece(pos);

            if (possDestination == null)
                return true;

            return false;
        }

        public override bool[,] PossibleMovements()
        {
            bool[,] movements = new bool[board.lines, board.columns];
            Position pos = new Position(this.position.Line, this.position.Column);

            // Top right
            pos.SetValues(this.position.Line - 1, this.position.Column + 1);
            while (board.ValidPosition(pos) && CanMove(pos))
            {
                movements[pos.Line, pos.Column] = true;
                if (board.GetPiece(pos) != null && board.GetPiece(pos).color != this.color)
                    break;

                pos.SetValues(pos.Line - 1, pos.Column + 1);
            }

            // Botton right
            pos.SetValues(this.position.Line + 1, this.position.Column + 1);
            while (board.ValidPosition(pos) && CanMove(pos))
            {
                movements[pos.Line, pos.Column] = true;
                if (board.GetPiece(pos) != null && board.GetPiece(pos).color != this.color)
                    break;

                pos.SetValues(pos.Line + 1, pos.Column + 1);
            }

            // Botton left
            pos.SetValues(this.position.Line + 1, this.position.Column - 1);
            while (board.ValidPosition(pos) && CanMove(pos))
            {
                movements[pos.Line, pos.Column] = true;
                if (board.GetPiece(pos) != null && board.GetPiece(pos).color != this.color)
                    break;

                pos.SetValues(pos.Line + 1, pos.Column - 1);
            }

            // Top left
            pos.SetValues(this.position.Line - 1, this.position.Column - 1);
            while (board.ValidPosition(pos) && CanMove(pos))
            {
                movements[pos.Line, pos.Column] = true;
                if (board.GetPiece(pos) != null && board.GetPiece(pos).color != this.color)
                    break;

                pos.SetValues(pos.Line - 1, pos.Column - 1);
            }

            return movements;
        }

        public override string ToString()
        {
            return "B";
        }
    }
}
