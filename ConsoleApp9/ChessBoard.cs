using Chess;

namespace Chessapp;

public class ChessBoard
{
    private readonly Dictionary<string, IPiece?> _pieces = new();
    IPiece _blueKing;
    IPiece _greenKing;
    public ChessBoard()
    {
        for (int i = 1; i <= 8; i++)
        {
            var pawnPiece = new PawnPiece("p" + i, PieceColor.Blue, (1, i - 1));
            _pieces["p" + i] = pawnPiece;
            var piece = new PawnPiece("P" + i, PieceColor.Green, (6, i - 1));
            _pieces["P" + i] = piece;
        }

        _pieces["k1"] = _blueKing = new KingPiece("k1", PieceColor.Blue, (0, 3));
        _pieces["K1"] = _greenKing = new KingPiece("K1", PieceColor.Green, (7, 4));

        _pieces["q1"] = new QueenPiece("q1", PieceColor.Blue, (0, 4));
        _pieces["Q1"] = new QueenPiece("Q1", PieceColor.Green, (7, 3));

        _pieces["n1"] = new KnightPiece("n1", PieceColor.Blue, (0, 1));
        _pieces["N1"] = new KnightPiece("N1", PieceColor.Green, (7, 1));
        _pieces["n2"] = new KnightPiece("n2", PieceColor.Blue, (0, 6));
        _pieces["N2"] = new KnightPiece("N2", PieceColor.Green, (7, 6));

        _pieces["b1"] = new BishopPiece("b1", PieceColor.Blue, (0, 2));
        _pieces["B1"] = new BishopPiece("B1", PieceColor.Green, (7, 2));
        _pieces["b2"] = new BishopPiece("b2", PieceColor.Blue, (0, 5));
        _pieces["B2"] = new BishopPiece("B2", PieceColor.Green, (7, 5));

        _pieces["r1"] = new RookPiece("r1", PieceColor.Blue, (0, 0));
        _pieces["R1"] = new RookPiece("R1", PieceColor.Green, (7, 0));
        _pieces["r2"] = new RookPiece("r2", PieceColor.Blue, (0, 7));
        _pieces["R2"] = new RookPiece("R2", PieceColor.Green, (7, 7));
        
        
    }

    public void ClearPiece((int row, int col) pos)
    {
        var piece = RetrievePieceFrom(pos);
        if (piece != null)
        {
            _pieces["ABCDEFGH".Substring(pos.col, 1) + pos.row] = null;
        }
    }

    public IPiece? RetrievePieceFrom(string symbol)
    {
        return _pieces.Values.FirstOrDefault(boardPiece => boardPiece?.Symbol == symbol);
    }

    public void PieceIsCaptured(string symbol)
    {
        var chessPiece = _pieces.First(x => x.Key.Equals(symbol)).Value;
        
        if (chessPiece != null)
        {
            chessPiece.IsPieceCaptured = true;
        }
    }
    
    
    /// <summary>
    /// Returns the piece at the specified position or null if no piece is at that
    /// position.
    /// </summary>
    public IPiece? RetrievePieceFrom((int row, int col) pos) => _pieces.Values.FirstOrDefault(x => x != null && x.Position.row == pos.row && x.Position.col == pos.col);

    /// <summary>
    /// Returns true if there is no piece at the specified position and false otherwise.
    /// </summary>
    /// <param name="pos"></param>
    /// <returns></returns>
    public bool IsEmpty((int row, int col) pos) => _pieces
        .FirstOrDefault(x => 
            x.Value != null && x.Value.Position.col == pos.col && x.Value.Position.row == pos.row).Value == null;

    /// <summary>
    /// Checks if the game has ended and returns true if it has.
    /// </summary>
    public bool IsGameOver() => _blueKing.IsPieceCaptured || _greenKing.IsPieceCaptured;

    public List<IPiece?> RetrieveAllPieces()
    {
        return _pieces.Values.ToList();
    }
}