using Jogo_Xadrez.Entities.Board;
using Jogo_Xadrez.UI;

namespace Jogo_Xadrez
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board(8, 8);
            Screen.DisplayBoard(board);
        }
    }
}
