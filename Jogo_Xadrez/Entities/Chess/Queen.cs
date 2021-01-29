﻿using Jogo_Xadrez.Entities.Board;

namespace Jogo_Xadrez.Entities.Chess
{
    public class Queen : Piece
    {
        public Queen(Color color, GameBoard board) : base(color, board) { }

        public override string ToString()
        {
            return "Q";
        }
    }
}
