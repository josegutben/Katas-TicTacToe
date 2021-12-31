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
            Action wrongPlayer = () => Play(new SymbolPlayer(Symbol.O), 0, 0);

            wrongPlayer.Should().Throw<MovementCouldNotBeCompletedException>().And.Reason.Should().Be(MovementErrorReason.WrongFirstPlayer);
        }

        [Test]
        public void players_can_not_move_twice() {
            Play(new SymbolPlayer(Symbol.X), 0, 0);
            Action wrongPlayerTurn = () => Play(new SymbolPlayer(Symbol.X), 0, 1);

            wrongPlayerTurn.Should().Throw<MovementCouldNotBeCompletedException>().And.Reason.Should().Be(MovementErrorReason.NoPlayerTurn);
        }

        [Test]
        public void players_can_not_move_twice_in_the_same_position() {
            Play(new SymbolPlayer(Symbol.X), 0, 0);
            Action wrongMovement = () => Play(new SymbolPlayer(Symbol.O), 0, 0);

            wrongMovement.Should().Throw<MovementCouldNotBeCompletedException>().And.Reason.Should().Be(MovementErrorReason.PositionAlreadyInUse);
        }

        [Test]
        public void player_win_if_has_three_tiles_in_vertical_line() {
            var expectedGameResult = new GameResult(true, Symbol.X);
            Play(new SymbolPlayer(Symbol.X), 0, 0);
            Play(new SymbolPlayer(Symbol.O), 1, 0);
            Play(new SymbolPlayer(Symbol.X), 0, 1);
            Play(new SymbolPlayer(Symbol.O), 1, 1);
            
            var playResult = Play(new SymbolPlayer(Symbol.X), 0, 2);

            playResult.Should().BeEquivalentTo(expectedGameResult);
        }

        [Test]
        public void player_win_if_has_three_tiles_in_horizontal_line() {
            var expectedGameResult = new GameResult(true, Symbol.X);
            Play(new SymbolPlayer(Symbol.X), 0, 0);
            Play(new SymbolPlayer(Symbol.O), 0, 1);
            Play(new SymbolPlayer(Symbol.X), 1, 0);
            Play(new SymbolPlayer(Symbol.O), 0, 2);

            var playResult = Play(new SymbolPlayer(Symbol.X), 2, 0);

            playResult.Should().BeEquivalentTo(expectedGameResult);
        }

        [Test]
        public void player_win_if_has_three_tiles_in_diagonal_line() {
            var expectedGameResult = new GameResult(true, Symbol.X);
            Play(new SymbolPlayer(Symbol.X), 0, 0);
            Play(new SymbolPlayer(Symbol.O), 0, 1);
            Play(new SymbolPlayer(Symbol.X), 1, 1);
            Play(new SymbolPlayer(Symbol.O), 0, 2);

            var playResult = Play(new SymbolPlayer(Symbol.X), 2, 2);

            playResult.Should().BeEquivalentTo(expectedGameResult);
        }

        [Test]
        public void game_ended_tied_if_all_tiles_are_filled_and_there_is_no_winner() {
            var expectedGameResult = new GameResult(true, Symbol.NoPlayer);
            Play(new SymbolPlayer(Symbol.X), 1, 1);
            Play(new SymbolPlayer(Symbol.O), 2, 1);
            Play(new SymbolPlayer(Symbol.X), 2, 0);
            Play(new SymbolPlayer(Symbol.O), 0, 2);
            Play(new SymbolPlayer(Symbol.X), 2, 2);
            Play(new SymbolPlayer(Symbol.O), 0, 0);
            Play(new SymbolPlayer(Symbol.X), 1, 0);
            Play(new SymbolPlayer(Symbol.O), 1, 2);
            var playResult = Play(new SymbolPlayer(Symbol.X), 0, 1);

            playResult.Should().BeEquivalentTo(expectedGameResult);
        }

        [Test]
        public void players_can_not_move_when_there_is_a_winner() {
            Play(new SymbolPlayer(Symbol.X), 0, 0);
            Play(new SymbolPlayer(Symbol.O), 0, 1);
            Play(new SymbolPlayer(Symbol.X), 1, 1);
            Play(new SymbolPlayer(Symbol.O), 0, 2);
            Play(new SymbolPlayer(Symbol.X), 2, 2);
            Action wrongPlayerTurn = () => Play(new SymbolPlayer(Symbol.O), 1, 0);

            wrongPlayerTurn.Should().Throw<MovementCouldNotBeCompletedException>().And.Reason.Should().Be(MovementErrorReason.GameIsFinished);
        }

        [Test]
        public void players_can_not_move_when_all_tiles_are_filled_and_there_is_no_winner() {
            Play(new SymbolPlayer(Symbol.X), 1, 1);
            Play(new SymbolPlayer(Symbol.O), 2, 1);
            Play(new SymbolPlayer(Symbol.X), 2, 0);
            Play(new SymbolPlayer(Symbol.O), 0, 2);
            Play(new SymbolPlayer(Symbol.X), 2, 2);
            Play(new SymbolPlayer(Symbol.O), 0, 0);
            Play(new SymbolPlayer(Symbol.X), 1, 0);
            Play(new SymbolPlayer(Symbol.O), 1, 2);
            Play(new SymbolPlayer(Symbol.X), 0, 1);

            Action wrongPlayerTurn = () => Play(new SymbolPlayer(Symbol.O), 2, 1);

            wrongPlayerTurn.Should().Throw<MovementCouldNotBeCompletedException>().And.Reason.Should().Be(MovementErrorReason.GameIsFinished);
        }

        private GameResult Play(SymbolPlayer symbolPlayer, int x, int y) {
            return game.Play(symbolPlayer, new Coordinates(x, y));
        }
    }
}
