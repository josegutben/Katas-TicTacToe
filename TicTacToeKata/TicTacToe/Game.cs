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
            CheckPlayer(symbolPlayer);
            var movementResult = TryToMove(symbolPlayer, coordinates);
            return CheckGameResult(movementResult);
        }

        private void CheckPlayer(SymbolPlayer symbolPlayer) {
            if(IsOFirstPlayer(symbolPlayer)) {
                throw new MovementCouldNotBeCompletedException(MovementErrorReason.WrongFirstPlayer);
            }

            if(IsNoTurnForPlayer(symbolPlayer)) {
                throw new MovementCouldNotBeCompletedException(MovementErrorReason.NoPlayerTurn);
            }
        }

        private MovementResultDto TryToMove(SymbolPlayer symbolPlayer, Coordinates coordinates) {
            try {
                var movementResult = board.Move(symbolPlayer.GetSymbol(), coordinates);
                lastSymbol = symbolPlayer;
                return movementResult;
            }
            catch (BoardException ex) {
                throw new MovementCouldNotBeCompletedException(ex.Reason);
            }
        }

        private GameResult CheckGameResult(MovementResultDto movementResultDto) {
            var playerWinnerSymbol = new SymbolPlayer(' ');
            var gameIsFinished = false;

            if(movementResultDto.ThereIsAWinner) {
                playerWinnerSymbol = lastSymbol;
                gameIsFinished = true;
            }

            if(movementResultDto.BoardIsFull) {
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