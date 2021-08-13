using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyserProblem
{
    public class MoodAnalyser
    {
        /// <summary>
        /// method return Sad or Happy
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public string AnalyserMood(string message)
        {
            if (message.Contains("Sad"))
            {
                return "Sad";
            }
            return "Happy";
        }
    }
}
