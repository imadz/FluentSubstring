using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentSubstring
{
    internal static class StringHelper
    {
        public static int IndexOf(string haystack, string needle, int beginIndex, int nthOccurrence, int endIndex)
        {
            if (nthOccurrence <= 0)
            {
                throw new ArgumentException("Number of occurences must be a positive integer");
            }
            int searchesLeft = nthOccurrence;
            int currentIndex = beginIndex;
            for (; searchesLeft > 0; searchesLeft--)
            {
                if (endIndex < 0)
                {
                    currentIndex = haystack.IndexOf(needle, currentIndex);
                }
                else
                {
                    currentIndex = haystack.IndexOf(needle, currentIndex, endIndex - currentIndex + 1);
                }
                if (currentIndex == -1)
                {
                    break;
                }
                else if (searchesLeft > 1)
                {
                    currentIndex++;
                }
            }
            return currentIndex;
        }
        public static int IndexOf(string haystack, string needle, int beginIndex, int nthOccurrence)
        {
            return IndexOf(haystack, needle, beginIndex, nthOccurrence, -1);
        }
        public static int ReverseIndexOf(string haystack, string needle, int beginIndex, int nthOccurrence)
        {
            return ReverseIndexOf(haystack, needle, beginIndex, nthOccurrence, -1);
        }
        public static int ReverseIndexOf(string haystack, string needle, int beginIndex, int nthOccurrence, int endIndex)
        {
            if (nthOccurrence <= 0)
            {
                throw new ArgumentException("Number of occurences must be a positive integer");
            }
            int searchesLeft = nthOccurrence;
            int currentIndex = beginIndex;
            for (; searchesLeft > 0; searchesLeft--)
            {
                if (endIndex == -1 || endIndex > beginIndex)
                {
                    currentIndex = haystack.LastIndexOf(needle, currentIndex);
                }
                else
                {
                    currentIndex = haystack.LastIndexOf(needle, currentIndex, beginIndex - endIndex + 1);
                }
                if (currentIndex == -1)
                {
                    break;
                }
                else if (searchesLeft > 1)
                {
                    currentIndex--;
                }
            }
            return currentIndex;
        }

    }

}
