using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyser
{
    class MoodAnalyser
    {
        public string AnalyserMood(string message)
        {
            if (message.Contains("happy") || message.Contains("Happy" ))
            {
                return "happy";
            }
            return "sad";
        }
    }
}
