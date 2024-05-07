using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Solved
{
    internal class FourSomeClass
    {
        public IList<IList<int>> FourSum(int[] nums, int target)
        {
            bool isNegated = false;
            if(target < 0)
            {
                for(int i = 0; i < nums.Length; i++) nums[i] = -nums[i];
                target = -target;
                isNegated = true;
            }
            int n = nums.Length;
            IList<IList<int>> ans = new List<IList<int>>();
            var hash = new HashSet<(int, int, int, int)>();
            Array.Sort(nums);
            for(int i = 0; i < n; i++)
            {
                if(i > 0 && nums[i] == nums[i - 1]) continue;
                for(int j = i + 1; j < n; j++)
                {
                    if(j > i + 1 && nums[j] == nums[j - 1]) continue;
                    int k = j + 1;
                    int l = n - 1;
                    while(k < l)
                    {
                        long sum = nums[i]; sum += nums[j]; sum += nums[k]; sum += nums[l];
                        if(sum < target) k++;
                        else if(sum > target) l--;
                        else
                        {
                            //ans.Add(new List<int> { nums[i], nums[j], nums[k], nums[l] });
                            hash.Add((nums[i], nums[j], nums[k], nums[l]));
                            k++; l--;
                            //while(k < l && nums[k] == nums[k - 1]) k++;
                            //while(k < l && nums[l] == nums[l - 1]) l--;
                        }
                    }
                }
            }
            if(isNegated)
            {
                foreach(var item in hash)
                    ans.Add(new List<int> { -item.Item1, -item.Item2, -item.Item3, -item.Item4 });
            }
            else
                foreach(var item in hash)
                    ans.Add(new List<int> { item.Item1, item.Item2, item.Item3, item.Item4 });

            return ans;
        }
    }
}
