﻿using System.Collections.Generic;
using TicTacToe.Exceptions;

namespace TicTacToe {
    public class PlayedPositions {
        private readonly Dictionary<BoardPosition, SymbolPlayer> playedPositions;

        public PlayedPositions() {
            playedPositions = new Dictionary<BoardPosition, SymbolPlayer>();
        }

        public void Add(BoardPosition boardPosition, SymbolPlayer symbolPlayer) {
            if (playedPositions.ContainsKey(boardPosition)) {
                throw new PositionAlreadyInUseException();
            }
            
            playedPositions.Add(boardPosition, symbolPlayer);
        }

        public bool SameSymbolInLine() {
            return SameSymbolInVertical() || SameSymbolInHorizontal() || SameSymbolInDiagonal();
        }

        public bool AllTilesAreFull() {
            return playedPositions.Count == 9;
        }

        private bool SameSymbolInVertical() {
            return (playedPositions.ContainsKey(BoardPosition.TopRight) && 
                    playedPositions.ContainsKey(BoardPosition.MidRight) && 
                    playedPositions.ContainsKey(BoardPosition.BottomRight) && 
                    playedPositions[BoardPosition.TopRight].Equals(playedPositions[BoardPosition.MidRight]) && 
                    playedPositions[BoardPosition.MidRight].Equals(playedPositions[BoardPosition.BottomRight]))
                   ||
                   (playedPositions.ContainsKey(BoardPosition.TopMiddle) && 
                    playedPositions.ContainsKey(BoardPosition.MidMiddle) && 
                    playedPositions.ContainsKey(BoardPosition.BottomMiddle) && 
                    playedPositions[BoardPosition.TopMiddle].Equals(playedPositions[BoardPosition.MidMiddle]) && 
                    playedPositions[BoardPosition.MidMiddle].Equals(playedPositions[BoardPosition.BottomMiddle]))
                   ||
                   (playedPositions.ContainsKey(BoardPosition.TopLeft) && 
                    playedPositions.ContainsKey(BoardPosition.MidLeft) && 
                    playedPositions.ContainsKey(BoardPosition.BottomLeft) && 
                    playedPositions[BoardPosition.TopLeft].Equals(playedPositions[BoardPosition.MidLeft]) 
                    && playedPositions[BoardPosition.MidLeft].Equals(playedPositions[BoardPosition.BottomLeft]));
        }

        private bool SameSymbolInHorizontal() {
            return (playedPositions.ContainsKey(BoardPosition.TopRight) && 
                    playedPositions.ContainsKey(BoardPosition.TopMiddle) && 
                    playedPositions.ContainsKey(BoardPosition.TopLeft) && 
                    playedPositions[BoardPosition.TopRight].Equals(playedPositions[BoardPosition.TopMiddle]) && 
                    playedPositions[BoardPosition.TopMiddle].Equals(playedPositions[BoardPosition.TopLeft]))
                   ||
                   (playedPositions.ContainsKey(BoardPosition.MidRight) && 
                    playedPositions.ContainsKey(BoardPosition.MidMiddle) && 
                    playedPositions.ContainsKey(BoardPosition.MidLeft) && 
                    playedPositions[BoardPosition.MidRight].Equals(playedPositions[BoardPosition.MidMiddle]) && 
                    playedPositions[BoardPosition.MidMiddle].Equals(playedPositions[BoardPosition.MidLeft]))
                   ||
                   (playedPositions.ContainsKey(BoardPosition.BottomRight) && 
                    playedPositions.ContainsKey(BoardPosition.BottomMiddle) && 
                    playedPositions.ContainsKey(BoardPosition.BottomLeft) && 
                    playedPositions[BoardPosition.BottomRight].Equals(playedPositions[BoardPosition.BottomMiddle]) && 
                    playedPositions[BoardPosition.BottomMiddle].Equals(playedPositions[BoardPosition.BottomLeft]));
        }

        private bool SameSymbolInDiagonal() {
            return (playedPositions.ContainsKey(BoardPosition.TopRight) && 
                    playedPositions.ContainsKey(BoardPosition.MidMiddle) && 
                    playedPositions.ContainsKey(BoardPosition.BottomLeft) && 
                    playedPositions[BoardPosition.TopRight].Equals(playedPositions[BoardPosition.MidMiddle]) && 
                    playedPositions[BoardPosition.MidMiddle].Equals(playedPositions[BoardPosition.BottomLeft]))
                   ||
                   (playedPositions.ContainsKey(BoardPosition.TopLeft) && 
                    playedPositions.ContainsKey(BoardPosition.MidMiddle) && 
                    playedPositions.ContainsKey(BoardPosition.BottomRight) && 
                    playedPositions[BoardPosition.TopLeft].Equals(playedPositions[BoardPosition.MidMiddle]) && 
                    playedPositions[BoardPosition.MidMiddle].Equals(playedPositions[BoardPosition.BottomRight]));
        }
    }
}