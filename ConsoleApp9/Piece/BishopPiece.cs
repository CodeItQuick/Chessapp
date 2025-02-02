using Chessapp;
using Chessapp.Piece;

namespace Chess;

public class BishopPiece : AbstractPiece
{

    public BishopPiece(string symbol, PieceColor color, (int, int) position) : base(symbol, color, position) { }
    
    /// <summary>
    /// Given a target position, checks the piece specific logic for moving this 
    /// piece to that position on the board. If the piece can move there,
    /// returns true and otherwise returns false.
    /// </summary>
    protected override bool SubLogic((int row, int col) target,
        List<IPiece?> chessBoardPieces)
    {
        if (!Rules.IsDiagonal(PieceAttributes.Position, target))
        {
            return false;
        }
        return Rules.IsPathClear(PieceAttributes.Position, target, chessBoardPieces);
    }

}