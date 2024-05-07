using LeetCode.Solved;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Xml.Linq;

var s = new Solution();
var q1 = new ListNode(5);
var q2 = new ListNode(4, q1);
var q3 = new ListNode(3, q2);
var q4 = new ListNode(2, q3);
var q5 = new ListNode(1, q4);
var q6 = new ListNode(-3, q5);

var w1 = new ListNode(4);
var w2 = new ListNode(3, w1);
var w3 = new ListNode(2, w2);
var w4 = new ListNode(1, w3);

var e1 = new ListNode(6);
var e2 = new ListNode(2, e1);

ListNode[] lists = new[] { q3, w3, e2 };



//s.ReverseKGroup(q5, 2);
//s.ReverseKGroup(q5, 3);

//Console.WriteLine(s.NextPermutation(new int[] { 1, 2, 3 }));
//Console.WriteLine(s.NextPermutation(new int[] { 3, 2, 1 }));
//Console.WriteLine(s.NextPermutation(new int[] { 7, 6, 5, 4, 3, 2, 1 }));
//Console.WriteLine(s.NextPermutation(new int[] { 1, 1, 5 }));
Console.ReadKey();
public class Solution
{
}
