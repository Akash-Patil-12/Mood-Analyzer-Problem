using MoodAnalyser;
using System;

namespace MoodAnalyserProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome in Mood Analyser Problem");
            object actual = MoodAnalyserFactory.CreateMoodAnalyse("MoodAnalyse", "Mood");
            Console.WriteLine(actual);

        }
    }
}
