using TicTacToe.Exceptions;

namespace TicTacToe {
    public class Board {
        private readonly PlayedPositions playedPositions;

        public Board() {
            playedPositions = new PlayedPositions();
        }

        public MovementResultDto Move(SymbolPlayer symbolPlayer, BoardPosition boardPosition) {
            try {
                return playedPositions.Add(boardPosition, symbolPlayer);
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
    }
}