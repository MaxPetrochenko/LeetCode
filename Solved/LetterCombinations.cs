using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Solved
{
    internal class LetterCombinationsClass
    {
        public IList<string> LetterCombinations(string digits)
        {
            List<List<char>> arr = new List<List<char>>
        {
            new List<char>{ 'a','b','c'},
            new List<char>{ 'd','e','f'},
            new List<char>{ 'g','h','i'},
            new List<char>{ 'j','k','l'},
            new List<char>{ 'm','n','o'},
            new List<char>{ 'p','q','r', 's'},
            new List<char>{ 't','u','v'},
            new List<char>{ 'w','x','y', 'z'},
        };
            var result = new List<string>();


            if(digits.Length == 1)
            {
                var e = digits[0] - '0' - 2;
                var q = arr[e];
                q.ForEach(x => result.Add(x.ToString()));
            }

            if(digits.Length == 2)
            {
                var r1 = digits[0] - '0' - 2;
                var r2 = digits[1] - '0' - 2;
                for(int i = 0; i < arr[r1].Count; i++)
                {
                    for(int j = 0; j < arr[r2].Count; j++)
                    {
                        result.Add(arr[r1][i].ToString() + arr[r2][j].ToString());
                    }
                }
            }

            if(digits.Length == 3)
            {
                var r1 = digits[0] - '0' - 2;
                var r2 = digits[1] - '0' - 2;
                var r3 = digits[2] - '0' - 2;
                for(int i = 0; i < arr[r1].Count; i++)
                {
                    for(int j = 0; j < arr[r2].Count; j++)
                    {
                        for(int k = 0; k < arr[r3].Count; k++)
                        {
                            result.Add(arr[r1][i].ToString() + arr[r2][j].ToString() + arr[r3][k].ToString());
                        }
                    }
                }
            }

            if(digits.Length == 4)
            {
                var r1 = digits[0] - '0' - 2;
                var r2 = digits[1] - '0' - 2;
                var r3 = digits[2] - '0' - 2;
                var r4 = digits[3] - '0' - 2;
                for(int i = 0; i < arr[r1].Count; i++)
                {
                    for(int j = 0; j < arr[r2].Count; j++)
                    {
                        for(int k = 0; k < arr[r3].Count; k++)
                        {
                            for(int q = 0; q < arr[r4].Count; q++)
                            {
                                result.Add(arr[r1][i].ToString() + arr[r2][j].ToString() + arr[r3][k].ToString() + arr[r4][q].ToString());
                            }
                        }
                    }
                }
            }

            return result;
        }
    }
}
