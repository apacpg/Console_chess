using Jogo_Xadrez.Entities.Board;
using Jogo_Xadrez.Entities.Chess;
using Jogo_Xadrez.UI;

namespace Jogo_Xadrez
{
    class Program
    {
        static void Main(string[] args)
        {

            ChessMatch chessMatch = new ChessMatch();


            Screen.DisplayBoard(chessMatch.board);
        }
    }
}
