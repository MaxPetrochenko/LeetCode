using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Solved
{
    internal class SearchRangeClass
    {
        public int[] SearchRange(int[] nums, int target)
        {
            var result = new int[] { -1, -1 };
            var index = Array.BinarySearch(nums, target);

            if (index < 0)
                return result;

            if (nums.Length == 1)
                return new int[] { 0, 0 };

            if (nums.Length == 2)
            {
                if (nums[0] == target)
                {
                    result[0] = 0;
                    result[1] = 0;
                }
                if (nums[1] == target)
                {
                    result[1] = 1;
                    if (result[0] == -1)
                        result[0] = 1;
                }

                return result;
            }

            var ans1 = rec(nums, 0, index, true);
            var ans2 = rec(nums, nums.Length - 1, index, false);
            return new int[] { ++ans1, --ans2 };
        }
        private int rec(int[] nums, int dynIndex, int staticIndex, bool status)
        {
            if (status)
                while (nums[dynIndex] < nums[staticIndex] && dynIndex + 1 < staticIndex) dynIndex = dynIndex + staticIndex >> 1;
            else
                while (nums[dynIndex] > nums[staticIndex] && dynIndex - 1 > staticIndex) dynIndex = dynIndex + staticIndex >> 1;

            if (dynIndex == 0)
            {
                if (nums[dynIndex] == nums[staticIndex]) return -1;
                return 0;
            }

            if (dynIndex == nums.Length - 1)
            {
                if (nums[dynIndex] == nums[staticIndex]) return nums.Length;
                return nums.Length - 1;
            }

            if (nums[dynIndex] == nums[staticIndex])
            {
                var previous = dynIndex * 2 - staticIndex;
                if (previous == nums.Length) --previous;
                if (status && dynIndex < staticIndex)
                    return rec(nums, previous, dynIndex, status);
                else if (!status && dynIndex > staticIndex)
                    return rec(nums, previous, dynIndex, status);
            }

            return dynIndex;
        }
    }
}
