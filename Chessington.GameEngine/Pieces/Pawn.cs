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

            if (Player == Player.White)
            {
                newMoves.Add(Square.At(currentSquare.Row - 1, currentSquare.Col));
                if (currentSquare.Row == 6)
                {
                    newMoves.Add(Square.At(currentSquare.Row - 2, currentSquare.Col));
                }
            }
            else if (Player == Player.Black)
            {
                newMoves.Add(Square.At(currentSquare.Row + 1, currentSquare.Col));
                if (currentSquare.Row == 1)
                {
                    newMoves.Add(Square.At(currentSquare.Row + 2, currentSquare.Col));
                }
            }

            return newMoves;
        }
    }
}