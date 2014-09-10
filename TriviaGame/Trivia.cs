using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaGame
{
    class Trivia
    {
        //TODO: Fill out the Trivia Object
        //The Trivia Object will have 2 properties
        //create properties for trivia game
        public string Question { get; set; }
        public string Answer { get; set; }

        // at a minimum, Question and Answer
        //The Constructor for the Trivia object will
        // accept only 1 string parameter.  You will
        // split the question from the answer in your
        // constructor and assign them to the Question
        // and Answer properties.

        public Trivia(string answers)
        {
            List<string> split = new List<string>();
            split = answers.Split('*').ToList();

            this.Question = split[0];
            this.Answer = split[1];

        }


    }
}
