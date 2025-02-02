using Chess;
using Chessapp;

namespace Tests.ConsoleApp9;

public class ChessBoardTests
{
    //
    // Acceptance Tests Begin
    //

    [Fact]
    public void GivenAChessBoardICanSelectAPiece()
    {
        var chessboard = new ChessBoardController();
        var pawnOnePlayerOne = chessboard.SelectChessPiece("b1");
        
        Assert.NotNull(pawnOnePlayerOne);
    }
    [Fact]
    public void GivenAChessBoardAtTheStartOfTheGamePlayerBlueIsSelected()
    {
        var chessboard = new ChessBoardController();
        var pawnOnePlayerOne = chessboard.ActivePlayer();
        
        Assert.Equal(PieceColor.Blue, pawnOnePlayerOne);
    }
    [Fact]
    public void GivenAChessBoardAtTheStartOfTheGameOnTurnTwoPlayerGreenIsSelected()
    {
        var chessboard = new ChessBoardController();

        IPiece? heroPiece = chessboard.RetrievePieceFrom((2, 0));
        chessboard.MovePieceOnBoard(heroPiece, (3, 0));
        
        var pawnOnePlayerOne = chessboard.ActivePlayer();
        
        Assert.Equal(PieceColor.Green, pawnOnePlayerOne);
    }
    
    [Fact]
    public void GivenAChessBoardAtTheStartOfTheGameIKnowTheCasingOfSelectedPlayersPieces()
    {
        var chessboard = new ChessBoardController();
        
        var pawnOnePlayerOne = chessboard.ActivePlayerCasing();
        
        Assert.Equal("lowercase", pawnOnePlayerOne);
    }
    
    
    [Fact]
    public void GivenAChessBoardAtTheStartOfTheGameICannotSelectTheWrongPiece()
    {
        var chessboard = new ChessBoardController();

        Assert.Throws<Exception>(() => chessboard.SelectChessPiece("P1"));
    }

    
    [Fact]
    public void GivenAChessBoardAtTheStartOfTheGameICannotSelectSquareWithNoPiece()
    {
        var chessboard = new ChessBoardController();

        Assert.Throws<Exception>(() => chessboard.SelectChessPiece("P12"));
    }
    [Fact]
    public void GivenAChessBoardAtTheStartOfTheGameICannotSelectSquareWithACapturedPiece()
    {
        var chessboard = new ChessBoardController();

        chessboard.PieceIsCaptured("p1");
        
        Assert.Throws<Exception>(() => chessboard.SelectChessPiece("p1"));
    }

    [Fact]
    public void WhenAChessBoardIsCreatedThereAreThirtyTwoPiecesPlaced()
    {
        var chessboard = new ChessBoardController();
        var piecesOnBoard = chessboard.RetrieveAllPieces()
            .Where(x => x != null);
        Assert.Equal(32, piecesOnBoard.Count());
    }

    [Fact]
    public void GivenAChessBoardWeCanMakeTheFirstMoveWithPawnOne()
    {
        var chessboard = new ChessBoardController();
        var pawnOne = chessboard.SelectChessPiece("p1");
        
        chessboard.MovePieceOnBoard(pawnOne, (3, 0));
        Assert.Equal((3, 0), pawnOne.Position);
    }

    [Fact]
    public void GivenAChessBoardWeCanMakeTheSecondMoveAsPlayerTwoWithPawnOne()
    {
        var chessboard = new ChessBoardController();
        var pawnOnePlayerOne = chessboard.SelectChessPiece("p1");
        chessboard.MovePieceOnBoard(pawnOnePlayerOne, (3, 0));
        var pawnOnePlayerTwo = chessboard.SelectChessPiece("P2");
        chessboard.MovePieceOnBoard(pawnOnePlayerTwo, (5, 1));
        
        Assert.Equal((5, 1), pawnOnePlayerTwo.Position);
    }

    [Fact]
    public void GivenAChessBoardCannotMakeInvalidMove()
    {
        var chessboard = new ChessBoardController();
        var pawnOnePlayerOne = chessboard.SelectChessPiece("b1");
        chessboard.MovePieceOnBoard(pawnOnePlayerOne, (3, 3));
        
        Assert.Equal((0, 2), pawnOnePlayerOne.Position);
    }

    //
    // Acceptance Tests End
    //
}