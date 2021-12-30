using TicTacToe.Exceptions;

namespace TicTacToe {
    public class BoardTiles {
        private readonly char[,] tiles;

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

        public bool SameSymbolInLine() {
            return SameSymbolInVertical() || SameSymbolInHorizontal() || SameSymbolInDiagonal();
        }

        private void InitializeTiles() {
            for (var i = 0; i < 3; i++) {
                for (var j = 0; j < 3; j++) {
                    tiles[i, j] = ' ';
                }
            }
        }

        private bool SameSymbolInVertical() {
            return (tiles[0, 0] == tiles[0, 1] && tiles[0, 1] == tiles[0, 2]) ||
                   (tiles[1, 0] == tiles[1, 1] && tiles[1, 1] == tiles[1, 2]) ||
                   (tiles[2, 0] == tiles[2, 1] && tiles[2, 1] == tiles[2, 2]);
        }

        private bool SameSymbolInHorizontal() {
            return (tiles[0, 0] == tiles[1, 0] && tiles[1, 0] == tiles[2, 0]) ||
                   (tiles[0, 1] == tiles[1, 1] && tiles[1, 1] == tiles[2, 1]) ||
                   (tiles[0, 2] == tiles[1, 2] && tiles[1, 2] == tiles[2, 2]);
        }

        private bool SameSymbolInDiagonal() {
            return (tiles[0, 0] == tiles[1, 1] && tiles[1, 1] == tiles[2, 2]) ||
                   (tiles[0, 2] == tiles[1, 1] && tiles[1, 1] == tiles[2, 0]);
        }
    }
}