using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyserProblem;

namespace MoodAnalyserTesting
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        ///<summery>
        ///Test1.1 message should return Sad
        ///<summery>
        public void GivenSadMessage_WhenAnalyse_ShouldReturnSad()
        {
            MoodAnalyser moodAnalyser = new MoodAnalyser();
            string actual = moodAnalyser.AnalyserMood("I am in Sad Mood");
            Assert.AreEqual("Sad", actual);
        }
        [TestMethod]
        ///<summery>
        ///Test1.2 message should return Sad or Happy
        ///<summery>
        public void GivenMessage_WhenAnalyse_ShouldReturnSadOrHappy()
        {
            MoodAnalyser moodAnalyser = new MoodAnalyser();
            string actual = moodAnalyser.AnalyserMood("I am in any Mood");
            Assert.AreEqual("Happy", actual);
        }
    }   
}
