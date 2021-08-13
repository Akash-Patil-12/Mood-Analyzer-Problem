using System;

namespace MoodAnalyser
{
    class Program
    {
        static void Main(string[] args)
        {
            MoodAnalyser moodAnalyser = new MoodAnalyser();
            Console.WriteLine(moodAnalyser.AnalyserMood("I am sad"));
        }
    }
}
