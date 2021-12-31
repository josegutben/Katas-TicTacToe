using TicTacToe.Exceptions;

namespace TicTacToe {
    public class BoardTiles {
        private const int Size = 3;
        private const char EmptyTile = ' ';
        private readonly char[,] tiles;

        public BoardTiles() {
            tiles = new char[Size, Size];
            InitializeTiles();
        }

        public MovementResultDto AddTile(char symbol, Coordinates coordinates) {
            CheckBoardTilesStatus();
            CheckPosition(coordinates.X, coordinates.Y);

            tiles[coordinates.X, coordinates.Y] = symbol;

            return new MovementResultDto {
                SameSymbolInLine = SameSymbolInLine(),
                BoardIsFull = AllTilesAreFull()
            };
        }

        private void CheckBoardTilesStatus() {
            if (SameSymbolInLine()) {
                throw new SameSymbolInLineException();
            }

            if (AllTilesAreFull()) {
                throw new ThereIsAlreadyAWinnerException();
            }
        }

        private void CheckPosition(int line, int column) {
            if(tiles[line, column] != EmptyTile) {
                throw new PositionAlreadyInUseException();
            }
        }

        private void InitializeTiles() {
            for (var line = 0; line < Size; line++) {
                InitializeLine(line);
            }
        }

        private void InitializeLine(int line) {
            for (var column = 0; column < Size; column++) {
                tiles[line, column] = EmptyTile;
            }
        }

        private bool SameSymbolInLine() {
            return SameSymbolInVertical() || SameSymbolInHorizontal() || SameSymbolInDiagonal();
        }

        private bool AllTilesAreFull() {
            for(var line = 0; line < Size; line++) {
                if (!LineIsFull(line)) 
                    return false;
            }

            return true;
        }

        private bool LineIsFull(int line) {
            for (var column = 0; column < Size; column++) {
                if (TileIsEmpty(line, column)) 
                    return false;
            }

            return true;
        }

        private bool TileIsEmpty(int line, int column) {
            return tiles[line, column] == EmptyTile;
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