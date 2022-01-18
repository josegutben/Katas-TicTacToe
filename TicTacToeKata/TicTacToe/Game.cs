using TicTacToe.Exceptions;

namespace TicTacToe {
    public class Game {
        private readonly Board board;
        private SymbolPlayer lastSymbol;

        public Game() {
            board = new Board();
            lastSymbol = new SymbolPlayer(Symbol.NoPlayer);
        }

        public GameResult Play(SymbolPlayer symbolPlayer, BoardPosition boardPosition) {
            CheckPlayer(symbolPlayer);
            var movementResult = TryToMove(symbolPlayer, boardPosition);
            return CheckGameResult(movementResult);
        }

        private void CheckPlayer(SymbolPlayer symbolPlayer) {
            if(IsOFirstPlayer(symbolPlayer)) {
                throw new MovementCouldNotBeCompletedException(MovementErrorReason.WrongFirstPlayer);
            }

            if(IsNoTurnFor(symbolPlayer)) {
                throw new MovementCouldNotBeCompletedException(MovementErrorReason.NoPlayerTurn);
            }
        }

        private MovementResultDto TryToMove(SymbolPlayer symbolPlayer, BoardPosition boardPosition) {
            try {
                var movementResult = board.Move(symbolPlayer, boardPosition);
                lastSymbol = symbolPlayer;
                return movementResult;
            }
            catch (BoardException ex) {
                throw new MovementCouldNotBeCompletedException(ex.Reason);
            }
        }

        private GameResult CheckGameResult(MovementResultDto movementResultDto) {
            var playerWinnerSymbol = new SymbolPlayer(Symbol.NoPlayer);
            var gameIsFinished = false;

            if(movementResultDto.SameSymbolInLine) {
                playerWinnerSymbol = lastSymbol;
                gameIsFinished = true;
            }

            if(movementResultDto.BoardIsFull) {
                gameIsFinished = true;
            }

            return new GameResult(gameIsFinished, playerWinnerSymbol.GetSymbol());
        }

        private bool IsNoTurnFor(SymbolPlayer symbolPlayer) {
            return lastSymbol.Equals(symbolPlayer);
        }

        private bool IsOFirstPlayer(SymbolPlayer symbolPlayer) {
            return lastSymbol.IsEmpty() && symbolPlayer.IsOPlayer();
        }
    }
}