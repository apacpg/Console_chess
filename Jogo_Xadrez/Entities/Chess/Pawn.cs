using Jogo_Xadrez.Entities.Board;

namespace Jogo_Xadrez.Entities.Chess
{
    public class Pawn : Piece
    {
        public Pawn(Color color, GameBoard board) : base(color, board) { }

        public override string ToString()
        {
            return "P";
        }
    }
}
