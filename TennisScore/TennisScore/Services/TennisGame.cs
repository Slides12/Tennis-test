using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisScore.Models;

namespace TennisScore.Services
{
    internal class TennisGame
    {
        private Player player1;
        private Player player2;
        private bool deuce = false;

        public TennisGame(Player player1, Player player2)
        {
            this.player1 = player1;
            this.player2 = player2;
        }


        public void StartGame()
        {
            Console.Clear();
            Console.SetCursorPosition(10, 2);
            Console.WriteLine("Press leftArrow to give point to the left player, and rightArrow for the right player. Exit with ESC.");
            Console.SetCursorPosition(50, 3);
            Console.WriteLine("Press R to restart");
            Console.SetCursorPosition(46, 4);
            Console.WriteLine("Start the game with SPACE.");

            ConsoleKey key;
            do
            {
                key = Console.ReadKey(intercept: true).Key;
            } while (key != ConsoleKey.Spacebar && key != ConsoleKey.Escape);

            if (key == ConsoleKey.Spacebar)
            {
                Console.Clear();
                WriteScore();

                while (true)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);

                    if (keyInfo.Key == ConsoleKey.LeftArrow)
                    {
                        this.player1.CurrentScore ++;
                    }
                    else if (keyInfo.Key == ConsoleKey.RightArrow)
                    {
                        this.player2.CurrentScore ++;
                    }
                    else if (keyInfo.Key == ConsoleKey.R)
                    {
                        ResetGame();
                    }
                    else if (keyInfo.Key == ConsoleKey.Escape)
                    {
                        ExitGame();
                        break;
                    }

                    WriteScore();
                }
            }
            else if (key == ConsoleKey.Escape)
            {
                ExitGame();
            }
        }


        public void WriteScore()
        {
            Console.SetCursorPosition(30, 5);
            Console.WriteLine($"{player1.PlayerName}, Score:{player1.CurrentScore}|Set:{player1.Set} -||-  Set:{player2.Set}|Score:{player2.CurrentScore}, {player2.PlayerName}");
            Console.SetCursorPosition(50, 7);
            Console.WriteLine("Call");
            if(!deuce)
            {
                GetPlayerCall();
            }
            else
            {
                GetDeuceCall();
            }
        }

        private void ExitGame()
        {
            Console.Clear();
            Console.SetCursorPosition(50, 5);
            Console.WriteLine("Exiting...                                                                                                               ");
        }

        private void ResetGame()
        {
            player1.CurrentScore = 0;
            player1.Set = 0;
            player2.CurrentScore = 0;
            player2.Set = 0;
            StartGame();
        }

        private void GetPlayerCall()
        {
            if(player1.CurrentScore != player2.CurrentScore)
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
            if(player1.CurrentScore == player2.CurrentScore)
            {
                Console.SetCursorPosition(30, 8);
                Console.WriteLine("                           ");
                Console.SetCursorPosition(70, 8);
                Console.WriteLine("                           ");
                Console.SetCursorPosition(50, 8);
                Console.WriteLine("Deuce        ");
            }
            else if(player1.CurrentScore > player2.CurrentScore)
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


        private string GetCall(int playerPoint)
        {

            switch(playerPoint)
            {
                case 0:
                    return "Love";
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

    }
}
