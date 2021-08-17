using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyser;
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
        ///Test 3.2 message should return Exception type is null or mood is empty
        /// </summary>
        public void GivenNullMessage_WhenAnalyseShouldReturnException()
        {
            MoodAnalysers moodAnalysers = new MoodAnalysers();
            string actual = moodAnalysers.AnalyserMood();
            Assert.AreEqual("NULL_MOOD", actual);
        }       
        [TestMethod]
        /// <summary>
        /// TC-4.1 Returns the MoodAnalysers object
        /// </summary>
        public void GivenMoodAnalyserReflection_ShouldReturnObject()
        {
            object expected = new MoodAnalysers();
            object actual = MoodAnalyserFactory.CreateMoodAnalyse("MoodAnalyserProblem.MoodAnalysers", "MoodAnalysers");
            expected.Equals(actual);
        }
        /// <summary>
        /// TC-4.2 Throw No such class found exception.
        /// </summary>
        [TestMethod]
        public void GivenClassNameImproper_ShouldReturnMoodAnalysisException()
        {
            string expected = "No such class found";
            object actual = MoodAnalyserFactory.CreateMoodAnalyse("MoodAnalyse", "Mood");
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// TC-4.3 Throw No such method  exception.
        /// </summary>
        [TestMethod]
        public void GivenConstructorNameImproper_ShouldReturnMoodAnalysisException()
        {
            string expected = "No such method";
            object actual = MoodAnalyserFactory.CreateMoodAnalyse("MoodAnalyserProblem.MoodAnalysers", "Mood");
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// Tast Case -5.1 Returns the mood analyser object with parameterized constructor.
        /// </summary>
        [TestMethod]
        public void GivenParameterizedConstructor_ShouldReturnObject()
        {
            object expected = new MoodAnalysers("I am Parameter constructor");
            object actual = MoodAnalyserFactory.CreateMoodAnalyse("MoodAnalyserProblem.MoodAnalysers", "MoodAnalysers", "I am Parameter constructor");
            expected.Equals(actual);
        }
        /// <summary>
        /// Test Case -5.2 should throw No such class found exception with parameterized constructor.
        /// </summary>
        [TestMethod]
        public void GivenClassNameImproperParameterizedConstructor_ShouldReturnMoodAnalysisException()
        {
            string expected = "No such class found";
            try
            {
                object actual = MoodAnalyserFactory.CreateMoodAnalyse("MoodAnalyser.MoodAnalyser", "MoodAnalyser", "I am Parameter constructor");
            }
            catch (MoodAnalyserException e)
            {
                Assert.AreEqual(expected, e.Message);
            }
        }
        /// <summary>
        /// TC-5.3 should throw NO_SUCH_CONSTRUCTOR exception with parameterized constructor.
        /// </summary>
        [TestMethod]
        public void GivenImproperParameterizedConstructorName_ShouldReturnMoodAnalysisException()
        {
            string expected = "No such method";
            try
            {
                object actual = MoodAnalyserFactory.CreateMoodAnalyse("MoodAnalyserProblem.MoodAnalyser", "MoodAnalyser", "I am Parameter constructor");
            }
            catch (MoodAnalyserException e)
            {
                Assert.AreEqual(expected, e.Message);
            }
        }
    }   
}
