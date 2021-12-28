using TicTacToe.Exceptions;

namespace TicTacToe {
    public class Game {
        private readonly char lastSymbol;

        public Game() {
            lastSymbol = ' ';
        }

        public void Play(SymbolPlayer symbolPlayer, int x, int y) {
            if (IsOFirstPlayer(symbolPlayer)) {
                throw new MovementCouldNotBeCompletedException(MovementErrorReason.WrongFirstPlayer);
            }
        }

        private bool IsOFirstPlayer(SymbolPlayer symbolPlayer) {
            return lastSymbol == ' ' && symbolPlayer.IsOPlayer();
        }
    }
}