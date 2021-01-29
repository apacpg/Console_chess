﻿using Jogo_Xadrez.Entities.Board;

namespace Jogo_Xadrez.Entities.Chess
{
    public class Bishop : Piece
    {
        public Bishop(Color color, GameBoard board) : base(color, board) { }

        public override string ToString()
        {
            return "B";
        }
    }
}