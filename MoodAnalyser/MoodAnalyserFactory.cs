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
        /// Return object according to given parameter
        /// </summary>
        /// <param name="className"></param>
        /// <param name="constructorName"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static object CreateMoodAnalyse(string className, string constructorName, string message="")
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
    }
}