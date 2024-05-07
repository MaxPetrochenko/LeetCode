using LeetCode.Solved;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Unsolved
{
    internal class ReverseKGroupClass
    {
        public ListNode ReverseKGroup(ListNode head, int k)
        {
            if(k == 1) return head;
            var current = head;
            ListNode lastNode = null;
            ListNode root = null;

            root = rec(head, k);

            if(root == null)
                return head;

            return root;
        }

        private ListNode rec(ListNode currentRoot, int k)
        {
            int i = 0;
            var current = currentRoot;
            ListNode prev = null;
            ListNode next = null;
            ListNode currentHead;

            var root = currentRoot;

            if(currentRoot.next == null)
                return currentRoot;

            ListNode lastNode = null;
            while(current != null && i < k - 1)
            {
                next = current.next;
                ListNode pair;
                if(i == 0)
                    pair = SetNewRoot(currentRoot, current.next, current);
                else
                    pair = SetNewRoot(currentRoot, current, prev);
                currentRoot = pair;
                currentHead = pair;
                prev = current;
                current = current.next; i++;
            }

            if(current == null || current.next == null || i < k - 1)
            {
                return currentRoot;
            }

            if(k == 2)
            {
                if(current.next != null)
                {
                    prev.next = rec(current, k);
                }
            }
            else
            {
                prev.next = rec(current, k);
            }

            return currentRoot;
        }

        private ListNode SetNewRoot(ListNode root, ListNode current, ListNode prev)
        {
            if(current == null)
                return root;

            var tail = current.next;
            current.next = root;
            prev.next = tail;

            return current;
        }
    }
}
