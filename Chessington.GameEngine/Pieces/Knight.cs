using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Knight : Piece
    {
        public Knight(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            Square currentSquare = board.FindPiece(this);

            int[] xMoves = new[] {-2, 2, 2, -2, -1, 1, 1, -1};
            int[] yMoves = new[] {-1, 1, -1, 1, 2, 2, -2, -2};

            List<Square> newMoves = xMoves.Select((t, i) => Square.At(currentSquare.Row + yMoves[i], currentSquare.Col + t)).ToList();

            newMoves.RemoveAll(s => s.Row < 0 || s.Row > 7 || s.Col < 0 || s.Col > 7);

            return newMoves;
        }
    }
}