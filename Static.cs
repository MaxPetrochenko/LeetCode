using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public static class Static
    {
        public static (int, int, int) sortAction(int a, int b, int c)
        {
            if(a <= c)
            {
                var min = Math.Min(a, b);
                var max = Math.Max(a, b);
                //if a < b, then b < c or b >= c
                //if a > b, then b < c
                if(a > b || b < c)
                    return (min, max, c);

                return (min, c, max);
            }
            else
                return sortAction(c, b, a);
        }


        public static void sort(int[] arr, int[] iin, int[] jin, int length)
        {
            //int n = arr.Length;
            int n = length;

            for(int i = n / 2 - 1; i >= 0; i--)
                heapify(arr, n, i, iin, jin);

            for(int i = n - 1; i >= 0; i--)
            {
                int temp = arr[0];
                arr[0] = arr[i];
                arr[i] = temp;

                temp = iin[0];
                iin[0] = iin[i];
                iin[i] = temp;

                temp = jin[0];
                jin[0] = jin[i];
                jin[i] = temp;

                heapify(arr, i, 0, iin, jin);
            }
        }


        public static void heapify(int[] arr, int n, int i, int[] iin, int[] jin)
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

                swap = iin[i];
                iin[i] = iin[largest];
                iin[largest] = swap;

                swap = jin[i];
                jin[i] = jin[largest];
                jin[largest] = swap;

                heapify(arr, n, largest, iin, jin);
            }
        }
    }
}
