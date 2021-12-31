using TicTacToe.Exceptions;

namespace TicTacToe {
    public class Board {
        private readonly BoardTiles boardTiles;

        public Board() {
            boardTiles = new BoardTiles();
        }

        public MovementResult Move(char symbol, Coordinates coordinates) {
            try {
                return boardTiles.AddTile(symbol, coordinates);
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