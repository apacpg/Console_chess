using System;

namespace Jogo_Xadrez.Entities.Board
{
    public class Posicao
    {
        public int Line { get; set; }
        public int Column { get; set; }

        public Posicao(int line, int column)
        {
            this.Line = line;
            this.Column = column;
        }

        public override string ToString()
        {
            return Line + ", " + Column;
        }

        public override bool Equals(object obj)
        {
            Posicao pos = obj as Posicao;

            if (pos != null)
            {
                return ((this.Line == pos.Line) && (this.Column == pos.Column));
            }
            else
                throw new Exception(string.Format("The obj is not of the {0} type", typeof(Posicao)));
        }
    }
}
