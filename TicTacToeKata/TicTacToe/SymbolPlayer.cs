using System;
using System.Drawing;

namespace TicTacToe {
    public class SymbolPlayer {
        private readonly char symbol;

        public SymbolPlayer(char symbol) {
            this.symbol = symbol;
        }

        public bool IsOPlayer() {
            return symbol == 'O';
        }

        public bool IsEmpty() {
            return symbol == ' ';
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
    }
}