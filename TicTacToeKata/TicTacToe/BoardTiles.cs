using TicTacToe.Exceptions;

namespace TicTacToe {
    public class BoardTiles {
        private const int Size = 3;
        private readonly char[,] tiles;

        public BoardTiles() {
            tiles = new char[Size, Size];
            InitializeTiles();
        }

        public MovementResultDto AddTile(char symbol, Coordinates coordinates) {
            if (SameSymbolInLine()) {
                throw new SameSymbolInLineException();
            }

            if (AllTilesAreFull()) {
                throw new ThereIsAlreadyAWinnerException();
            }

            if(tiles[coordinates.X, coordinates.Y] != ' ') {
                throw new PositionAlreadyInUseException();
            }

            tiles[coordinates.X, coordinates.Y] = symbol;

            return new MovementResultDto {
                ThereIsAWinner = SameSymbolInLine(),
                BoardIsFull = AllTilesAreFull()
            };
        }

        private void InitializeTiles() {
            for (var line = 0; line < Size; line++) {
                InitializeLine(line);
            }
        }

        private void InitializeLine(int line) {
            for (var column = 0; column < Size; column++) {
                tiles[line, column] = ' ';
            }
        }

        private bool SameSymbolInLine() {
            return SameSymbolInVertical() || SameSymbolInHorizontal() || SameSymbolInDiagonal();
        }

        private bool AllTilesAreFull() {
            for(var i = 0; i < Size; i++) {
                for(var j = 0; j < Size; j++) {
                    if(tiles[i, j] == ' ')
                        return false;
                }
            }

            return true;
        }

        private bool SameSymbolInVertical() {
            return (tiles[0, 0] != ' ' && tiles[0, 0] == tiles[0, 1] && tiles[0, 1] == tiles[0, 2]) ||
                   (tiles[1, 0] != ' ' && tiles[1, 0] == tiles[1, 1] && tiles[1, 1] == tiles[1, 2]) ||
                   (tiles[2, 0] != ' ' && tiles[2, 0] == tiles[2, 1] && tiles[2, 1] == tiles[2, 2]);
        }

        private bool SameSymbolInHorizontal() {
            return (tiles[0, 0] != ' ' && tiles[0, 0] == tiles[1, 0] && tiles[1, 0] == tiles[2, 0]) ||
                   (tiles[0, 1] != ' ' && tiles[0, 1] == tiles[1, 1] && tiles[1, 1] == tiles[2, 1]) ||
                   (tiles[0, 2] != ' ' && tiles[0, 2] == tiles[1, 2] && tiles[1, 2] == tiles[2, 2]);
        }

        private bool SameSymbolInDiagonal() {
            return (tiles[0, 0] != ' ' && tiles[0, 0] == tiles[1, 1] && tiles[1, 1] == tiles[2, 2]) ||
                   (tiles[2, 0] != ' ' && tiles[0, 2] == tiles[1, 1] && tiles[1, 1] == tiles[2, 0]);
        }
    }
}