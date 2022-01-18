using System.Collections.Generic;
using TicTacToe.Exceptions;

namespace TicTacToe {
    public class PlayedPositions {
        private readonly Dictionary<BoardPosition, Symbol> playedPositions;
        private readonly WinningPlays winnerTopHorizontal = new WinningPlays(new List<BoardPosition> { BoardPosition.TopRight, BoardPosition.TopMiddle, BoardPosition.TopLeft });
        private readonly WinningPlays winnerMiddleHorizontal = new WinningPlays(new List<BoardPosition> { BoardPosition.MidRight, BoardPosition.MidMiddle, BoardPosition.MidLeft });
        private readonly WinningPlays winnerBottomHorizontal = new WinningPlays(new List<BoardPosition> { BoardPosition.BottomLeft, BoardPosition.BottomMiddle, BoardPosition. BottomRight });
        private readonly WinningPlays winnerLeftVertical = new WinningPlays(new List<BoardPosition> { BoardPosition.TopLeft, BoardPosition.MidLeft, BoardPosition.BottomLeft });
        private readonly WinningPlays winnerMiddleVertical = new WinningPlays(new List<BoardPosition> { BoardPosition.TopMiddle, BoardPosition.MidMiddle, BoardPosition.BottomMiddle });
        private readonly WinningPlays winnerRightVertical = new WinningPlays(new List<BoardPosition> { BoardPosition.TopRight, BoardPosition.MidRight, BoardPosition.BottomRight });
        private readonly WinningPlays winnerLeftDiagonal = new WinningPlays(new List<BoardPosition> { BoardPosition.TopLeft, BoardPosition.MidMiddle, BoardPosition.BottomRight });
        private readonly WinningPlays winnerRightDiagonal = new WinningPlays(new List<BoardPosition> { BoardPosition.TopRight, BoardPosition.MidMiddle, BoardPosition.BottomLeft });

        public PlayedPositions() {
            playedPositions = new Dictionary<BoardPosition, Symbol>();
        }

        public MovementResultDto Add(BoardPosition boardPosition, SymbolPlayer symbolPlayer) {
            CheckPreviousPlayedPositions();
            CheckNextPosition(boardPosition);
            
            playedPositions.Add(boardPosition, symbolPlayer.GetSymbol());

            return new MovementResultDto {
                SameSymbolInLine = SameSymbolInLine(),
                BoardIsFull = AllTilesAreFull()
            };
        }

        private void CheckPreviousPlayedPositions() {
            if(SameSymbolInLine()) {
                throw new SameSymbolInLineException();
            }

            if(AllTilesAreFull()) {
                throw new ThereIsAlreadyAWinnerException();
            }
        }

        private void CheckNextPosition(BoardPosition boardPosition) {
            if (PositionIsAlreadyPlayed(boardPosition)) {
                throw new PositionAlreadyInUseException();
            }
        }

        private bool PositionIsAlreadyPlayed(BoardPosition boardPosition) {
            return playedPositions.ContainsKey(boardPosition);
        }

        private bool SameSymbolInLine() {
            return SameSymbolInVerticalFor(Symbol.X) || 
                   SameSymbolInVerticalFor(Symbol.O) || 
                   SameSymbolInHorizontalFor(Symbol.X) || 
                   SameSymbolInHorizontalFor(Symbol.O) || 
                   SameSymbolInDiagonalFor(Symbol.X) ||
                   SameSymbolInDiagonalFor(Symbol.O);
        }

        private bool AllTilesAreFull() {
            return playedPositions.Count == 9;
        }

        private bool SameSymbolInVerticalFor(Symbol symbol) {
            return winnerLeftVertical.IsWinner(playedPositions, symbol) ||
                   winnerMiddleVertical.IsWinner(playedPositions, symbol) ||
                   winnerRightVertical.IsWinner(playedPositions, symbol);
        }

        private bool SameSymbolInHorizontalFor(Symbol symbol) {
            return winnerTopHorizontal.IsWinner(playedPositions, symbol) ||
                   winnerMiddleHorizontal.IsWinner(playedPositions, symbol) ||
                   winnerBottomHorizontal.IsWinner(playedPositions, symbol);
        }

        private bool SameSymbolInDiagonalFor(Symbol symbol) {
            return winnerLeftDiagonal.IsWinner(playedPositions, symbol) ||
                   winnerMiddleHorizontal.IsWinner(playedPositions, symbol);
        }
    }
}