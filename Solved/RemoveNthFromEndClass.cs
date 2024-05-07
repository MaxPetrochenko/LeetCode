using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Solved
{
    internal class RemoveNthFromEndClass
    {
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            ListNode listNode = null;

            if(head.next is null) return head.next;
            var ss = MemberwiseClone();
            var prev = head;
            head = head.next;
            var pre = new ListNodeExtended(prev.val, null, head);
            var ans = new ListNodeExtended(head.val, pre, head.next);
            head = head?.next;
            while(head != null)
            {
                ans = new ListNodeExtended(head.val, ans, head.next);
                head = head.next;
            }
            for(int i = 0; i < n; i++)
            {
                listNode = ans;
                ans = ans.prev;
            }


            if(ans == null) // position -1, delete at position 0
            {
                return listNode.next;
            }


            if(ans?.next?.next != null)
            {
                var value = ans.next.next;
                ans.next = value;
                if(ans.prev != null)
                    ans.prev.next.next = value;
            }
            else
            {
                ans.next = null;
                if(ans.prev != null)
                    ans.prev.next.next = null;
            }

            while(ans?.prev != null) ans = ans.prev;
            return ans;
        }
    }
    public class ListNodeExtended : ListNode
    {
        public ListNodeExtended prev;
        public ListNodeExtended(int val = 0, ListNodeExtended prev = null, ListNode next = null) : base(val, next)
        {
            this.prev = prev;
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

}
