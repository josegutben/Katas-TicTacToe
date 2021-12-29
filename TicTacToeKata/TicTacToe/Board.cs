using System.ComponentModel.Design;

namespace TicTacToe {
    public class Board {
        public char[,] Tiles { get; set; }

        public Board() {
            Tiles = Initialize();
        }

        private char[,] Initialize() {
            var tiles = new char[3,3];
            for (int i = 0; i < 3; i++) {
                for (int j = 0; j < 3; j++) {
                    tiles[i, j] = ' ';
                }
            }

            return tiles;
        }
    }
}