using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Solved
{
    internal class MergeKListsClass
    {
        const int arrLength = 5_000_000;
        public ListNode MergeKLists(ListNode[] lists)
        {
            ListNode result = null;
            var toMerge = new int[arrLength];
            int k = 0;
            for(int i = 0; i < lists.Length; i++)
            {
                while(lists[i] != null)
                {
                    toMerge[k++] = lists[i].val;
                    lists[i] = lists[i].next;
                }
            }
            if(k == 0) return default;

            sort(toMerge, k);
            var last = new ListNode(toMerge[k - 1]);
            for(int i = k - 2; i >= 0; i--)
            {
                result = new ListNode(toMerge[i], last);
                last = result;
            }
            if(last != null && result == null)
                result = last;

            return result;
        }
        public static void sort(int[] arr, int length)
        {
            int n = length;

            for(int i = n / 2 - 1; i >= 0; i--)
                heapify(arr, n, i);

            for(int i = n - 1; i >= 0; i--)
            {
                int temp = arr[0];
                arr[0] = arr[i];
                arr[i] = temp;

                heapify(arr, i, 0);
            }
        }


        public static void heapify(int[] arr, int n, int i)
        {
            int largest = i;
            int l = 2 * i + 1; // left = 2*i + 1
            int r = 2 * i + 2; // right = 2*i + 2

            if(l < n && arr[l] > arr[largest])
                largest = l;

            if(r < n && arr[r] > arr[largest])
                largest = r;

            if(largest != i)
            {
                int swap = arr[i];
                arr[i] = arr[largest];
                arr[largest] = swap;

                heapify(arr, n, largest);
            }
        }
    }
}
