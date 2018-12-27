using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace HangMan
{
    class Program
    {

        static string correctWord;
        static string[] word;
        static char[] maskedWord;
        static string finalWord;
        static string letter;
        static Player player;

        static void Main(string[] args)
        {
                StartGame();     
                PlayGame();
                EndGame();
        }

        private static void StartGame()
        {
            Console.WriteLine("Starting the GAME");
            AskForUsersName();
        }

        static void AskForUsersName()
        {

            Console.WriteLine("Enter your name:");
            string input = Console.ReadLine();

            if (input.Length >= 2)
            {
                player = new Player(input);
            }
            else
            {
                AskForUsersName();
            }
        }

        static void ReadWord()
        {
            
            try
            {
                word = File.ReadAllLines(@"C:\Users\Catalin\source\repos\HangMan\HangMan\Words.txt");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found");
                word = new string[5] { "house", "car", "computer" , "hangman", "sun" };
            }

            Random rand = new Random();
            int index = rand.Next(word.Length);
            correctWord = word[index];
        }

        private static void PlayGame()
        {
            Console.Clear();
            Console.WriteLine("Playing the game..");
            ReadWord();
            DisplayMaskedWord();
            AskForLetter();
            Console.Clear();
        }

        private static void CheckLetter()
        {
            for (int i = 0; i < correctWord.Length; i++)
            {
                if (letter.Equals(correctWord[i].ToString()))
                {
                    Console.WriteLine("Correct letter: " + letter);
                    maskedWord[i] = correctWord[i];
                    player.Score++;
                }
            }
            Console.Clear();
        }

        static void DisplayMaskedWord()
        {
            maskedWord = correctWord.ToCharArray();

            for (int i = 0; i < correctWord.Length; i++)
            {
                maskedWord[i] = '_';
            }

            for (int i = 0; i < maskedWord.Length; i++)
            {
                Console.Write(maskedWord[i] + " ");
            }
            Console.WriteLine();
        }

        static void AskForLetter()
        {
            do
            {
                do
                {
                    Console.WriteLine("Enter a letter:");
                    letter = Console.ReadLine();
                } while (letter.Length != 1);
                
                if (!player.GuessedLetters.Contains(letter))
                {
                    player.GuessedLetters.Add(letter);
                }

                CheckLetter();
                
                for (int i = 0; i < maskedWord.Length; i++)
                {
                    Console.Write(maskedWord[i] + " ");
                }
                Console.WriteLine();

                finalWord = new string(maskedWord);

            } while (!(finalWord.Equals(correctWord)));
        }

        private static void EndGame()
        {
            Console.WriteLine("Congrats! Correct word: " + correctWord);
            Console.WriteLine("Thank you " + player.Name );
            Console.WriteLine("Total number of guesses: " + player.GuessedLetters.Count + " Score: "  + player.Score); 
        }
    }
}
