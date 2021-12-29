using TicTacToe.Exceptions;

namespace TicTacToe {
    public class Game {
        private SymbolPlayer lastSymbol;

        public Game() {
            lastSymbol = new SymbolPlayer(' ');
        }

        public void Play(SymbolPlayer symbolPlayer, int x, int y) {
            CheckMovement(symbolPlayer);
            lastSymbol = symbolPlayer;
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