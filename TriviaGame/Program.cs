using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaGame
{
    class Program
    {
        static void Main(string[] args)
        {
            //The logic for your trivia game happens here
            List<Trivia> AllQuestions = GetTriviaList();

            Greeting();

             //delare variables for questions that are given
            int score = 0;
            int correct = 0;
            int wrong = 0;

             
            //while loop if score is greater than 0 play
            while (wrong < 10)
            {
                 //create a random generator for trivia quesions
                Random rng = new Random();
                int newRandom = rng.Next(1,5001);

                var triviaQuestion = GetTriviaList()[newRandom];

                Console.WriteLine("Your answer is: ");
                string input = Console.ReadLine();
                
                if (input == triviaQuestion.Answer.ToLower())
                {
                    correct++; score += 100;
                    Console.Clear();
                    Console.WriteLine("You are awesomeness!");
                }
                        else   
                {
                     wrong++;
                    score -= 50;
                    Console.Clear();
                    Console.WriteLine(input + " is wrong!\nThe correct answer is: " + triviaQuestion.Answer + "\n");
                }
                Console.WriteLine("Correct: " + correct + "\nScore: " + score + "\nYou have " + (10 - wrong) + " incorrect guesses remaining.\n");
            }
            Console.ReadKey();
            }
        //This functions gets the full list of trivia questions from the Trivia.txt document
        static List<Trivia> GetTriviaList()
        {
            //Get Contents from the file.  Remove the special char "\r".  Split on each line.  Convert to a list.
            List<string> contents = File.ReadAllText("trivia.txt").Replace("\r", "").Split('\n').ToList();

            //make a new list to return all trivia questions
            List<Trivia> returnList = new List<Trivia>();
            // TODO: go through each line in contents of the trivia file and make a trivia object.
            //       add it to our return list.
            // Example: Trivia newTrivia = new Trivia("what is my name?*question");
            
            foreach (string s in contents)
            {
                //Declare newTrivia and split into question and answer
                Trivia newTrivia = new Trivia(s);
                returnList.Add(newTrivia);
            }
            //Return the full list of trivia questions
            return returnList;
        }

        static void Greeting()

        {
            Console.Write("Please enter your name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Hello, " + name + " you will answer questions until you get 10 wrong or hit Ctrl+C.");
        }

        static void AddHighScore(int PlayerScore)
        {
            Console.WriteLine("Your Name");
            string playerName = Console.ReadLine();
            NORTHWNDEntities db = new NORTHWNDEntities();

            //create a new highscore
            HighScore newHighScore = new HighScore();
            newHighScore.Date = DateTime.Now;
            newHighScore.Game = "Trivia";
            newHighScore.Name = playerName;
            newHighScore.Score = PlayerScore;

            //add it to the data base

            db.HighScores.Add(newHighScore);

            //save changes 
            db.SaveChanges();
            

        }



        static void DisplayHighScore()
        {
            Console.WriteLine("Display Trivia High Score");
            Console.WriteLine("--------------");

            NORTHWNDEntities db = new NORTHWNDEntities();
            List<HighScore> highScoreList = db.HighScores.Where(x => x.Game == "Trivia")
                .OrderByDescending(x => x.Score).Take(10).ToList();

            foreach(HighScore highScore in highScoreList)
            {
                Console.WriteLine("{0}. {1}- {2} on {3}",
                highScoreList.IndexOf(highScore) + 1,
                highScore.Name,
                highScore.Score,
                highScore.Date.Value.ToShortDateString());

            }
        }
    }
}

        


     