

using TennisScore.Models;
using TennisScore.Services;

TennisGame game = new TennisGame(
    new Player() { PlayerName = "Player1"}, 
    new Player() { PlayerName = "Player2" }
    );


game.StartGame();
