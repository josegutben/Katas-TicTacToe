namespace TicTacToe {
    public class Board {
        private BoardTiles boardTiles;

        public Board() {
            boardTiles = new BoardTiles();
        }

        public void Move(SymbolPlayer symbolPlayer, Coordinates coordinates) {
            boardTiles.AddTile(symbolPlayer.GetSymbol(), coordinates);
        }
    }
}