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

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (Math.Abs(i - currentSquare.Row) == Math.Abs(j - currentSquare.Col))
                    {
                        newMoves.Add(Square.At(i, j));
                    }

                    if (i == currentSquare.Row || j == currentSquare.Col)
                    {
                        newMoves.Add(Square.At(i, j));
                    }
                }
            }

            newMoves.RemoveAll(s => s == Square.At(currentSquare.Row, currentSquare.Col));

            return newMoves;
        }
    }
}