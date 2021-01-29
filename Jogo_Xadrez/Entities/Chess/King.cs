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
    }
}
