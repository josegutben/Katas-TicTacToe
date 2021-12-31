using TicTacToe.Exceptions;

namespace TicTacToe {
    public class Game {
        private readonly Board board;
        private SymbolPlayer lastSymbol;

        public Game() {
            board = new Board();
            lastSymbol = new SymbolPlayer(' ');
        }

        public GameResult Play(SymbolPlayer symbolPlayer, Coordinates coordinates) {
            CheckMovement(symbolPlayer);
            var movementResult = TryToMove(symbolPlayer, coordinates);
            return CheckGameResult(movementResult);
        }

        private void CheckMovement(SymbolPlayer symbolPlayer) {
            if(IsOFirstPlayer(symbolPlayer)) {
                throw new MovementCouldNotBeCompletedException(MovementErrorReason.WrongFirstPlayer);
            }

            if(IsNoTurnForPlayer(symbolPlayer)) {
                throw new MovementCouldNotBeCompletedException(MovementErrorReason.NoPlayerTurn);
            }
        }

        private MovementResult TryToMove(SymbolPlayer symbolPlayer, Coordinates coordinates) {
            try {
                var movementResult = board.Move(symbolPlayer, coordinates);
                lastSymbol = symbolPlayer;
                return movementResult;
            }
            catch (PositionAlreadyInUseException) {
                throw new MovementCouldNotBeCompletedException(MovementErrorReason.PositionAlreadyInUse);
            }
            catch (SameSymbolInLineException) {
                throw new MovementCouldNotBeCompletedException(MovementErrorReason.GameIsFinished);
            }
            catch(ThereIsAlreadyAWinnerException) {
                throw new MovementCouldNotBeCompletedException(MovementErrorReason.GameIsFinished);
            }
        }

        private GameResult CheckGameResult(MovementResult movementResult) {
            var playerWinnerSymbol = new SymbolPlayer(' ');
            var gameIsFinished = false;

            if(movementResult.ThereIsAWinner()) {
                playerWinnerSymbol = lastSymbol;
                gameIsFinished = true;
            }

            if(movementResult.BoardIsFull()) {
                gameIsFinished = true;
            }

            return new GameResult(gameIsFinished, playerWinnerSymbol.GetSymbol());
        }

        private bool IsNoTurnForPlayer(SymbolPlayer symbolPlayer) {
            return lastSymbol.Equals(symbolPlayer);
        }

        private bool IsOFirstPlayer(SymbolPlayer symbolPlayer) {
            return lastSymbol.IsEmpty() && symbolPlayer.IsOPlayer();
        }
    }
}