using System;
using FluentAssertions;
using NUnit.Framework;
using TicTacToe.Exceptions;

namespace TicTacToe.Tests {
    [TestFixture]
    public class GameShould {
        private Game game;

        [SetUp]
        public void SetUp() {
            game = new Game();
        }

        [Test]
        public void o_player_can_not_be_the_first_player() {
            Action wrongPlayer = () => Play(new SymbolPlayer('O'), 0, 0);

            wrongPlayer.Should().Throw<MovementCouldNotBeCompletedException>().And.Reason.Should().Be(MovementErrorReason.WrongFirstPlayer);
        }

        [Test]
        public void players_can_not_move_twice() {
            Play(new SymbolPlayer('X'), 0, 0);
            Action wrongPlayerTurn = () => Play(new SymbolPlayer('X'), 0, 1);

            wrongPlayerTurn.Should().Throw<MovementCouldNotBeCompletedException>().And.Reason.Should().Be(MovementErrorReason.NoPlayerTurn);
        }

        [Test]
        public void players_can_not_move_twice_in_the_same_position() {
            Play(new SymbolPlayer('X'), 0, 0);
            Action wrongMovement = () => Play(new SymbolPlayer('O'), 0, 0);

            wrongMovement.Should().Throw<MovementCouldNotBeCompletedException>().And.Reason.Should().Be(MovementErrorReason.PositionAlreadyInUse);
        }

        [Test]
        public void player_win_if_has_three_tiles_in_horizontal_line() {
            var expectedGameResult = new GameResult(true, 'X');
            Play(new SymbolPlayer('X'), 0, 0);
            Play(new SymbolPlayer('O'), 1, 0);
            Play(new SymbolPlayer('X'), 0, 1);
            Play(new SymbolPlayer('O'), 1, 1);
            
            var playResult = Play(new SymbolPlayer('X'), 0, 2);

            playResult.Should().BeEquivalentTo(expectedGameResult);
        }

        private GameResult Play(SymbolPlayer symbolPlayer, int x, int y) {
            return game.Play(symbolPlayer, new Coordinates(x, y));
        }
    }
}
