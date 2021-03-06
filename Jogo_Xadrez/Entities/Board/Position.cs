﻿using System;

namespace Jogo_Xadrez.Entities.Board
{
    public class Position
    {
        public int Line { get; set; }
        public int Column { get; set; }

        public Position(int line, int column)
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
            Position pos = obj as Position;

            if (pos != null)
            {
                return ((this.Line == pos.Line) && (this.Column == pos.Column));
            }
            else
                throw new Exception(string.Format("The obj is not of the {0} type", typeof(Position)));
        }

        public void SetValues(int line, int column)
        {
            this.Line = line;
            this.Column = column;
        }
    }
}
