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

        public List<Square> GetRookMoves(Board board)
        {
            Square square = board.FindPiece(this);
            List<Square> newMoves = new List<Square>();

            int leftLim = square.Col - 1;
            for (int col = square.Col - 1; col >= 0; col--)
            {
                Square checkRow = Square.At(square.Row, col);
                if (board.GetPiece(checkRow) == null)
                    leftLim = col;
                else
                    break;
            }

            int rightLim = square.Col + 1;
            for (int col = square.Col + 1; col < 8; col++)
            {
                Square checkRow = Square.At(square.Row, col);
                if (board.GetPiece(checkRow) == null)
                    rightLim = col;
                else
                    break;
            }

            int upLim = square.Row - 1;
            for (int row = square.Row - 1; row >= 0; row--)
            {
                Square checkCol = Square.At(row, square.Col);
                if (board.GetPiece(checkCol) == null)
                    upLim = row;
                else
                    break;
            }

            int downLim = square.Row + 1;
            for (int row = square.Row + 1; row < 8; row++)
            {
                Square checkCol = Square.At(row, square.Col);
                if (board.GetPiece(checkCol) == null)
                    downLim = row;
                else
                    break;
            }

            for (int i = leftLim; i <= rightLim; i++)
            {
                newMoves.Add(Square.At(square.Row, i));
            }

            for (int i = upLim; i <= downLim; i++)
            {
                newMoves.Add(Square.At(i, square.Col));
            }

            // Remove the square that the rook is currently on
            newMoves.RemoveAll(s => s == Square.At(square.Row, square.Col));

            return newMoves;
        }

        public List<Square> GetBishopMoves(Board board)
        {
            Square square = board.FindPiece(this);

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