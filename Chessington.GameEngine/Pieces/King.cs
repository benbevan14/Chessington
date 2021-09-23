using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class King : Piece
    {
        public King(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            Square currentSquare = board.FindPiece(this);

            List<Square> newMoves = new List<Square>();

            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    newMoves.Add(Square.At(currentSquare.Row + i, currentSquare.Col + j));
                }
            }

            newMoves.RemoveAll(s => s == Square.At(currentSquare.Row, currentSquare.Col));

            return newMoves;
        }
    }
}