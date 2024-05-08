using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Solved
{
    internal class CountAndSayClass
    {
        public string CountAndSay(int n)
        {
            if(n == 1) return "1";
            return rec(n - 1);
        }

        public string rec(int n)
        {
            if(n == 1) return "11";
            var s = rec(n - 1);
            int i = 0;
            var sb = new StringBuilder();
            while(i < s.Length)
            {
                int cnt = 1;
                int j = i + 1;
                while(j < s.Length && s[i] == s[j]) { j++; cnt++; }
                sb.Append(cnt)
                  .Append(s[i]);
                i = j;
            }
            return sb.ToString();
        }
    }
}
