using MoodAnalyser;
using System;

namespace MoodAnalyserProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome in Mood Analyser Problem");
            string actual1 = MoodAnalyserReflector.InvokeAnalyseMood("I am happy", "AnalyserMood");
            string actual = MoodAnalyserReflector.InvokeAnalyseMood("I am happy", "MoodAnalysers");
            Console.WriteLine("actual" + actual);
        }
    }
}
