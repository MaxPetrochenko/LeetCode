using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class MyLinkedList
    {
        internal class Node<T>
        {
            public Node(T data)
            {
                Data = data;
            }
            public T Data { get; set; }
            public Node<T> Next { get; set; }
        }
        int countHead, countTail, count;
        Node<int> head, tail;
        /** Initialize your data structure here. */
        public MyLinkedList()
        {

        }

        /** Get the value of the index-th node in the linked list. If the index is invalid, return -1. */
        public int Get(int index)
        {
            if (index >= count) return -1;
            if (index == 0) return head.Data;
            var node = FindPrevNodeByIndex(index);
            return node.Next.Data;
        }

        /** Add a node of value val before the first element of the linked list. After the insertion, the new node will be the first node of the linked list. */
        public void AddAtHead(int val)
        {
            /* Node<int> node = new Node<int>(val);
             node.Next = head;
             head = node;
             if (count == 0)
                 tail = head;
             count++;*/
            Node<int> node = new Node<int>(val);
            if (head == null) head = node;
            else
            {
                node.Next = head;
                head = node;
            }
            if (count == 0)
                tail = head;
            count++;
            countHead++;
        }

        /** Append a node of value val to the last element of the linked list. */
        public void AddAtTail(int val)
        {
            Node<int> node = new Node<int>(val);
            if (head == null) head = node;
            else tail.Next = node;
            tail = node;
            count++;
            countTail++;
        }

        /** Add a node of value val before the index-th node in the linked list. If index equals to the length of linked list, the node will be appended to the end of linked list. 
         * If index is greater than the length, the node will not be inserted. */
        public void AddAtIndex(int index, int val)
        {
            if (index > count) return;
            if (index == count)
            {
                AddAtTail(val);
                return;
            }
            var node = FindPrevNodeByIndex(index);
            var oldNode = node.Next;
            node.Next = new Node<int>(val);
            node.Next.Next = oldNode;
            /*
            if (node != null)
            {
                var oldNode = node.Next;
                node.Next = new Node<int>(val);
                node.Next.Next = oldNode;
            }
            else
            {
                node = new Node<int>(val);
                tail = node;
            }*/
            count++;
        }

        /** Delete the index-th node in the linked list, if the index is valid. */
        public void DeleteAtIndex(int index)
        {
            if (index >= count) return;
            var node = FindPrevNodeByIndex(index);
            node.Next = node.Next.Next;
            count--;
        }

        /// <summary>
        /// Returns current and previous nodes by index
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private Node<int> FindPrevNodeByIndex(int index, int value = -1)
        {
            Node<int> current = head, prev = null;
            for (int i = 0; i < index - 1; i++)
            {
                /*prev = current;
                if (prev == null) return null;*/
                if (current == null) return null;
                current = current.Next;
            }
            //return new Tuple<Node<int>, Node<int>>(current, prev);
            //return prev;
            return current;
        }
    }




}
