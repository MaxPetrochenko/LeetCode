using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Solved
{
    internal class GenerateParenthesisClass
    {
        public IList<string> GenerateParenthesis(int n)
        {
            HashSet<string> result = new HashSet<string>(new[] { "()" });

            rec(result, 1, n);


            return result.ToList();
        }

        protected ISet<string> rec(HashSet<string> result, int start, int n)
        {
            if(start == n)
                return result;
            List<string> strings = new();
            foreach(var item in result)
            {
                var x = item;
                result.Remove(x);
                strings.AddRange(GenerateStrings(x));

            }
            strings.ForEach(x => result.Add(x));
            return rec(result, start + 1, n);
        }

        protected List<string> GenerateStrings(string x)
        {
            var result = new List<string>();
            for(int i = 0; i < x.Length; i++)
            {
                string s;
                if(i > 0)
                {
                    s = x[0..i] + "()" + x[i..x.Length];

                }
                else
                    s = "()" + x;
                result.Add(s);
            }
            return result;
        }
    }
}
