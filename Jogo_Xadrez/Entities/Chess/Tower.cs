using Jogo_Xadrez.Entities.Board;

namespace Jogo_Xadrez.Entities.Chess
{
    class Tower : Piece
    {
        public Tower(Color color, GameBoard board) : base(color, board) { }

        public override string ToString()
        {
            return "T";
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

            Position pos = new Position(this.position.Line, this.position.Column);

            // check up
            pos.SetValues(this.position.Line - 1, this.position.Column);    
            while(board.ValidPosition(pos) && CanMove(pos))
            {
                movements[pos.Line, pos.Column] = true;
                if (board.GetPiece(pos) != null && board.GetPiece(pos).color != this.color)
                    break;

                pos.SetValues(pos.Line - 1, pos.Column);
            }

            // check right
            pos.SetValues(this.position.Line, this.position.Column + 1);
            while (board.ValidPosition(pos) && CanMove(pos))
            {
                movements[pos.Line, pos.Column] = true;
                if (board.GetPiece(pos) != null && board.GetPiece(pos).color != this.color)
                    break;

                pos.SetValues(pos.Line, pos.Column + 1);
            }

            // check botton
            pos.SetValues(this.position.Line + 1, this.position.Column);
            while (board.ValidPosition(pos) && CanMove(pos))
            {
                movements[pos.Line, pos.Column] = true;
                if (board.GetPiece(pos) != null && board.GetPiece(pos).color != this.color)
                    break;

                pos.SetValues(pos.Line + 1, pos.Column);
            }

            // check left
            pos.SetValues(this.position.Line, this.position.Column - 1);
            while (board.ValidPosition(pos) && CanMove(pos))
            {
                movements[pos.Line, pos.Column] = true;
                if (board.GetPiece(pos) != null && board.GetPiece(pos).color != this.color)
                    break;

                pos.SetValues(pos.Line, pos.Column - 1);
            }

            return movements;
        }
    }
}
