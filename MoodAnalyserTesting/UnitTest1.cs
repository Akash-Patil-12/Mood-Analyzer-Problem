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
            object actual = MoodAnalyser.MoodAnalyserReflector.CreateMoodAnalyse("MoodAnalyserProblem.MoodAnalysers", "MoodAnalysers");
            expected.Equals(actual);
        }
        [TestMethod]
        /// <summary>
        /// TC-4.2 Throw No such class found exception.
        /// </summary>
        public void GivenClassNameImproper_ShouldReturnMoodAnalysisException()
        {
            string expected = "No such class found";
            object actual = MoodAnalyser.MoodAnalyserReflector.CreateMoodAnalyse("MoodAnalyse", "Mood");
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        /// <summary>
        /// TC-4.3 Throw No such method  exception.
        /// </summary>
        public void GivenConstructorNameImproper_ShouldReturnMoodAnalysisException()
        {
            string expected = "No such method";
            object actual = MoodAnalyser.MoodAnalyserReflector.CreateMoodAnalyse("MoodAnalyserProblem.MoodAnalysers", "Mood");
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        /// <summary>
        /// Tast Case -5.1 Returns the mood analyser object with parameterized constructor.
        /// </summary>
        public void GivenParameterizedConstructor_ShouldReturnObject()
        {
            object expected = new MoodAnalysers("I am Parameter constructor");
            object actual = MoodAnalyser.MoodAnalyserReflector.CreateMoodAnalyse("MoodAnalyserProblem.MoodAnalysers", "MoodAnalysers", "I am Parameter constructor");
            expected.Equals(actual);
        }
        [TestMethod]
        /// <summary>
        /// Test Case -5.2 should throw No such class found exception with parameterized constructor.
        /// </summary>
        public void GivenClassNameImproperParameterizedConstructor_ShouldReturnMoodAnalysisException()
        {
            string expected = "No such class found";
            try
            {
                object actual = MoodAnalyser.MoodAnalyserReflector.CreateMoodAnalyse("MoodAnalyser.MoodAnalyser", "MoodAnalyser", "I am Parameter constructor");
            }
            catch (MoodAnalyserException e)
            {
                Assert.AreEqual(expected, e.Message);
            }
        }
        [TestMethod]
        /// <summary>
        /// TC-5.3 should throw NO_SUCH_CONSTRUCTOR exception with parameterized constructor.
        /// </summary>
        public void GivenImproperParameterizedConstructorName_ShouldReturnMoodAnalysisException()
        {
            string expected = "No such method";
            try
            {
                object actual = MoodAnalyser.MoodAnalyserReflector.CreateMoodAnalyse("MoodAnalyserProblem.MoodAnalyser", "MoodAnalyser", "I am Parameter constructor");
            }
            catch (MoodAnalyserException e)
            {
                Assert.AreEqual(expected, e.Message);
            }
        }
        [TestMethod]
        /// <summary>
        /// TC-6.1 Invokes the method using reflection and should return happy
        /// </summary>
        public void InvokeMethodUsingReflection_ShouldRetunHappy()
        {
            string expected = "happy";
            string actual = MoodAnalyserReflector.InvokeAnalyseMood("I am happy", "AnalyserMood");
            expected.Equals(actual);
        }
        [TestMethod]
        /// <summary>
        /// TC-6.2  should throw method not found exception.
        /// </summary>
        public void GivenMethodnameImproper_ShouldReturnMoodAnalysisException()
        {
            string expected = "No such method";
            string actual = MoodAnalyserReflector.InvokeAnalyseMood("I am happy", "Mood");
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        /// <summary>
        /// TC-7.1-Change mood dynamically.
        /// </summary>
        public void GivenSetMoodDynamically_ShouldReturnHappy()
        {
            string expected = "Happy";
            string actual = MoodAnalyserReflector.SetFieldDynamic("Happy", "message");
            expected.Equals(actual);
        }
        [TestMethod]
        /// <summary>
        /// TC-7.2 Given field name improper should return No such field
        /// </summary>
        public void GivenFieldNameImproper_ShouldReturnMoodAnaysisException()
        {
            string expected = "No such field";
            string actual = MoodAnalyserReflector.SetFieldDynamic("Happy", "msg");
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        /// <summary>
        /// TC-7.3 Change message dynamically
        /// </summary>
        public void ChangeMeassageDynamically_ShouldReturnMessage()
        {
            string expected = "Message should not be null";
            string actual = MoodAnalyserReflector.SetFieldDynamic(null, "message");
            Assert.AreEqual(expected, actual);
        }
    }   
}
