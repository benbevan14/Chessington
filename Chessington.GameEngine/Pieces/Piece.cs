using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public abstract class Piece
    {
        protected Piece(Player player)
        {
            Player = player;
        }

        public Player Player { get; private set; }

        public abstract IEnumerable<Square> GetAvailableMoves(Board board);

        public void MoveTo(Board board, Square newSquare)
        {
            var currentSquare = board.FindPiece(this);
            board.MovePiece(currentSquare, newSquare);
        }

        public static List<Square> GetRookMoves(Square square)
        {
            List<Square> newMoves = new List<Square>();

            for (int i = 0; i < 8; i++)
            {
                newMoves.Add(Square.At(square.Row, i));
                newMoves.Add(Square.At(i, square.Col));
            }

            newMoves.RemoveAll(s => s == Square.At(square.Row, square.Col));

            return newMoves;
        }

        public static List<Square> GetBishopMoves(Square square)
        {
            List<Square> newMoves = new List<Square>();

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (Math.Abs(i - square.Row) == Math.Abs(j - square.Col))
                    {
                        newMoves.Add(Square.At(i, j));
                    }
                }
            }

            newMoves.RemoveAll(s => s == Square.At(square.Row, square.Col));

            return newMoves;
        }
    }
}