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
        // at a minimum, Question and Answer

        public string Question { get; set; }

        public string Answer { get; set; }

        //The Constructor for the Trivia object will
        // accept only 1 string parameter.  You will
        // split the question from the answer in your
        // constructor and assign them to the Question
        // and Answer properties
        public Trivia(string trivialSplit)
        {
            //create a list for the questions/answers to go to
            List<string> QandA = new List<string>();
            //split each question and answer from the txt file at the asteric and add to QandA list
            QandA = trivialSplit.Split('*').ToList();

            //set up that in QandA, the question is before the * and the answer is after
            //question would be index 0 and answer would be index 1
            //set the values for Question and Answer
            this.Question = QandA[0];
            this.Answer = QandA[1];


        }

    }
}