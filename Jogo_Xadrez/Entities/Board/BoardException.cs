using System;

namespace Jogo_Xadrez.Entities.Board
{
    public class BoardException : Exception
    {
        public BoardException(string msg) : base(msg)
        {

        }
    }
}
