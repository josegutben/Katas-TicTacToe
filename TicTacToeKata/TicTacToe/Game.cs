using TicTacToe.Exceptions;

namespace TicTacToe {
    public class Game {
        private readonly char lastSymbol;

        public Game() {
            lastSymbol = ' ';
        }

        public void Play(char symbol, int x, int y) {
            if (lastSymbol == ' ' && symbol == 'O') {
                throw new MovementCouldNotBeCompletedException(MovementErrorReason.WrongFirstPlayer);
            }
        }
    }
}