namespace TicTacToe {
    public class GameResult {
        private readonly bool isFinished;
        private readonly char winnerSymbol;

        public GameResult(bool isFinished, char winnerSymbol) {
            this.isFinished = isFinished;
            this.winnerSymbol = winnerSymbol;
        }

        public override bool Equals(object obj) {
            if((obj == null) || this.GetType() != obj.GetType()) {
                return false;
            }

            var gameResult = (GameResult)obj;
            return (this.isFinished == gameResult.isFinished && this.winnerSymbol == gameResult.winnerSymbol);
        }
    }
}