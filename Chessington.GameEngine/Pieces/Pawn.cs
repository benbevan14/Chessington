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

            switch (this.Player)
            {
                case Player.White:
                    return new List<Square> { Square.At(currentSquare.Row - 1, currentSquare.Col) };
                case Player.Black:
                    return new List<Square> { Square.At(currentSquare.Row + 1, currentSquare.Col) };
                default:
                    return new List<Square>();
            }
        }
    }
}