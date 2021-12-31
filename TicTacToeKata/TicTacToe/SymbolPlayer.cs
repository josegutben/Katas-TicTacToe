namespace TicTacToe {
    public class SymbolPlayer {
        private readonly Symbol symbol;

        public SymbolPlayer(Symbol symbol) {
            this.symbol = symbol;
        }

        public bool IsOPlayer() {
            return symbol == Symbol.O;
        }

        public bool IsEmpty() {
            return symbol == Symbol.NoPlayer;
        }

        public override bool Equals(object obj) {
            if((obj == null) || this.GetType() != obj.GetType()) {
                return false;
            }

            var symbolPlayer = (SymbolPlayer)obj;
            return (this.symbol == symbolPlayer.symbol);
        }

        public bool Equals(SymbolPlayer symbolPlayer) {
            return symbolPlayer.symbol == symbol;
        }

        public Symbol GetSymbol() {
            return symbol;
        }
    }
}