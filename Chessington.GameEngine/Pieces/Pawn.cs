using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            Square currentSquare = board.FindPiece(this);

            List<Square> newMoves = new List<Square>();

            int startRow = this.Player == Player.White ? 6 : 1;
            int dir = this.Player == Player.White ? -1 : 1;

            // If there's a piece in front of the pawn it can't move, so return empty list
            if (board.GetPiece(Square.At(currentSquare.Row + dir, currentSquare.Col)) != null) return newMoves;

            // Add the square in front of the pawn as a possible move
            newMoves.Add(Square.At(currentSquare.Row + dir, currentSquare.Col));

            // If it's not the first move return the list of just one move
            if (currentSquare.Row != startRow) return newMoves;

            // If it's the first move and the square two in front is empty, add that move
            if (board.GetPiece(Square.At(currentSquare.Row + (dir * 2), currentSquare.Col)) == null)
                newMoves.Add(Square.At(currentSquare.Row + (dir * 2), currentSquare.Col));

            return newMoves;
        }
    }
}