namespace TicTacToe {
    public class Board {
        private readonly BoardTiles boardTiles;

        public Board() {
            boardTiles = new BoardTiles();
        }

        public MovementResult Move(SymbolPlayer symbolPlayer, Coordinates coordinates) {
            return boardTiles.AddTile(symbolPlayer.GetSymbol(), coordinates);
        }
    }
}