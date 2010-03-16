using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentSubstring
{
    internal static class StringHelper
    {
        public static int IndexOf(string haystack, string needle, int beginIndex, int nthOccurence)
        {
            if (nthOccurence <= 0)
            {
                throw new ArgumentException("Number of occurences must be a positive integer");
            }
            int searchesLeft = nthOccurence;
            int currentIndex = beginIndex;
            for (; searchesLeft > 0; searchesLeft--)
            {
                currentIndex = haystack.IndexOf(needle, currentIndex);
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
        public static int ReverseIndexOf(string haystack, string needle, int beginIndex, int nthOccurence)
        {
            if (nthOccurence <= 0)
            {
                throw new ArgumentException("Number of occurences must be a positive integer");
            }
            int searchesLeft = nthOccurence;
            int currentIndex = beginIndex;
            for (; searchesLeft > 0; searchesLeft--)
            {
                currentIndex = haystack.LastIndexOf(needle, currentIndex);
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
        public static int IndexOf(string haystack, string needle)
        {
            return haystack.IndexOf(needle);
        }
    }

}
