using System;
using System.Collections.Generic;
using System.Text;

namespace PrimeNumbersCounter.Services
{
    internal interface IPermutator
    {
        int CountCombinationsFromString(string value, Predicate<string> predicate = null);
    }
}
