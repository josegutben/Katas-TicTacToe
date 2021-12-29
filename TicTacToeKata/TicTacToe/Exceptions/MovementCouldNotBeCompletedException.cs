using System;

namespace TicTacToe.Exceptions {
    public class MovementCouldNotBeCompletedException : Exception {
        public MovementErrorReason Reason { get; private set; }

        public MovementCouldNotBeCompletedException(MovementErrorReason reason) {
            Reason = reason;
        }
    }

    public enum MovementErrorReason {
        WrongFirstPlayer,
        NoPlayerTurn
    }
}