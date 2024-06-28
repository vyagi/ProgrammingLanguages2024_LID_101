using System;
using System.Collections.Generic;
using System.Linq;

public class IntroductionProgram
{
    public static void Main(string[] args)
    {
        var array = new int[] { 6, 9, 10, 12, 11, 9, 6, 10, 0, -2 };

        //Your homework(*), is to implement some other Linq methods, Take, FirstOrDefault, LastOrDefault, Sum(*), Max(*) (riddle)

        //foreach (var element in array.OurSkip(3))
        //{
        //    Console.WriteLine(element);
        //}

        //foreach (var element in array.OurWhere(x => x > 5))
        //{
        //    Console.WriteLine(element);
        //}

        //Console.WriteLine(array.OurSingleOrDefault(x=>x == 6));

        //foreach (var element in array.Where(x => x > 5))
        //{
        //    Console.WriteLine(element);
        //}

    }
}

public static class OurLinq
{
    public static IEnumerable<T> OurSkip<T>(this IEnumerable<T> collection, int howMany)
    {
        var skipped = 0;

        foreach (var element in collection)
        {
            if (++skipped > howMany)
            {
                yield return element;
            }
        }
    }

    public static IEnumerable<T> OurWhere<T>(this IEnumerable<T> collection, Func<T, bool> condition)
    {
        foreach (var element in collection)
        {
            if (condition(element))
            {
                yield return element;
            }
        }
    }

    public static T OurSingleOrDefault<T>(this IEnumerable<T> collection, Func<T, bool> condition)
    {
        T result = default;
        var found = false;

        foreach (var element in collection)
        {
            if (condition(element))
            {
                if (found)
                    throw new Exception("More than one occurence !!!!");

                found = true;
                result = element;
            }    
        }

        return result;
    }
 }
