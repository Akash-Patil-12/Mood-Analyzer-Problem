using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace MoodAnalyser
{
    public class MoodAnalyserFactory
    {
        /// <summary>
        /// If className and constructorName match then return the className object
        /// </summary>
        /// <param name="className"></param>
        /// <param name="constructorName"></param>
        /// <returns></returns>
        public static object CreateMoodAnalyse(string className, string constructorName)
        {
            string pattern = @"." + constructorName + "";
            Match result = Regex.Match(className, pattern);
            Console.WriteLine("result" + result);
            try
            {
                if (result.Success)
                {
                    Assembly executing = Assembly.GetExecutingAssembly();
                    Type moodAnalyseType = executing.GetType(className);
                    if (!moodAnalyseType.Name.Equals(constructorName))
                    {
                        throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.NO_SUCH_CONSTRUCTOR, "No such method");
                    }
                    return Activator.CreateInstance(moodAnalyseType);
                }
                else
                {
                    throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.NO_SUCH_CONSTRUCTOR, "No such class found");
                }
            }
            catch (MoodAnalyserException e)
            {
                return e.Message;
            }


        }
    }
}
