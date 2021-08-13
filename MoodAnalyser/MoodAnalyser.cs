using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyserProblem
{
    public class MoodAnalyser
    {
        /// <summary>
        /// method return sad
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public string AnalyserMood(string message)
        {
            if (message.Contains("Sad") || message.Contains("sad" ))
            {
                return "Sad";
            }
            return "";
        }
    }
}
