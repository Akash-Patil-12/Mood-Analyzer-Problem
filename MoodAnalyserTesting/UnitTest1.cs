using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyserProblem;
using System;

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
            MoodAnalysers moodAnalyser = new MoodAnalysers("I am in sad mood");
            string actual = moodAnalyser.AnalyserMood();
            Assert.AreEqual("Sad", actual);
        }
        [TestMethod]
        ///<summery>
        ///Test1.2 message should return Sad or Happy
        ///<summery>
        public void GivenMessage_WhenAnalyse_ShouldReturnSadOrHappy()
        {
            MoodAnalysers moodAnalyser = new MoodAnalysers("I am in any Mood");
            string actual = moodAnalyser.AnalyserMood();
            Assert.AreEqual("Happy", actual);
        }
        [TestMethod]
        ///<summary>
        ///Test 2.1 If message is null throw exception and return Happy
        ///<summary>
        public void GivenNullMessage_WhenAnalyseShouldReturnException()
        {
            MoodAnalysers moodAnalyser = new MoodAnalysers();
            string actual=moodAnalyser.AnalyserMood();
            Assert.AreEqual("Happy",actual);
        }
    }   
}
