using TicTacToe.Exceptions;

namespace TicTacToe {
    public class Game {
        private Board board;
        private SymbolPlayer lastSymbol;

        public Game() {
            board = new Board();
            lastSymbol = new SymbolPlayer(' ');
        }

        public void Play(SymbolPlayer symbolPlayer, int x, int y) {
            CheckMovement(symbolPlayer);
            if(board.Tiles[x, y] != ' ')
            {
                throw new MovementCouldNotBeCompletedException(MovementErrorReason.PositionAlreadyInUse);
            }
            board.Tiles[x, y] = symbolPlayer.GetSymbol();
            lastSymbol = symbolPlayer;
        }

        private void CheckMovement(SymbolPlayer symbolPlayer) {
            if (IsOFirstPlayer(symbolPlayer)) {
                throw new MovementCouldNotBeCompletedException(MovementErrorReason.WrongFirstPlayer);
            }

            if (IsNoTurnForPlayer(symbolPlayer)) {
                throw new MovementCouldNotBeCompletedException(MovementErrorReason.NoPlayerTurn);
            }
        }

        private bool IsNoTurnForPlayer(SymbolPlayer symbolPlayer) {
            return lastSymbol.Equals(symbolPlayer);
        }

        private bool IsOFirstPlayer(SymbolPlayer symbolPlayer) {
            return lastSymbol.IsEmpty() && symbolPlayer.IsOPlayer();
        }
    }
}