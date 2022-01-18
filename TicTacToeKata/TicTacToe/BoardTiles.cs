using System.Collections.Generic;
using TicTacToe.Exceptions;

namespace TicTacToe {
    public class BoardTiles {
        private readonly Dictionary<BoardPosition, SymbolPlayer> playedPositions;

        public BoardTiles() {
            playedPositions = new Dictionary<BoardPosition, SymbolPlayer>();
        }

        public MovementResultDto AddTile(SymbolPlayer symbolPlayer, BoardPosition boardPosition) {
            CheckBoardTilesStatus();
            CheckPosition(boardPosition);

            playedPositions.Add(boardPosition, symbolPlayer);

            return new MovementResultDto {
                SameSymbolInLine = SameSymbolInLine(),
                BoardIsFull = AllTilesAreFull()
            };
        }

        private void CheckBoardTilesStatus() {
            if (SameSymbolInLine()) {
                throw new SameSymbolInLineException();
            }

            if (AllTilesAreFull()) {
                throw new ThereIsAlreadyAWinnerException();
            }
        }

        private void CheckPosition(BoardPosition boardPosition) {
            if(playedPositions.ContainsKey(boardPosition)) {
                throw new PositionAlreadyInUseException();
            }
        }

        private bool SameSymbolInLine() {
            return SameSymbolInVertical() || SameSymbolInHorizontal() || SameSymbolInDiagonal();
        }

        private bool AllTilesAreFull() {
            return playedPositions.Count == 9;
        }

        private bool SameSymbolInVertical() {
            return (playedPositions.ContainsKey(BoardPosition.TopRight) &&
                    playedPositions.ContainsKey(BoardPosition.MidRight) &&
                    playedPositions.ContainsKey(BoardPosition.BottomRight) &&
                    playedPositions[BoardPosition.TopRight] == playedPositions[BoardPosition.MidRight] &&
                    playedPositions[BoardPosition.MidRight] == playedPositions[BoardPosition.BottomRight])
                   ||
                   (playedPositions.ContainsKey(BoardPosition.TopMiddle) &&
                    playedPositions.ContainsKey(BoardPosition.MidMiddle) &&
                    playedPositions.ContainsKey(BoardPosition.BottomMiddle) &&
                    playedPositions[BoardPosition.TopMiddle] == playedPositions[BoardPosition.MidMiddle] &&
                    playedPositions[BoardPosition.MidMiddle] == playedPositions[BoardPosition.BottomMiddle])
                   ||
                   (playedPositions.ContainsKey(BoardPosition.TopLeft) &&
                    playedPositions.ContainsKey(BoardPosition.MidLeft) &&
                    playedPositions.ContainsKey(BoardPosition.BottomLeft) &&
                    playedPositions[BoardPosition.TopLeft] == playedPositions[BoardPosition.MidLeft] &&
                    playedPositions[BoardPosition.MidLeft] == playedPositions[BoardPosition.BottomLeft]);
        }

        private bool SameSymbolInHorizontal() {
            return (playedPositions.ContainsKey(BoardPosition.TopRight) &&
                    playedPositions.ContainsKey(BoardPosition.TopMiddle) &&
                    playedPositions.ContainsKey(BoardPosition.TopLeft) &&
                    playedPositions[BoardPosition.TopRight] == playedPositions[BoardPosition.TopMiddle] &&
                    playedPositions[BoardPosition.TopMiddle] == playedPositions[BoardPosition.TopLeft])
                   ||
                   (playedPositions.ContainsKey(BoardPosition.MidRight) &&
                    playedPositions.ContainsKey(BoardPosition.MidMiddle) &&
                    playedPositions.ContainsKey(BoardPosition.MidLeft) &&
                    playedPositions[BoardPosition.MidRight] == playedPositions[BoardPosition.MidMiddle] &&
                    playedPositions[BoardPosition.MidMiddle] == playedPositions[BoardPosition.MidLeft])
                   ||
                   (playedPositions.ContainsKey(BoardPosition.BottomRight) &&
                    playedPositions.ContainsKey(BoardPosition.BottomMiddle) &&
                    playedPositions.ContainsKey(BoardPosition.BottomLeft) &&
                    playedPositions[BoardPosition.BottomRight] == playedPositions[BoardPosition.BottomMiddle] &&
                    playedPositions[BoardPosition.BottomMiddle] == playedPositions[BoardPosition.BottomLeft]);
        }

        private bool SameSymbolInDiagonal() {
            return (playedPositions.ContainsKey(BoardPosition.TopRight) &&
                    playedPositions.ContainsKey(BoardPosition.MidMiddle) &&
                    playedPositions.ContainsKey(BoardPosition.BottomLeft) &&
                    playedPositions[BoardPosition.TopRight] == playedPositions[BoardPosition.MidMiddle] &&
                    playedPositions[BoardPosition.MidMiddle] == playedPositions[BoardPosition.BottomLeft])
                   ||
                   (playedPositions.ContainsKey(BoardPosition.TopLeft) &&
                    playedPositions.ContainsKey(BoardPosition.MidMiddle) &&
                    playedPositions.ContainsKey(BoardPosition.BottomRight) &&
                    playedPositions[BoardPosition.TopLeft] == playedPositions[BoardPosition.MidMiddle] &&
                    playedPositions[BoardPosition.MidMiddle] == playedPositions[BoardPosition.BottomRight]);
        }
    }
}