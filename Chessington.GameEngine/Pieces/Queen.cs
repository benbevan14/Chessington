using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Queen : Piece
    {
        public Queen(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            Square currentSquare = board.FindPiece(this);

            List<Square> newMoves = new List<Square>();

            newMoves.AddRange(this.GetDiagonalMoves(board));
            newMoves.AddRange(this.GetOrthogonalMoves(board));

            return newMoves;
        }
    }
}