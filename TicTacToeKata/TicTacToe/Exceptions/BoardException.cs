using System;

namespace TicTacToe.Exceptions {
    public class BoardException : Exception {
        public MovementErrorReason Reason { get; private set; }

        public BoardException(MovementErrorReason reason) {
            Reason = reason;
        }
    }
}