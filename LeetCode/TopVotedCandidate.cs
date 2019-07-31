using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class TopVotedCandidate
    {
        int _lastUsedIndex = -1, max = 1;
        int[] person, time, ans;
        Dictionary<int, int> dictionary = new Dictionary<int, int>();
        public TopVotedCandidate(int[] persons, int[] times)
        {
            person = persons;
            time = times;
            ans = new int[person.Length];
        }

        private void Count(int start, int end)
        {
            for (int i = start; i <= end; i++)
            {

                if (i > 0)
                {
                    if (!dictionary.ContainsKey(person[i]))
                    {
                        dictionary[person[i]] = 1;
                        ans[i] = max == 1 ? person[i] : ans[i - 1];
                    }
                    else
                    {
                        var value = dictionary[person[i]];
                        dictionary[person[i]] = value + 1;
                        if (value + 1 > max)
                        {
                            max = value + 1;
                            ans[i] = person[i];
                        }
                        else if (value + 1 == max)
                        {
                            ans[i] = person[i];
                        }
                        else
                            ans[i] = ans[i - 1];
                    }
                }
                else
                {
                    dictionary.Add(person[i], 1); //the man himself
                    ans[i] = person[i];
                }
            }
        }

        private int BinarySearch(int value)
        {
            int start = 0, end = person.Length - 1;
            while (start < end)
            {
                int mid = (start + end) / 2;
                if (time[mid] < value)
                    start = mid + 1;
                else if (time[mid] > value)
                    end = mid - 1;
                else
                    return mid;
            }
            return time[start] > value ? start - 1 : start;
        }

        public int Q(int t)
        {
            var index = BinarySearch(t);
            if (index > _lastUsedIndex)
            {
                Count(_lastUsedIndex + 1, index);
                _lastUsedIndex = index;
            }
            return ans[index];
        }
    }
}
