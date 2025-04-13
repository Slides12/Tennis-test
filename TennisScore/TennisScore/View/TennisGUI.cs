using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisScore.Models;
using TennisScore.Services;

namespace TennisScore.View
{
    internal class TennisGUI
    {
        private Player player1;
        private Player player2;
        private TennisGame game;
        private bool deuce = false;

        public TennisGUI(Player player1, Player player2, TennisGame game)
        {
            this.player1 = player1;
            this.player2 = player2;
            this.game = game;
        }

        public void WriteScore()
        {
            
            Console.SetCursorPosition(30, 5);
            Console.WriteLine($"{player1.PlayerName}, Score:{player1.CurrentScore}|Set:{player1.Set} -||-  Set:{player2.Set}|Score:{player2.CurrentScore}, {player2.PlayerName}");
            Console.SetCursorPosition(50, 7);
            Console.WriteLine("Call");
            CheckGameWin();


            if (!deuce)
            {
                GetPlayerCall();
            }
            else
            {
                GetDeuceCall();
            }
        }

        private void GetPlayerCall()
        {
            if (player1.CurrentScore != player2.CurrentScore)
            {
                Console.SetCursorPosition(30, 8);
                Console.WriteLine(GetCall(player1.CurrentScore));
                Console.SetCursorPosition(70, 8);
                Console.WriteLine(GetCall(player2.CurrentScore));
            }
            else
            {
                if (player1.CurrentScore == 4 && player1.CurrentScore == player2.CurrentScore)
                {
                    deuce = true;
                    GetDeuceCall();
                }
                else
                {
                    Console.SetCursorPosition(30, 8);
                    Console.WriteLine(GetCall(player1.CurrentScore));
                    Console.SetCursorPosition(70, 8);
                    Console.WriteLine("all        ");
                }
            }
        }

        private void GetDeuceCall()
        {
            if (player1.CurrentScore == player2.CurrentScore)
            {
                Console.SetCursorPosition(30, 8);
                Console.WriteLine("                           ");
                Console.SetCursorPosition(70, 8);
                Console.WriteLine("                           ");
                Console.SetCursorPosition(50, 8);
                Console.WriteLine("Deuce        ");
            }
            else if (player1.CurrentScore > player2.CurrentScore)
            {
                Console.SetCursorPosition(30, 8);
                Console.WriteLine("Advantage");
                Console.SetCursorPosition(70, 8);
                Console.WriteLine(player2.CurrentScore);
            }
            else
            {
                Console.SetCursorPosition(30, 8);
                Console.WriteLine(player1.CurrentScore);
                Console.SetCursorPosition(70, 8);
                Console.WriteLine("Advantage");
            }
        }

        private void CheckGameWin()
        {
            if (player1.CurrentScore >= 4 && player1.CurrentScore >= player2.CurrentScore + 2)
            {
                player1.Set++;
                Console.SetCursorPosition(40, 9);
                Console.WriteLine($"{player1.PlayerName} wins the game!");
                Console.SetCursorPosition(50, 11);
                Console.WriteLine("                   ");
                Console.SetCursorPosition(50, 11);
                Console.WriteLine(GetScore());

                ResetGameScores();
                WriteScore();
            }
            else if (player2.CurrentScore >= 4 && player2.CurrentScore >= player1.CurrentScore + 2)
            {
                player2.Set++;
                Console.SetCursorPosition(40, 9);
                Console.WriteLine($"{player2.PlayerName} wins the game!");
                Console.SetCursorPosition(50, 11);
                Console.WriteLine("                   ");
                Console.SetCursorPosition(50, 11);
                Console.WriteLine(GetScore());

                ResetGameScores();
                WriteScore();
            }

            if (player1.Set == 3)
            {
                Console.SetCursorPosition(40, 12);
                Console.WriteLine($"{player1.PlayerName} wins the match!");
                EndMatch();
            }
            else if (player2.Set == 3)
            {
                Console.SetCursorPosition(40, 12);
                Console.WriteLine($"{player2.PlayerName} wins the match!");
                EndMatch();
            }
        }

        private void ResetGameScores()
        {
            player1.CurrentScore = 0;
            player2.CurrentScore = 0;
            deuce = false;
        }

        private string GetCall(int playerPoint)
        {

            switch (playerPoint)
            {
                case 0:
                    return "Love             ";
                    break;
                case 1:
                    return "15    ";
                    break;
                case 2:
                    return "30    ";
                    break;
                case 3:
                    return "40    ";
                    break;
                case 4:
                    return "game    ";
                    break;
                default:
                    return "        ";
                    break;
            }
        }

        private void EndMatch()
        {
            Console.SetCursorPosition(35, 13);
            Console.WriteLine("Press Space to go back to the start menu.");

            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);

                if (keyInfo.Key == ConsoleKey.Spacebar)
                {
                    game.ResetGame();
                    break;
                }
            }
        }

        public string GetScore()
        {
            if (player1.CurrentScore >= 3 && player2.CurrentScore >= 3)
            {
                if (player1.CurrentScore == player2.CurrentScore)
                {
                    return "Deuce";
                }
                else if (player1.CurrentScore == player2.CurrentScore + 1)
                {
                    return $"Advantage {player1.PlayerName}";
                }
                else if (player2.CurrentScore == player1.CurrentScore + 1)
                {
                    return $"Advantage {player2.PlayerName}";
                }
            }

            string player1Call = GetCall(player1.CurrentScore).Trim();
            string player2Call = GetCall(player2.CurrentScore).Trim();

            if (player1.CurrentScore == player2.CurrentScore)
            {
                return $"{player1Call}-All";
            }

            return $"{player1Call} - {player2Call}";
        }

    }
}
