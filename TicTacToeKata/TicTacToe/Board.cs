using TicTacToe.Exceptions;

namespace TicTacToe {
    public class Board {
        private readonly PlayedPositions playedPositions;

        public Board() {
            playedPositions = new PlayedPositions();
        }

        public MovementResultDto Move(SymbolPlayer symbolPlayer, BoardPosition boardPosition) {
            try {
                CheckBoardTilesStatus();

                playedPositions.Add(boardPosition, symbolPlayer);

                return new MovementResultDto {
                    SameSymbolInLine = playedPositions.SameSymbolInLine(),
                    BoardIsFull = playedPositions.AllTilesAreFull()
                };
            }
            catch (PositionAlreadyInUseException) {
                throw new BoardException(MovementErrorReason.PositionAlreadyInUse);
            }
            catch (SameSymbolInLineException) {
                throw new BoardException(MovementErrorReason.GameIsFinished);
            }
            catch(ThereIsAlreadyAWinnerException) {
                throw new BoardException(MovementErrorReason.GameIsFinished);
            }
        }

        private void CheckBoardTilesStatus() {
            if(playedPositions.SameSymbolInLine()) {
                throw new SameSymbolInLineException();
            }

            if(playedPositions.AllTilesAreFull()) {
                throw new ThereIsAlreadyAWinnerException();
            }
        }
    }
}