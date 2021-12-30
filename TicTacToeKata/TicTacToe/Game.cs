using TicTacToe.Exceptions;

namespace TicTacToe {
    public class Game {
        private readonly Board board;
        private SymbolPlayer lastSymbol;

        public Game() {
            board = new Board();
            lastSymbol = new SymbolPlayer(' ');
        }

        public GameResult Play(SymbolPlayer symbolPlayer, Coordinates coordinates) {
            CheckMovement(symbolPlayer);
            TryToMove(symbolPlayer, coordinates);
            lastSymbol = symbolPlayer;
            return new GameResult(false, ' ');
        }

        private void TryToMove(SymbolPlayer symbolPlayer, Coordinates coordinates) {
            try {
                board.Move(symbolPlayer, coordinates);
            }
            catch (PositionAlreadyInUseException) {
                throw new MovementCouldNotBeCompletedException(MovementErrorReason.PositionAlreadyInUse);
            }
        }

        private void CheckMovement(SymbolPlayer symbolPlayer) {
            if (IsOFirstPlayer(symbolPlayer)) {
                throw new MovementCouldNotBeCompletedException(MovementErrorReason.WrongFirstPlayer);
            }

            if (IsNoTurnForPlayer(symbolPlayer)) {
                throw new MovementCouldNotBeCompletedException(MovementErrorReason.NoPlayerTurn);
            }
        }

        private bool IsNoTurnForPlayer(SymbolPlayer symbolPlayer) {
            return lastSymbol.Equals(symbolPlayer);
        }

        private bool IsOFirstPlayer(SymbolPlayer symbolPlayer) {
            return lastSymbol.IsEmpty() && symbolPlayer.IsOPlayer();
        }
    }
}