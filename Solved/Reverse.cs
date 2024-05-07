using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    static class Reversed
    {
        public static int Reverse(int x)
        {
            string s = x.ToString(), ss = string.Empty;
            int l = s.Length - 1;
            bool hasMinus = false;
            while (l >= 0)
            {
                if (s[l] != '-')
                    ss += s[l];
                else
                {
                    hasMinus = true;
                }
                l--;
            }
            long k = long.Parse(ss);
            if (hasMinus)
                k = -k;
            int y = Int32.MaxValue, yy = Int32.MinValue;
            if (k > y || k < yy)
                return 0;
            return (int)k;
        }
    }
}
