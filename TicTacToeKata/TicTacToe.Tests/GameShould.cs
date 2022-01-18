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
            Action wrongPlayer = () => Play(new SymbolPlayer(Symbol.O), BoardPosition.TopLeft);

            wrongPlayer.Should().Throw<MovementCouldNotBeCompletedException>().And.Reason.Should().Be(MovementErrorReason.WrongFirstPlayer);
        }

        [Test]
        public void players_can_not_move_twice() {
            Play(new SymbolPlayer(Symbol.X), BoardPosition.TopLeft);
            Action wrongPlayerTurn = () => Play(new SymbolPlayer(Symbol.X), BoardPosition.TopMiddle);

            wrongPlayerTurn.Should().Throw<MovementCouldNotBeCompletedException>().And.Reason.Should().Be(MovementErrorReason.NoPlayerTurn);
        }

        [Test]
        public void players_can_not_move_twice_in_the_same_position() {
            Play(new SymbolPlayer(Symbol.X), BoardPosition.TopLeft);
            Action wrongMovement = () => Play(new SymbolPlayer(Symbol.O), BoardPosition.TopLeft);

            wrongMovement.Should().Throw<MovementCouldNotBeCompletedException>().And.Reason.Should().Be(MovementErrorReason.PositionAlreadyInUse);
        }

        [Test]
        public void player_win_if_has_three_tiles_in_vertical_line() {
            var expectedGameResult = new GameResult(true, Symbol.X);
            Play(new SymbolPlayer(Symbol.X), BoardPosition.TopLeft);
            Play(new SymbolPlayer(Symbol.O), BoardPosition.TopMiddle);
            Play(new SymbolPlayer(Symbol.X), BoardPosition.MidLeft);
            Play(new SymbolPlayer(Symbol.O), BoardPosition.MidMiddle);
            
            var playResult = Play(new SymbolPlayer(Symbol.X), BoardPosition.BottomLeft);

            playResult.Should().BeEquivalentTo(expectedGameResult);
        }

        [Test]
        public void player_win_if_has_three_tiles_in_horizontal_line() {
            var expectedGameResult = new GameResult(true, Symbol.X);
            Play(new SymbolPlayer(Symbol.X), BoardPosition.TopLeft);
            Play(new SymbolPlayer(Symbol.O), BoardPosition.MidLeft);
            Play(new SymbolPlayer(Symbol.X), BoardPosition.TopMiddle);
            Play(new SymbolPlayer(Symbol.O), BoardPosition.MidMiddle);

            var playResult = Play(new SymbolPlayer(Symbol.X), BoardPosition.TopRight);

            playResult.Should().BeEquivalentTo(expectedGameResult);
        }

        [Test]
        public void player_win_if_has_three_tiles_in_diagonal_line() {
            var expectedGameResult = new GameResult(true, Symbol.X);
            Play(new SymbolPlayer(Symbol.X), BoardPosition.TopLeft);
            Play(new SymbolPlayer(Symbol.O), BoardPosition.TopMiddle);
            Play(new SymbolPlayer(Symbol.X), BoardPosition.MidMiddle);
            Play(new SymbolPlayer(Symbol.O), BoardPosition.TopRight);

            var playResult = Play(new SymbolPlayer(Symbol.X), BoardPosition.BottomRight);

            playResult.Should().BeEquivalentTo(expectedGameResult);
        }

        [Test]
        public void game_ended_tied_if_all_tiles_are_filled_and_there_is_no_winner() {
            var expectedGameResult = new GameResult(true, Symbol.NoPlayer);
            Play(new SymbolPlayer(Symbol.X), BoardPosition.MidMiddle);
            Play(new SymbolPlayer(Symbol.O), BoardPosition.BottomMiddle);
            Play(new SymbolPlayer(Symbol.X), BoardPosition.BottomLeft);
            Play(new SymbolPlayer(Symbol.O), BoardPosition.TopRight);
            Play(new SymbolPlayer(Symbol.X), BoardPosition.BottomRight);
            Play(new SymbolPlayer(Symbol.O), BoardPosition.TopLeft);
            Play(new SymbolPlayer(Symbol.X), BoardPosition.MidLeft);
            Play(new SymbolPlayer(Symbol.O), BoardPosition.MidRight);
            var playResult = Play(new SymbolPlayer(Symbol.X), BoardPosition.TopMiddle);

            playResult.Should().BeEquivalentTo(expectedGameResult);
        }

        [Test]
        public void players_can_not_move_when_there_is_a_winner() {
            Play(new SymbolPlayer(Symbol.X), BoardPosition.TopLeft);
            Play(new SymbolPlayer(Symbol.O), BoardPosition.TopMiddle);
            Play(new SymbolPlayer(Symbol.X), BoardPosition.MidMiddle);
            Play(new SymbolPlayer(Symbol.O), BoardPosition.TopRight);
            Play(new SymbolPlayer(Symbol.X), BoardPosition.BottomRight);
            Action wrongPlayerTurn = () => Play(new SymbolPlayer(Symbol.O), BoardPosition.MidLeft);

            wrongPlayerTurn.Should().Throw<MovementCouldNotBeCompletedException>().And.Reason.Should().Be(MovementErrorReason.GameIsFinished);
        }

        [Test]
        public void players_can_not_move_when_all_tiles_are_filled_and_there_is_no_winner() {
            Play(new SymbolPlayer(Symbol.X), BoardPosition.MidMiddle);
            Play(new SymbolPlayer(Symbol.O), BoardPosition.BottomMiddle);
            Play(new SymbolPlayer(Symbol.X), BoardPosition.BottomLeft);
            Play(new SymbolPlayer(Symbol.O), BoardPosition.TopRight);
            Play(new SymbolPlayer(Symbol.X), BoardPosition.BottomRight);
            Play(new SymbolPlayer(Symbol.O), BoardPosition.TopLeft);
            Play(new SymbolPlayer(Symbol.X), BoardPosition.MidLeft);
            Play(new SymbolPlayer(Symbol.O), BoardPosition.MidRight);
            Play(new SymbolPlayer(Symbol.X), BoardPosition.TopMiddle);

            Action wrongPlayerTurn = () => Play(new SymbolPlayer(Symbol.O), BoardPosition.BottomMiddle);

            wrongPlayerTurn.Should().Throw<MovementCouldNotBeCompletedException>().And.Reason.Should().Be(MovementErrorReason.GameIsFinished);
        }

        private GameResult Play(SymbolPlayer symbolPlayer, BoardPosition boardPosition) {
            return game.Play(symbolPlayer, boardPosition);
        }
    }
}
