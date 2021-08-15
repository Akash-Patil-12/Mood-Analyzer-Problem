using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyserProblem
{
    public class MoodAnalyser
    {
        public string message;
        public MoodAnalyser()
        {
           
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
            try
            {
                if (message == null)
                {
                    throw new Exception();
                }
                message = this.message.ToLower();
                if (message.Contains("sad"))
                {
                    return "Sad";
                }
                else
                    return "Happy";
            }
            catch (Exception)
            {
                return "Happy";
            }
        }
    }
}
