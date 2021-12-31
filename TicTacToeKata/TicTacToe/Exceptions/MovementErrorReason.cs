namespace TicTacToe.Exceptions {
    public enum MovementErrorReason {
        WrongFirstPlayer,
        NoPlayerTurn,
        PositionAlreadyInUse,
        GameIsFinished
    }
}