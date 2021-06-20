/*
 * Returns a List of all the possible heads-tails combinations of a set of 'numCoins' coins.
 * 
 * The combinations are printed to the console. 
 */

namespace CodingChallenges
{
    using System;
    using System.Collections.Generic;

    class Solution
    { 
        private static List<string> GetCoinTossCombinations(int numCoins)
        {
            List<string> listOfCombinations = new List<string>();
            string startingString = "";
            for(int i = 0; i < numCoins; i++)
            {
                startingString += "H";
            }
            listOfCombinations.Add(startingString);
            int colNum = 0;
            int numProcessed = 1;
            while (colNum < numCoins)
            {
                // Doubles the list size, with the new entries replicating the existing ones. 
                // As only the new additions are operated on, the 'for' loop starting and end points are adjusted accordingly.
                listOfCombinations = DoubleListSize(listOfCombinations);
                int currListSize = listOfCombinations.Count;
                int startingPoint = numProcessed;
                // For the new entries, every entry has a 'H' at index 'colNum'. This is replaced by a 'T'. 
                for (int combinationIndex = startingPoint; combinationIndex < currListSize; combinationIndex++)
                {
                    listOfCombinations[combinationIndex] = GetReplacement(listOfCombinations[combinationIndex], colNum);
                    numProcessed++;
                }
                // Current col processed, so move to next.
                colNum++;
            }
            return listOfCombinations;
        }

        // Replaces the H in index 'colNum' with 'T'
        private static string GetReplacement(string coinCombination, int colNum)
        {
            char[] arr;
            arr = coinCombination.ToCharArray(0, coinCombination.Length);
            arr[colNum] = 'T';
            return new string(arr);
        }
        private static List<string> DoubleListSize(List<string> list)
        {
            int listCount = list.Count;
            for (int index = 0; index < listCount; index++)
            {
                string toReplicate = list[index];
                list.Add(toReplicate);
            }
            return list;
        }
        public static void Main(string[] args)
        {
            List<string> coinCombinations = GetCoinTossCombinations(6);
            foreach(string combination in coinCombinations)
            {
                Console.WriteLine(combination);
            }
            Console.WriteLine("\nCoin toss combinations: " + coinCombinations.Count);
        }
    }
}
