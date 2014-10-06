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
            Console.WriteLine(@"Trivia Game");
            //ask the user for name
            Console.WriteLine("\nWhat is your name?\n\n");

            //set name
            string name = Console.ReadLine();
            Console.Clear();
            //greet the user and explain the trivia game!
            Console.WriteLine(@"Hello there, " + name + "! Welcome to the Trivia Game 5000!\n\nThis is a game where I will ask you twenty trivia questions at which you will have to provide the correct answer.  You can only answer each question one time and I will let you know if you have answered correctly or incorrectly.\n\nEach question answered correctly will earn you 1000 points. If a question is answered incorrectly, no points will be deducted.  Try and answer all twenty questions correctly for a total of 20,000 points!\n\nAt the end of the game, your final stats will be displayed.\n\nGood luck!\n\n\n");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
            //create some variable for correct/incorrect answers, number of questions, and user's score
            int correct = 0;
            int incorrect = 0;
            int questionAsk = 20;
            int userScore = 0;
            //create varible for question number
            int number = 1;
            //create a loop to run the twenty questions counting down from 20
            while (questionAsk > 0)
            {
                //create a random generator to draw a question from the txt file at random
                Random rand = new Random();
                int randNum = rand.Next(1, 5001);
                var triviaNum = GetTriviaList()[randNum];

                Console.WriteLine("Question #" + number + ":\n\n");
                //ask the user the random question
                //link the Question from the trivia.cs file
                Console.WriteLine(triviaNum.Question);
                //get the users answer
                Console.WriteLine("\n\nYour Answer: \n\n");
                //convert the users answer to lowercase 
                var userAnswer = Console.ReadLine().ToLower();
                //see if the users answer matches up with the correct answer in our txt file
                //link Answer from the triva.cs file
                if (userAnswer == triviaNum.Answer.ToLower())
                {
                    //take one away from questions asked
                    questionAsk = questionAsk - 1;
                    //add 5 points to the users score
                    userScore = userScore + 1000;
                    //add one to correct answers
                    correct++;
                    //let user know that they answered correctly
                    Console.WriteLine("\n==========Correct==========\n\n");
                    //let user know they add 1000 pts to their score
                    Console.WriteLine("You have earned 1000 pts!");
                    //go on to the next question
                    number++;
                    Console.WriteLine("\n\n\n\nPress any key to continue...");
                    Console.ReadKey();
                }
                //if answer was incorrect...
                else
                {
                    //take one away from questions asked
                    questionAsk = questionAsk - 1;
                    //add one to incorrect answers
                    incorrect++;
                    //let user know they answered incorrectly
                    Console.WriteLine("\n==========Incorrect==========\n\n");
                    //go on to the next question
                    number++;
                    //tell the user the correct answer
                    Console.WriteLine("The correct answer was: \n\n" + triviaNum.Answer);
                    Console.WriteLine("\n\n\n\nPress any key to continue...");
                    Console.ReadKey();

                }
                //clear console after each question
                Console.Clear();
            }
            //at the end of twenty questions print out to the user their score and stats
            Console.WriteLine("Congratulations! You have finished answering all of the questions!  Here are your results:\n\n");
            Console.WriteLine("================Game Stats================\n\n");
            Console.WriteLine("Total Answered Correctly: " + correct);
            Console.WriteLine("Total Answered Incorrectly: " + incorrect);
            Console.WriteLine("Score: " + userScore + "pts");
            Console.WriteLine("\n\n\n\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();
      
            //thank the user for playing
            Console.WriteLine("\n\n\nThank you for playing Trivia Game 5000!");
            Console.WriteLine("\n\nPress any key to exit.");

            //keep console open
            Console.ReadKey();
        }


        //This functions gets the full list of trivia questions from the Trivia.txt document
        static List<Trivia> GetTriviaList()
        {
            //Get Contents from the file.  Remove the special char "\r".  Split on each line.  Convert to a list.
            List<string> contents = File.ReadAllText("trivia.txt").Replace("\r", "").Split('\n').ToList();

            //Each item in list "contents" is now one line of the Trivia.txt document.

            //make a new list to return all trivia questions
            List<Trivia> returnList = new List<Trivia>();
            // TODO: go through each line in contents of the trivia file and make a trivia object.
            //       add it to our return list.
            // Example: Trivia newTrivia = new Trivia("what is my name?*question");
            foreach (string question in contents)
            {
                Trivia triviaObject = new Trivia(question);
                //add the new object to returnList
                returnList.Add(triviaObject);
            }
            //Return the full list of trivia questions
            return returnList;
        }
    }
}


      

     