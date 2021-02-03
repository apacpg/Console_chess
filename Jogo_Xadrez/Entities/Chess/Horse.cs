using Jogo_Xadrez.Entities.Board;

namespace Jogo_Xadrez.Entities.Chess
{
    public class Horse : Piece
    {
        public Horse(Color color, GameBoard board) : base(color, board) { }

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

            //Top
            pos.SetValues(this.position.Line - 2, this.position.Column + 1);
            if (board.ValidPosition(pos) && CanMove(pos))
                movements[pos.Line, pos.Column] = true;
            pos.SetValues(this.position.Line - 2, this.position.Column - 1);
            if (board.ValidPosition(pos) && CanMove(pos))
                movements[pos.Line, pos.Column] = true;

            //Right
            pos.SetValues(this.position.Line + 1, this.position.Column + 2);
            if (board.ValidPosition(pos) && CanMove(pos))
                movements[pos.Line, pos.Column] = true;
            pos.SetValues(this.position.Line - 1, this.position.Column + 2);
            if (board.ValidPosition(pos) && CanMove(pos))
                movements[pos.Line, pos.Column] = true;

            //Botton
            pos.SetValues(this.position.Line + 2, this.position.Column + 1);
            if (board.ValidPosition(pos) && CanMove(pos))
                movements[pos.Line, pos.Column] = true;
            pos.SetValues(this.position.Line + 2, this.position.Column - 1);
            if (board.ValidPosition(pos) && CanMove(pos))
                movements[pos.Line, pos.Column] = true;

            //Left
            pos.SetValues(this.position.Line + 1, this.position.Column - 2);
            if (board.ValidPosition(pos) && CanMove(pos))
                movements[pos.Line, pos.Column] = true;
            pos.SetValues(this.position.Line - 1, this.position.Column - 2);
            if (board.ValidPosition(pos) && CanMove(pos))
                movements[pos.Line, pos.Column] = true;

            return movements;
        }

        public override string ToString()
        {
            return "H";
        }
    }
}
