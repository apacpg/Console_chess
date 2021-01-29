using Jogo_Xadrez.Entities.Board;

namespace Jogo_Xadrez.Entities.Chess
{
    public class ChessPosition
    {
        public int line { get; set; }
        public char column { get; set; }

        public ChessPosition(int line, char column)
        {
            this.line = line;
            this.column = column;
        }

        public Position ToPosition()
        {
            int col = this.column - 'a';
            int lin = 8 - this.line;

            return new Position(lin, col);
        }

        public override string ToString()
        {
            return "" + this.line + this.column;
        }
    }
}
