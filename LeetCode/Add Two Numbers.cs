using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }
    static class Add_Two_Numbers
    {
        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            return Add(l1, l2);
        }
        public static ListNode Add(ListNode l1, ListNode l2, int overflow = 0)
        {
            if (l1 == null && l2 == null && overflow == 0) return null;
            int cache = (l1?.val ?? 0) + (l2?.val ?? 0) + overflow;
            return new ListNode(cache % 10)
            {
                next = Add(l1?.next, l2?.next, cache / 10)
            };
        }
    }
}
