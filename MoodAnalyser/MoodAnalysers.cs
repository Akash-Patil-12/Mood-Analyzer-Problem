using MoodAnalyser;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyserProblem
{
    public class MoodAnalysers
    {
        //Variables
        public string message;
        public MoodAnalysers()
        {
           
        }
        public MoodAnalysers(string message)
        {
            this.message = message;
        }
        /// <summary>
        /// method return Sad or Happy or if message is empty or null then throw specific exception
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public string AnalyserMood()
        {
            try
            {
                if (message == null)
                {
                    throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.NULL_MOOD, "mood is null");
                }
                if (message.Length == 0)
                {
                    throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.EMPTY_MOOD, "mood is empty");
                }
                message = this.message.ToLower();
                if (message.Contains("sad"))
                {
                    return "Sad";
                }
                else
                    return "Happy";
            }
            catch (MoodAnalyserException e)
            {
                return e.type.ToString();
            }          
        }
    }
}
