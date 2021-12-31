namespace TicTacToe {
    public class MovementResult {
        private readonly bool boardIsFull;
        private readonly bool thereIsAWinner;

        public MovementResult(bool boardIsFull, bool thereIsAWinner) {
            this.boardIsFull = boardIsFull;
            this.thereIsAWinner = thereIsAWinner;
        }

        public bool BoardIsFull() {
            return boardIsFull;
        }

        public bool ThereIsAWinner() {
            return thereIsAWinner;
        }
    }
}