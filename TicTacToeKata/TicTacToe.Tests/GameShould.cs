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

        private void Play(SymbolPlayer symbolPlayer, int x, int y) {
            game.Play(symbolPlayer, x, y);
        }
    }
}
