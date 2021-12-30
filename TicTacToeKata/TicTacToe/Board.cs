namespace TicTacToe {
    public class Board {
        private readonly BoardTiles boardTiles;

        public Board() {
            boardTiles = new BoardTiles();
        }

        public void Move(SymbolPlayer symbolPlayer, Coordinates coordinates) {
            boardTiles.AddTile(symbolPlayer.GetSymbol(), coordinates);
        }

        public bool GameIsFinished() {
            return boardTiles.AnyWinnerInVerticalLine() || boardTiles.AnyWinnerInHorizontalLine() || boardTiles.AnyWinnerInDiagonalLine();
        }
    }
}