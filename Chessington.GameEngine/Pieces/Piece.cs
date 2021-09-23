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

        public List<Square> GetOrthogonalMoves(Board board)
        {
            Square square = board.FindPiece(this);
            List<Square> newMoves = new List<Square>();

            for (int col = square.Col - 1; col >= 0; col--)
            {
                Square checkRow = Square.At(square.Row, col);
                if (board.GetPiece(checkRow) == null)
                    newMoves.Add(checkRow);
                else if (board.GetPiece(checkRow).Player != this.Player)
                {
                    newMoves.Add(checkRow);
                    break;
                }
                else
                    break;
            }

            for (int col = square.Col + 1; col < 8; col++)
            {
                Square checkRow = Square.At(square.Row, col);
                if (board.GetPiece(checkRow) == null)
                    newMoves.Add(checkRow);
                else if (board.GetPiece(checkRow).Player != this.Player)
                {
                    newMoves.Add(checkRow);
                    break;
                }
                else
                    break;
            }

            for (int row = square.Row - 1; row >= 0; row--)
            {
                Square checkCol = Square.At(row, square.Col);
                if (board.GetPiece(checkCol) == null)
                    newMoves.Add(checkCol);
                else if (board.GetPiece(checkCol).Player != this.Player)
                {
                    newMoves.Add(checkCol);
                    break;
                }
                else
                    break;
            }

            for (int row = square.Row + 1; row < 8; row++)
            {
                Square checkCol = Square.At(row, square.Col);
                if (board.GetPiece(checkCol) == null)
                    newMoves.Add(checkCol);
                else if (board.GetPiece(checkCol).Player != this.Player)
                {
                    newMoves.Add(checkCol);
                    break;
                }
                else
                    break;
            }

            // Remove the square that the piece is currently on
            newMoves.RemoveAll(s => s == Square.At(square.Row, square.Col));

            return newMoves;
        }

        public List<Square> GetDiagonalMoves(Board board)
        {
            Square square = board.FindPiece(this);
            List<Square> newMoves = new List<Square>();

            // Up-left direction (limit by column)
            int rowChange = 1;
            for (int col = square.Col - 1; col >= 0; col--, rowChange++)
            {
                // Check we haven't gone out the top of the board
                if (square.Row - rowChange < 0)
                    break;

                Square checkSq = Square.At(square.Row - rowChange, col);
                if (board.GetPiece(checkSq) == null)
                    newMoves.Add(checkSq);
                else
                    break;
            }

            // Up-right direction (limit by column)
            rowChange = 1;
            for (int col = square.Col + 1; col < 8; col++, rowChange++)
            {
                // Check we haven't gone out the top of the board
                if (square.Row - rowChange < 0)
                    break;

                Square checkSq = Square.At(square.Row - rowChange, col);
                if (board.GetPiece(checkSq) == null)
                    newMoves.Add(checkSq);
                else
                    break;
            }

            // Down-left direction (limit by column)
            rowChange = 1;
            for (int col = square.Col - 1; col >= 0; col--, rowChange++)
            {
                // Check we haven't gone out the bottom of the board
                if (square.Row + rowChange > 7)
                    break;

                Square checkSq = Square.At(square.Row + rowChange, col);
                if (board.GetPiece(checkSq) == null)
                    newMoves.Add(checkSq);
                else
                    break;
            }

            // Down-right direction (limit by column)
            rowChange = 1;
            for (int col = square.Col + 1; col < 8; col++, rowChange++)
            {
                // Check we haven't gone out the bottom of the board
                if (square.Row + rowChange > 7)
                    break;

                Square checkSq = Square.At(square.Row + rowChange, col);
                if (board.GetPiece(checkSq) == null)
                    newMoves.Add(checkSq);
                else
                    break;
            }

            return newMoves;
        }
    }
}