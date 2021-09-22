using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Rook : Piece
    {
        public Rook(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            Square currentSquare = board.FindPiece(this);

            List<Square> newMoves = new List<Square>();

            for (int i = 0; i < 8; i++)
            {
                newMoves.Add(Square.At(currentSquare.Row, i));
                newMoves.Add(Square.At(i, currentSquare.Col));
            }

            newMoves.RemoveAll(s => s == Square.At(currentSquare.Row, currentSquare.Col));

            return newMoves;
        }
    }
}