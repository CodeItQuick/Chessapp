using Chessapp;
using Chessapp.Piece;

namespace Chess;
public class PawnPiece : AbstractPiece
{

    public PawnPiece(string symbol, PieceColor color, (int, int) position) : base(symbol, color, position) { }
    protected override bool SubLogic((int row, int col) target, ChessBoard chessBoard)
    {
        int rowInc = _pieceAttributes.Color == PieceColor.Blue ? 1 : -1;
        int targetRow = _pieceAttributes.Position.row + rowInc;
        int firstTurnTargetRow = _pieceAttributes.Position.row + 2*rowInc;
        int[] targetCols = {_pieceAttributes.Position.col - 1, Position.col + 1};
        bool isAttack = _pieceAttributes.Position.col - target.col != 0;

        // Always, pawn may move forward 1 if space is empty
        if (target.row == targetRow && !isAttack && chessBoard.IsEmpty(target))
        {
            return true;
        }

        // On first turn, pawn may move forward 2 spaces if empty
        if (!_pieceAttributes.HasMoved && 
            target.row == firstTurnTargetRow && 
            !isAttack && chessBoard.IsEmpty(target) && 
            chessBoard.IsPathClear(_pieceAttributes.Position, target))
        {
            return true;
        }

        // Can move diagonal 1 if an enemy is in that space
        if (target.row == targetRow && targetCols.Contains(target.col) && !chessBoard.IsEmpty(target))
        {
            return true;
        }

        // TODO: En passant move

        return false;
    }

}