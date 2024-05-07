using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Solved
{
    internal class SwapPairsClass
    {
        public ListNode SwapPairs(ListNode head)
        {
            var current = head;
            ListNode lastNode = null;
            ListNode root = null;
            while(current != null && current.next != null)
            {
                var node = GetSwappedPair(current, current.next);
                if(lastNode != null)
                {
                    lastNode.next.next = node;
                    lastNode = node;
                }
                else
                {
                    lastNode = node;
                    root = node;
                }


                current = current?.next;
            }
            if(root == null)
                return head;

            if(current != null && current.next == null)
            {
                lastNode.next.next = current;
            }
            return root;
        }

        private ListNode GetSwappedPair(ListNode current, ListNode next)
        {
            var nextRef = next.next;
            current.next = nextRef;

            ListNode tmp = next;
            tmp.next = current;
            //current.next = next.next;
            return tmp;
        }
    }
}
