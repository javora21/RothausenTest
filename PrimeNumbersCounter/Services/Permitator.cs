using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrimeNumbersCounter.Services
{
    internal class Permutator: IPermutator
    {
        List<string> combinations = new List<string>();

        private Predicate<string> countProcessor = null;
        private int countResult;


        public int CountCombinationsFromString(string value, Predicate<string> predicate = null)
        {
            countResult = 0;
            if (predicate == null)
            {
                predicate = x => true;
            }
            countProcessor = predicate;

            char[] arr = value.ToCharArray();

            PermutateChars(arr, 0, arr.Length - 1);

            return countResult;
        }
        private void PermutateChars(char[] list, int currentPos, int endPos)
        {
            if (currentPos == endPos)
            {
                for (int n = 1; n <= list.Length; n++)
                {
                    var numberString = new string(list[0..n]);

                    if (!combinations.Any(x => x == numberString))
                    {
                        combinations.Add(numberString);

                        if (countProcessor(numberString))
                        {
                            countResult++;
                        }
                    }

                }
            }
            else
            {
                for (int i = currentPos; i <= endPos; i++)
                {
                    Swap(ref list[currentPos], ref list[i]);
                    PermutateChars(list, currentPos + 1, endPos);
                    Swap(ref list[currentPos], ref list[i]);
                }
            }

        }

        private void Swap(ref char a, ref char b)
        {
            if (a == b) return;

            var temp = a;
            a = b;
            b = temp;
        }
    }
}
