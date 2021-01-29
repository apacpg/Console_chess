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
    }
}
