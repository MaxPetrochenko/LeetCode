using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Solved
{
    internal class ThreeSumClosestClass
    {
        public int ThreeSumClosest(int[] nums, int target)
        {
            var n = nums.Length;
            if(n == 3)
                return nums[0] + nums[1] + nums[2];

            var tempLength = (n * n - n) / 2;
            Array.Sort(nums);
            int[] temp = new int[tempLength], iin = new int[tempLength], jin = new int[tempLength];
            int cnt = 0;

            for(int i = 0; i < nums.Length; i++)
            {
                for(int j = i + 1; j < nums.Length; j++)
                {
                    temp[cnt] = nums[i] + nums[j];
                    iin[cnt] = i; jin[cnt] = j;
                    cnt++;
                }
            }

            Static.sort(temp, iin, jin, cnt);
            var ans = target > 0 ? int.MinValue : int.MaxValue;
            int absDiff = int.MaxValue;
            int result = 0;
            for(int i = 0; i < nums.Length; i++)
            {
                var newTarget = target - nums[i];

                var found = Array.BinarySearch(temp, 0, cnt - 1, newTarget);
                if(found < 0) found = ~found;
                if(found > 0)
                {
                    var diff1 = Math.Abs(Math.Abs(temp[found]) - Math.Abs(newTarget));
                    var diff2 = Math.Abs(Math.Abs(temp[found - 1]) - Math.Abs(newTarget));
                    if(diff2 < diff1) found--;
                }
                var curSum = temp[found];
                int j = found;
                int k = j;
                while(true)
                {
                    bool jOff, kOff;
                    if(j >= 0 && temp[j] == curSum)
                    {
                        jOff = true;
                        var _i = iin[j];
                        var _j = jin[j];
                        if(i != _i && i != _j) // add
                        {
                            var allSum = temp[found] + nums[i];
                            if(allSum == target) return target;
                            if(Math.Abs(target - allSum) < absDiff)
                            {
                                absDiff = Math.Abs(target - allSum);
                                result = allSum;
                            }
                            break;
                        }
                        else j--;
                    }
                    else
                        jOff = false;

                    if(k < cnt && temp[k] == curSum)
                    {
                        kOff = true;
                        var _i = iin[k];
                        var _j = jin[k];
                        if(i != _i && i != _j) // add
                        {
                            var allSum = temp[found] + nums[i];
                            if(allSum == target) return target;
                            if(Math.Abs(target - allSum) < absDiff)
                            {
                                absDiff = Math.Abs(target - allSum);
                                result = allSum;
                            }
                            break;
                        }
                        else k++;
                    }
                    else
                        kOff = false;
                    if((j < 0 && k >= cnt) || (!jOff && !kOff)) break;
                }
            }
            return result;
        }
    }
}
