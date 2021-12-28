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
            Action wrongPlayer = () => game.Play('O', 0, 0);

            wrongPlayer.Should().Throw<MovementCouldNotBeCompletedException>().And.Reason.Should().Be(MovementErrorReason.WrongFirstPlayer);
        }
    }
}
