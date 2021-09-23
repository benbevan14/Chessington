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

            // Make sure the pawn can't move off the board
            if (currentSquare.Row + dir < 0 || currentSquare.Row + dir > 7)
                return new List<Square>();

            // Check if the pawn can move diagonally to take an opposing piece
            if (currentSquare.Col < 7)
            {
                Square right = Square.At(currentSquare.Row + dir, currentSquare.Col + 1);
                if (board.GetPiece(right) != null && board.GetPiece(right).Player != Player)
                    newMoves.Add(right);

                if (currentSquare.Row == startRow + (3 * dir))
                {
                    Square nextToRight = Square.At(currentSquare.Row, currentSquare.Col + 1);
                    if (board.GetPiece(nextToRight) != null && board.GetPiece(nextToRight).Player != Player)
                        newMoves.Add(Square.At(currentSquare.Row + dir, currentSquare.Col + 1));
                }
                
            }
            if (currentSquare.Col > 0)
            {
                Square left = Square.At(currentSquare.Row + dir, currentSquare.Col - 1);
                if (board.GetPiece(left) != null && board.GetPiece(left).Player != Player)
                    newMoves.Add(left);

                if (currentSquare.Row == startRow + (3 * dir))
                {
                    Square nextToLeft = Square.At(currentSquare.Row, currentSquare.Col - 1);
                    if (board.GetPiece(nextToLeft) != null && board.GetPiece(nextToLeft).Player != Player)
                        newMoves.Add(Square.At(currentSquare.Row + dir, currentSquare.Col - 1));
                }
            }

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