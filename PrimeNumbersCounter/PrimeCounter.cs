using PrimeNumbersCounter.Services;
using PrimeNumbersCounter.Utils;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Linq;

namespace PrimeNumbersCounter
{
    public class PrimeCounter
    {
        public Dictionary<string, int> Count(List<string> list)
        {
            ConcurrentDictionary<string, int> countDictionary = new ConcurrentDictionary<string, int>();
            Parallel.ForEach(list, item =>
            {
                IPermutator permutator = new Permutator();
                if(item.Length <= 7)
                {
                    int numOfPrimes = permutator.CountCombinationsFromString(item, val =>
                    {
                        return PrimeCheckUtil.IsPrime(int.Parse(val));
                    });
                    countDictionary.TryAdd(item, numOfPrimes);
                }
                else
                {
                    countDictionary.TryAdd(item, -1);
                }

                
            });
            return new Dictionary<string, int>(countDictionary);
        }
    }
}
