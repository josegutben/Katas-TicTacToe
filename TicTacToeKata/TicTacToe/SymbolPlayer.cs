namespace TicTacToe {
    public class SymbolPlayer {
        private readonly char symbol;

        public SymbolPlayer(char symbol) {
            this.symbol = symbol;
        }

        public bool IsOPlayer() {
            return symbol == 'O';
        }
    }
}