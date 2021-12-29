using TicTacToe.Exceptions;

namespace TicTacToe {
    public class BoardTiles {
        private char[,] tiles;

        public BoardTiles() {
            tiles = new char[3, 3];
            InitializeTiles();
        }

        public void AddTile(char symbol, Coordinates coordinates) {
            if(tiles[coordinates.X, coordinates.Y] != ' ') {
                throw new PositionAlreadyInUseException();
            }

            tiles[coordinates.X, coordinates.Y] = symbol;
        }

        private void InitializeTiles() {
            for (var i = 0; i < 3; i++) {
                for (var j = 0; j < 3; j++) {
                    tiles[i, j] = ' ';
                }
            }
        }
    }
}