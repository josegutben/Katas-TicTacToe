using System.Collections.Generic;
using System.Linq;

namespace TicTacToe {
    public class WinningPlays {
        private readonly List<BoardPosition> winningCombinations;

        public WinningPlays(List<BoardPosition> boardPositions) {
            this.winningCombinations = boardPositions;
        }

        public bool IsWinner(Dictionary<BoardPosition, Symbol> playedPositions, Symbol symbol) {
            return winningCombinations.All(x => playedPositions.ContainsKey(x) && playedPositions[x] == symbol);
        }
    }
}