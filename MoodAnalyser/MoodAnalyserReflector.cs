using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace MoodAnalyser
{
    public class MoodAnalyserReflector
    {
        /// <summary>
        /// Return object according to given parameter
        /// </summary>
        /// <param name="className"></param>
        /// <param name="constructorName"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static object CreateMoodAnalyse(string className, string constructorName, string message = "")
        {
            if (message.Length == 0)
            {
                Console.WriteLine("Message is optional");
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
            else
            {
                Type type = Type.GetType(className);
                try
                {
                    if (type.FullName.Equals(className) || type.Name.Equals(className))
                    {
                        if (type.Name.Equals(constructorName))
                        {
                            ConstructorInfo info = type.GetConstructor(new[] { typeof(string) });
                            object instance = info.Invoke(new object[] { message });
                            return instance;
                        }
                        else
                        {
                            throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.NO_SUCH_CONSTRUCTOR, "No such method");
                        }
                    }
                    else
                    {
                        throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.NO_SUCH_CONSTRUCTOR, "No such class found");
                    }
                }
                catch (Exception e)
                {
                    return e;
                }
            }

        }
        /// <summary>
        /// If method found return message
        /// </summary>
        /// <param name="message"></param>
        /// <param name="methodName"></param>
        /// <returns></returns>
        public static string InvokeAnalyseMood(string message, string methodName)
        {
            try
            {
                Type type = Type.GetType("MoodAnalyserProblem.MoodAnalysers");
                object moodAnalyseObject = MoodAnalyserReflector.CreateMoodAnalyse("MoodAnalyserProblem.MoodAnalysers", "MoodAnalysers", message);
                MethodInfo methodInfo = type.GetMethod(methodName);
                Console.WriteLine("Method Info " + methodInfo);
                if (methodInfo == null)
                {
                    throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.NO_SUCH_METHOD, "No such method");
                }
                object mood = methodInfo.Invoke(moodAnalyseObject, null);
                return mood.ToString();
            }
            catch (MoodAnalyserException e )
            {
                return e.Message;
            }
        }
    }
}