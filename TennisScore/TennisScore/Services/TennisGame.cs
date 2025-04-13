using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisScore.Models;
using TennisScore.View;

namespace TennisScore.Services
{
    internal class TennisGame
    {
        private Player player1;
        private Player player2;
        private TennisGUI gui;

        public TennisGame(Player player1, Player player2)
        {
            this.player1 = player1;
            this.player2 = player2;
        }


        public void StartGame()
        {
            gui = new TennisGUI(this.player1, this.player2, this);
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
                gui.WriteScore();

                while (true)
                {
                    ConsoleKey keyInfo = Console.ReadKey(intercept: true).Key;

                    if (keyInfo == ConsoleKey.LeftArrow)
                    {
                        this.player1.CurrentScore ++;
                    }
                    else if (keyInfo == ConsoleKey.RightArrow)
                    {
                        this.player2.CurrentScore ++;
                    }
                    else if (keyInfo == ConsoleKey.R)
                    {
                        ResetGame();
                    }
                    else if (keyInfo == ConsoleKey.Escape)
                    {
                        ExitGame();
                        break;
                    }

                    gui.WriteScore();
                }
            }
            else if (key == ConsoleKey.Escape)
            {
                ExitGame();
            }
        }


       

        private void ExitGame()
        {
            Console.Clear();
            Console.SetCursorPosition(50, 5);
            Console.WriteLine("Exiting!                                                                                                               ");
        }

        public void ResetGame()
        {
            player1.CurrentScore = 0;
            player1.Set = 0;
            player2.CurrentScore = 0;
            player2.Set = 0;
            StartGame();
        }
        

    }
}
