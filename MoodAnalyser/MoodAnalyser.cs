using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyserProblem
{
    public class MoodAnalyser
    {
        string message;
        public MoodAnalyser()
        {
            this.message = "I am in any mood";
        }
        public MoodAnalyser(string message)
        {
            this.message = message;
        }
        /// <summary>
        /// method return Sad or Happy
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public string AnalyserMood()
        {
            if (message.Contains("Sad"))
            {
                return "Sad";
            }
            return "Happy";
        }
    }
}
