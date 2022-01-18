using TicTacToe.Exceptions;

namespace TicTacToe {
    public class Board {
        private readonly BoardTiles boardTiles;

        public Board() {
            boardTiles = new BoardTiles();
        }

        public MovementResultDto Move(SymbolPlayer symbolPlayer, BoardPosition boardPosition) {
            try {
                return boardTiles.AddTile(symbolPlayer, boardPosition);
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