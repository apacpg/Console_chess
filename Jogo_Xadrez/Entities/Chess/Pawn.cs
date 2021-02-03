using Jogo_Xadrez.Entities.Board;

namespace Jogo_Xadrez.Entities.Chess
{
    public class Pawn : Piece
    {
        public Pawn(Color color, GameBoard board) : base(color, board) { }

        public override bool[,] PossibleMovements()
        {
            bool[,] movements = new bool[board.lines, board.columns];

            Position pos = new Position(this.position.Line, this.position.Column);

            if(this.movNumber == 0)
            {
                if(this.color == Color.Black)
                {
                    pos.SetValues(this.position.Line + 2, this.position.Column);
                    if (board.ValidPosition(pos) && CanMove(pos))
                    {
                        movements[pos.Line, pos.Column] = true;
                    }
                }
                else
                {
                    pos.SetValues(this.position.Line - 2, this.position.Column);
                    if (board.ValidPosition(pos) && CanMove(pos))
                    {
                        movements[pos.Line, pos.Column] = true;
                    }
                }
            }

            VerifyVerticalMovement(ref movements);
            VerifyDiagonalMove(ref movements);

            return movements;
        }

        private bool CanMove(Position pos)
        {
            Piece possDestination = board.GetPiece(pos);

            if (possDestination == null)
                return true;

            return false;
        }

        private void VerifyVerticalMovement(ref bool[,] movements)
        {
            Position pos = new Position(this.position.Line, this.position.Column);

            if(this.color == Color.Black)
            {
                // Move down
                pos.SetValues(this.position.Line + 1, this.position.Column);
                if (board.ValidPosition(pos) && CanMove(pos))
                {
                    movements[pos.Line, pos.Column] = true;
                }
            }
            else
            {
                // Move up
                pos.SetValues(this.position.Line - 1, this.position.Column);
                if (board.ValidPosition(pos) && CanMove(pos))
                {
                    movements[pos.Line, pos.Column] = true;
                }
            }
        }

        private void VerifyDiagonalMove(ref bool[,] movements)
        {
            Piece enemy;
            Position pos = new Position(this.position.Line, this.position.Column);

            if(this.color == Color.Black)
            {
                // Lower left
                pos.SetValues(this.position.Line + 1, this.position.Column - 1);
                if (board.ValidPosition(pos))
                {
                    enemy = board.GetPiece(pos);
                    if (enemy != null && enemy.color != this.color)
                    {
                        movements[pos.Line, pos.Column] = true;
                    }
                }

                // Lower right
                pos.SetValues(this.position.Line + 1, this.position.Column + 1);
                if (board.ValidPosition(pos))
                {
                    enemy = board.GetPiece(pos);
                    if (enemy != null && enemy.color != this.color)
                    {
                        movements[pos.Line, pos.Column] = true;
                    }
                }
            }
            else
            {
                if (this.color == Color.White)
                {
                    // Upper left
                    pos.SetValues(this.position.Line - 1, this.position.Column - 1);
                    if (board.ValidPosition(pos))
                    {
                        enemy = board.GetPiece(pos);
                        if (enemy != null && enemy.color != this.color)
                        {
                            movements[pos.Line, pos.Column] = true;
                        }
                    }

                    // Upper right
                    pos.SetValues(this.position.Line - 1, this.position.Column + 1);
                    if (board.ValidPosition(pos))
                    {
                        enemy = board.GetPiece(pos);
                        if (enemy != null && enemy.color != this.color)
                        {
                            movements[pos.Line, pos.Column] = true;
                        }
                    }
                }
            }
        }

        public override string ToString()
        {
            return "P";
        }
    }
}
