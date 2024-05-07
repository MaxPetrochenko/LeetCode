using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Solved
{
    internal class DivideClass
    {
        public int Divide(int dividend, int divisor)
        {
            if(dividend == divisor) return 1;
            int sign = 1;
            sign = GetAnsSign(sign, dividend, divisor);
            if(divisor == 1 || divisor == -1)
            {
                if(sign < 0 && divisor == -1) return -dividend;
                else return dividend;
                //if(sign < 0 && divisor == 1) return dividend;
                //if(sign > 0 && divisor == 1) return dividend;
                //if(sign > 0 && divisor == -1) return dividend;
            }

            var a = Abs(dividend);
            var b = Abs(divisor);

            if(a < b || (a == b && divisor == int.MinValue)) return 0;



            int ans = 0;

            if(dividend == int.MinValue)
            {
                var d1 = dividend;
                var d2 = -Math.Abs(divisor);
                ans = GetAns(d1, d2, sign, false);
            }
            else
            {
                var d1 = Math.Abs(dividend);
                var d2 = Math.Abs(divisor);
                ans = GetAns(d1, d2, sign, true);
            }

            ans = GetAnsSign(ans, dividend, divisor);

            return ans;
        }

        private int GetAnsSign(int ans, int dividend, int divisor)
        {
            if((dividend > 0 && divisor < 0) || (dividend < 0 && divisor > 0)) ans = -ans;
            return ans;
        }

        private int GetAns(int d1, int d2, int sign, bool dest)
        {
            int ans = 0;

            if(dest)
            {
                while(d1 > d2)
                {
                    d1 -= d2;
                    ans++;
                }
            }
            else
            {
                while(d1 < d2)
                {
                    d1 -= d2;
                    ans++;
                }
            }

            if(d1 == d2)
            {
                if(ans == int.MaxValue)
                {
                    if(sign == -1) ans++;
                }
                else
                    ans++;
            }

            return ans;
        }

        private int Abs(int a)
        {
            if(a == int.MinValue)
                return int.MaxValue;

            return Math.Abs(a);
        }
    }
}
