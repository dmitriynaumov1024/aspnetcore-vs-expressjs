using System;
using System.Collections.Generic;

public static class RandomExtensions 
{
    public static T Choice<T> (this Random random, IList<T> list) 
    {
        return list[random.Next(0, list.Count)];
    }

    public static int RandInt (this Random random, int lowerBound, int upperBound) 
    {
        return random.Next(lowerBound, upperBound);
    }
}
