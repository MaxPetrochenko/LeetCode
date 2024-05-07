using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Solved
{
    internal class SearchClass
    {
        public int Search(int[] nums, int target)
        {
            var u = GetAscIndex(nums, target);
            if(nums[u] == target) return u;
            if(target == nums[0]) return 0;

            int res;
            if(target > nums[0])
            {
                res = Array.BinarySearch(nums, 0, u + 1, target);
            }
            else
            {
                if(nums.Length - u - 2 > 0)
                    res = Array.BinarySearch(nums, u + 1, nums.Length - u - 1, target);
                else res = -1;
            }

            if(res < 0) return -1;
            else return res;
        }

        private int GetAscIndex(int[] nums, int target)
        {
            var n = nums.Length - 1;
            var k = n / 2;
            var l = 0;
            var r = n;
            while(l < r)
            {
                var mid = (l + r) / 2;
                if(nums[mid] == target) return mid;
                if(nums[mid] < nums[l])
                {
                    r = mid;
                }
                else
                {
                    l = mid;
                }
                if(l + 1 == r)
                {
                    if(nums[l] == target) return l;
                    if(nums[r] == target) return r;
                    return nums[l] > nums[r] ? l : r;
                }
            }
            return 0;
        }
    }
}
