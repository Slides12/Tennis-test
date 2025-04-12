

using TennisScore.Models;
using TennisScore.Services;

TennisGame game = new TennisGame(
    new Player() { PlayerName = "player1"}, 
    new Player() { PlayerName = "player2" }
    );


game.StartGame();


