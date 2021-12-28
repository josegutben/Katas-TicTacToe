using TicTacToe.Exceptions;

namespace TicTacToe {
    public class Game {
        private readonly char lastSymbol;

        public Game() {
            lastSymbol = ' ';
        }

        public void Play(SymbolPlayer symbolPlayer, int x, int y) {
            if (lastSymbol == ' ' && symbolPlayer.IsOPlayer()) {
                throw new MovementCouldNotBeCompletedException(MovementErrorReason.WrongFirstPlayer);
            }
        }
    }
}