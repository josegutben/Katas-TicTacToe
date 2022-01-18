using TicTacToe.Exceptions;

namespace TicTacToe {
    public class BoardTiles {
        private readonly PlayedPositions playedPositions;

        public BoardTiles() {
            playedPositions = new PlayedPositions();
        }

        public MovementResultDto AddTile(SymbolPlayer symbolPlayer, BoardPosition boardPosition) {
            CheckBoardTilesStatus();

            playedPositions.Add(boardPosition, symbolPlayer);

            return new MovementResultDto {
                SameSymbolInLine = playedPositions.SameSymbolInLine(),
                BoardIsFull = playedPositions.AllTilesAreFull()
            };
        }

        private void CheckBoardTilesStatus() {
            if (playedPositions.SameSymbolInLine()) {
                throw new SameSymbolInLineException();
            }

            if (playedPositions.AllTilesAreFull()) {
                throw new ThereIsAlreadyAWinnerException();
            }
        }
    }
}