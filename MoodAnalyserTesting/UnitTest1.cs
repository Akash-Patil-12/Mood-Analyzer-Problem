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
    }
}
