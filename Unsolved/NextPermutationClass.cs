using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Unsolved
{
    internal class NextPermutationClass
    {
        public string NextPermutation(int[] nums)
        {
            bool isPermuted = false;
            for(int i = 0; i < nums.Length - 1; i++)
            {
                if(nums[i] < nums[i + 1])
                {
                    int j = i + 1;
                    while(j < nums.Length - 1 && nums[j] < nums[j + 1]) j++;
                    if(j == nums.Length - 1) j--;
                    // [j] is to swap
                    var num = nums[j];
                    var k = j + 1;
                    bool isVisited = false;
                    while(k < nums.Length - 1 && nums[k] > nums[k + 1])
                    {
                        nums[k - 1] = nums[k];
                        k++;
                        isVisited = true;
                    } // [k] is to swap

                    if(!isVisited)
                    {
                        nums[j] = nums[k];
                    }

                    nums[k] = num;
                    i = j;
                    isPermuted = true;
                }
            }
            if(!isPermuted)
            {
                for(int i = 0; i < nums.Length / 2; i++)
                {
                    var tmp = nums[i];
                    nums[i] = nums[nums.Length - 1 - i];
                    nums[nums.Length - 1 - i] = tmp;
                }
            }
            return string.Join(',', nums);
        }
    }
}
