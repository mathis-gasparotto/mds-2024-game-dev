using System;
using System.Collections.Generic;

public abstract class Helper
{
    private static System.Random rnd = new System.Random();

    public static T GetRandomFromWeightedList<T>(IEnumerable<T> enumerable, Func<T, int> weightFunc)
    {
        int totalWeight = 0; // this stores sum of weights of all elements before current
        T selected = default(T); // currently selected element
        foreach (var data in enumerable)
        {
            int weight = weightFunc(data); // weight of current element
            int r = rnd.Next(totalWeight + weight); // random value
            if (r >= totalWeight) // probability of this is weight/(totalWeight+weight)
                selected = data; // it is the probability of discarding last selected element and selecting current one instead
            totalWeight += weight; // increase weight sum
        }

        return selected; // when iterations end, selected is some element of sequence. 
    }
}
