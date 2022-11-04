 
using System;
using System.Collections.Generic;
using System.Text;

 public static class Combinator<T>
    {
        /*
        Truth table logic. 
        
        Example:

        Inputs:
        List X = X1
        List Y = Y1 Y2
        List Z = Z1 Z2

        Outputs:
        List O1 = X1 Y1 Z1
        List O2 = X1 Y1 Z2
        List O3 = X1 Y2 Z1
        List O4 = X1 Y2 Z2
        
        Z repeats each time (multiplier = 1)
        Y repeats 2 times because Z has two members (multiplier = 2)
        X repeats 4 times because Y has two members (multiplier * 2 = 4)
         */
        public static List<List<T>> AllCombinationsOfLists(List<List<T>> lists )
        {
            int multiplier = 1;
            int totalPossibleCombinations = 1;
            int counter = 0;
            
            foreach (List<T> list in lists)
            {
                totalPossibleCombinations *= list.Count;
            }

            List<List<T>> outputList = new List<List<T>>(totalPossibleCombinations);
            for (int i = 0; i < totalPossibleCombinations; i++)
            {
                outputList.Add(new List<T>());
            }

            foreach (List<T> list in lists)
            {
                for (int i = 0; i < totalPossibleCombinations/(multiplier * list.Count); i++)
                {
                    for (int j = 0; j < list.Count; j++)
                    {
                        for (int k = 0; k < multiplier; k++)
                        {
                            outputList[(counter % totalPossibleCombinations)].Add(list[j]);
                            counter++;
                        }
                    }
                }
                multiplier *= list.Count;
            }
            return outputList;
        }
        /*
        Truth table logic. 
        
        Example:

        Inputs:
        List X = X1
        List Y = Y1 Y2
        List Z = Z1 Z2

        Outputs:
        List O1 = X1 Y1 Z1
        List O2 = X1 Y1 Z2
        List O3 = X1 Y2 Z1
        List O4 = X1 Y2 Z2
        
        Z repeats each time (multiplier = 1)
        Y repeats 2 times because Z has two members (multiplier = 2)
        X repeats 4 times because Y has two members (multiplier * 2 = 4)
         */
        public static List<T[]> AllCombinationsOfArrays(List<T[]> arrayList)
        {
            int multiplier = 1;
            int totalPossibleCombinations = 1;
            int arrayIndex = 0;
            int counter = 0;
            
            foreach (T[] array in arrayList)
            {
                totalPossibleCombinations *= array.Length;
            }

            List<T[]> outputList = new List<T[]>(totalPossibleCombinations);
            for (int i = 0; i < totalPossibleCombinations; i++)
            {
                outputList.Add(new T[arrayList.Count]);
            }
            
            foreach (T[] array in arrayList)
            {
                for (int i = 0; i < totalPossibleCombinations / (multiplier * array.Length); i++)
                {
                    for (int j = 0; j < array.Length; j++)
                    {
                        for (int k = 0; k < multiplier; k++)
                        {
                            outputList[(counter % totalPossibleCombinations)][arrayIndex] = array[j];
                            counter++;
                        }
                    }
                }
                multiplier *= array.Length;
                arrayIndex++;
            }
            return outputList;
        }
    }