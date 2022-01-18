using System.Collections.Generic;
using System.Linq;
using TicTacToe.Exceptions;

namespace TicTacToe {
    public class PlayedPositions {
        private readonly Dictionary<BoardPosition, Symbol> playedPositions;
        private readonly List<BoardPosition> winnerTopHorizontal = new List<BoardPosition> { BoardPosition.TopRight, BoardPosition.TopMiddle, BoardPosition.TopLeft };
        private readonly List<BoardPosition> winnerMiddleHorizontal = new List<BoardPosition> { BoardPosition.MidRight, BoardPosition.MidMiddle, BoardPosition.MidLeft };
        private readonly List<BoardPosition> winnerBottomHorizontal = new List<BoardPosition> { BoardPosition.BottomLeft, BoardPosition.BottomMiddle, BoardPosition. BottomRight };
        private readonly List<BoardPosition> winnerLeftVertical = new List<BoardPosition> { BoardPosition.TopLeft, BoardPosition.MidLeft, BoardPosition.BottomLeft };
        private readonly List<BoardPosition> winnerMiddleVertical = new List<BoardPosition> { BoardPosition.TopMiddle, BoardPosition.MidMiddle, BoardPosition.BottomMiddle };
        private readonly List<BoardPosition> winnerRightVertical = new List<BoardPosition> { BoardPosition.TopRight, BoardPosition.MidRight, BoardPosition.BottomRight };
        private readonly List<BoardPosition> winnerLeftDiagonal = new List<BoardPosition> { BoardPosition.TopLeft, BoardPosition.MidMiddle, BoardPosition.BottomRight };
        private readonly List<BoardPosition> winnerRightDiagonal = new List<BoardPosition> { BoardPosition.TopRight, BoardPosition.MidMiddle, BoardPosition.BottomLeft };

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

            
            var all = winnerLeftVertical.All(x => playedPositions.ContainsKey(x) && playedPositions[x] == symbol);
            var b = winnerMiddleVertical.All(x => playedPositions.ContainsKey(x) && playedPositions[x] == symbol);
            var all1 = winnerRightVertical.All(x => playedPositions.ContainsKey(x) && playedPositions[x] == symbol);
            return all ||
                   b ||
                   all1;
        }

        private bool SameSymbolInHorizontalFor(Symbol symbol) {
            var all = winnerTopHorizontal.All(x => playedPositions.ContainsKey(x) && playedPositions[x] == symbol);
            var b = winnerMiddleHorizontal.All(x => playedPositions.ContainsKey(x) && playedPositions[x] == symbol);
            var all1 = winnerBottomHorizontal.All(x => playedPositions.ContainsKey(x) && playedPositions[x] == symbol);
            return all ||
                   b ||
                   all1;

            /*return playedPositions.All(x => winnerTopHorizontal.Contains(x.Key) && x.Value == symbol) ||
                   playedPositions.All(x => winnerMiddleHorizontal.Contains(x.Key) && x.Value == symbol) ||
                   playedPositions.All(x => winnerBottomHorizontal.Contains(x.Key) && x.Value == symbol);*/
        }

        private bool SameSymbolInDiagonalFor(Symbol symbol) {
            var all = winnerLeftDiagonal.All(x => playedPositions.ContainsKey(x) && playedPositions[x] == symbol);
            var b = winnerMiddleHorizontal.All(x => playedPositions.ContainsKey(x) && playedPositions[x] == symbol);
            return all ||
                   b;
        }
    }
}