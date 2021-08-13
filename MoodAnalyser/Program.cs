using System;

namespace MoodAnalyserProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            MoodAnalyser moodAnalyser = new MoodAnalyser("I am in any mood");
            Console.WriteLine(moodAnalyser.AnalyserMood());
        }
    }
}
