using TicTacToe.Exceptions;

namespace TicTacToe {
    public class Game {
        private SymbolPlayer lastSymbol;

        public Game() {
            lastSymbol = new SymbolPlayer(' ');
        }

        public void Play(SymbolPlayer symbolPlayer, int x, int y) {
            if (IsOFirstPlayer(symbolPlayer)) {
                throw new MovementCouldNotBeCompletedException(MovementErrorReason.WrongFirstPlayer);
            }

            if (IsNoTurnForPlayer(symbolPlayer)) {
                throw new MovementCouldNotBeCompletedException(MovementErrorReason.NoPlayerTurn);
            }

            lastSymbol = symbolPlayer;
        }

        private bool IsNoTurnForPlayer(SymbolPlayer symbolPlayer) {
            return lastSymbol.Equals(symbolPlayer);
        }

        private bool IsOFirstPlayer(SymbolPlayer symbolPlayer) {
            return lastSymbol.IsEmpty() && symbolPlayer.IsOPlayer();
        }
    }
}