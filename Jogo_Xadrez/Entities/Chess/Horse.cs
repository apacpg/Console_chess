using Jogo_Xadrez.Entities.Board;

namespace Jogo_Xadrez.Entities.Chess
{
    public class Horse : Piece
    {
        public Horse(Color color, GameBoard board) : base(color, board) { }

        public override bool[,] PossibleMovements()
        {
            throw new System.NotImplementedException();
        }

        public override string ToString()
        {
            return "H";
        }
    }
}
