using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class Program
    {
        public static bool IsPalindrome(int x)
        {
            if (x < 0 || (x % 10 == 0 && x != 0))
                return false;
            string s = x.ToString();
            int l = s.Length;
            for (int i = 0; i < l / 2; i++)
            {
                if (s[i] != s[l - 1 - i])
                    return false;
            }
            return true;
        }
        public static bool IsPalindrome(string s)
        {
            string q = "", qq = "";
            for (int i = 0; i < s.Length; i++)
            {
                if ((s[i] >= 97 && s[i] <= 122) || (s[i] >= 48 && s[i] <= 57)) q += s[i];
                if (s[i] >= 65 && s[i] <= 90) q = q + (char)(s[i] + 32);
            }
            for (int i = 0; i < q.Length; i++) qq = q[i] + qq;
            return q == qq;
        }

        public static int RomanToInt(string s)
        {
            int result = 0;
            for (int i = 0; i < s.Length; i++)
            {
                switch (s[i])
                {
                    case 'M':
                        result += 1000;
                        break;
                    case 'D':
                        result += 500;
                        break;
                    case 'C':
                        result += 100;
                        break;
                    case 'L':
                        result += 50;
                        break;
                    case 'X':
                        result += 10;
                        break;
                    case 'V':
                        result += 5;
                        break;
                    case 'I':
                        result += 1;
                        break;
                }
            }
            if (s.Contains("CD") || s.Contains("CM"))
                result -= 200;
            if (s.Contains("XL") || s.Contains("XC"))
                result -= 20;
            if (s.Contains("IV") || s.Contains("IX"))
                result -= 2;
            return result;

        }

        public static string LongestCommonPrefix(string[] strs)
        {
            string res = string.Empty;
            if (strs.Length > 0)
            {
                Array.Sort(strs);
                int l1 = strs[0].Length, l2 = strs[strs.Length - 1].Length, l3 = Math.Min(l1, l2);
                for (int i = 0; i < l3; i++)
                {
                    if (strs[0][i] != strs[strs.Length - 1][i])
                        break;
                    res += strs[0][i];
                }
            }
            return res;
        }

        public static Tuple<char, int> Rec(string s, int index)
        {
            Tuple<char, int> ans = null;
            switch (s[index])
            {
                case '{':
                case '(':
                case '[':
                    ans = Rec(s, index + 1);
                    if (ans.Item1 == s[index])
                    {

                    }
                    break;
                case '}':
                case ')':
                case ']':
                    ans = new Tuple<char, int>(s[index], index);
                    break;
            }
            return ans;
        }

        public static bool IsValid(string s)
        {

            return false;
        }

        public static int RemoveDuplicates(int[] nums)
        {
            if (nums.Length == 0) return 0;
            else if (nums.Length == 1) return 1;
            else if (nums.Length == 2 && nums[0] != nums[1]) return 2;
            int i = 0, j = i, ans = 0;
            int[] an = (int[])nums.Clone();
            while (i < an.Length)
            {
                nums[ans] = an[i];
                ans++;
                j = i + 1;
                if (j < an.Length)
                {
                    while (j < an.Length && an[i] == an[j]) j++;
                }
                i = j;
            }
            return ans;
        }

        public static int RemoveElement(int[] nums, int val)
        {
            int l = 0;
            //bool v = val == int.MaxValue;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == val)
                {
                    nums[i] = int.MaxValue;
                    l++;
                }
            }
            Array.Sort(nums);
            return nums.Length - l;
        }

        public static int MaxSubArray(int[] nums)
        {
            int n = nums.Length, max = nums[0];
            for (int i = 1; i < n; i++)
            {
                if (nums[i - 1] > 0)
                {
                    nums[i] += nums[i - 1];

                }
                if (nums[i] > max) max = nums[i];
            }
            return max;
        }

        public static int LengthOfLastWord(string s)
        {
            int length = 0;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (s[i] == ' ' && length > 0) break;
                if (s[i] != ' ') length++;
            }
            return length;
        }

        public static int[] PlusOne(int[] digits)
        {
            bool br = false;
            digits[digits.Length - 1] += 1;
            for (int i = digits.Length - 1; i > 0; i--)
            {

                if (digits[i] == 10)
                {
                    digits[i - 1] += 1;
                    digits[i] = 0;
                }
                else
                {
                    br = true;
                    break;
                }
            }
            if (!br)
            {
                if (digits[0] == 10)
                {
                    int[] d = new int[digits.Length + 1];
                    digits[0] = 0;
                    d[0] = 1;
                    for (int i = 1; i < digits.Length; i++)
                    {
                        d[i] = digits[i - 1];
                    }
                    return d;
                }
                else return digits;
            }
            return digits;
        }

        public static char AddChar(char a, char b, ref bool addOneToNext)
        {
            char res;
            if ((a == '1' && b == '0') || (a == '0' && b == '1'))
            {
                if (addOneToNext)
                {
                    res = '0';
                }
                else res = '1';
            }
            else if (a == '1' && b == '1')
            {
                if (addOneToNext)
                    res = '1';
                else
                {
                    res = '0';
                    addOneToNext = true;
                }
            }
            else //0 0
            {
                if (addOneToNext)
                {
                    res = '1';
                    addOneToNext = false;
                }
                else
                    res = '0';
            }
            return res;
        }
        public static string AddBinary(string a, string b)
        {
            int minlength = Math.Min(a.Length, b.Length);
            bool addOneToNext = false;
            string res = string.Empty;
            for (int i = minlength - 1; i >= 0; i--)
            {
                if (a.Length == minlength)
                    res += AddChar(a[i], b[b.Length + i - minlength], ref addOneToNext);
                else
                    res += res += AddChar(a[a.Length + i - minlength], b[i], ref addOneToNext);
            }
            if (minlength != a.Length || minlength != b.Length)
            {
                if (minlength != a.Length)
                {
                    for (int i = a.Length - minlength - 1; i >= 0; i--)
                    {
                        res += AddChar(a[i], '0', ref addOneToNext);
                    }
                }
                else
                {
                    for (int i = b.Length - minlength - 1; i >= 0; i--)
                    {
                        res += AddChar(b[i], '0', ref addOneToNext);
                    }
                }
            }
            if (addOneToNext) res += '1';
            string s = string.Empty;
            for (int i = res.Length - 1; i >= 0; i--)
                s += res[i];
            return s;
        }

        public static int MySqrt(int x)
        {
            if (x == 0) return 0;
            if (x == 2147483647) return 46340;
            int current = 1;
            for (int i = 2; i < 46342; i++)
            {
                current = i * i;
                if (current == x) return i;
                if (current > x || current < 0) return i - 1;
            }
            return current;
        }

        public static int ClimbStairs(int n)
        {
            if (n < 4) return n;
            int[] f = new int[n];
            f[0] = 1;
            f[1] = 2;
            f[2] = 3;
            for (int i = 3; i < n; i++)
            {
                f[i] = f[i - 1] + f[i - 2];
            }
            return f[n - 1];
        }

        public static bool IsSameTree(TreeNode p, TreeNode q)
        {
            if ((p == null && q != null) || (p != null && q == null)) return false;
            if (p == null && q == null) return true;
            if (IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right) && p.val == q.val)
                return true;
            else return false;
        }

        public static bool IsMonotonic(int[] A)
        {
            int max = A[0], maxchanged = 1;
            int min = A[0], minchanged = 1;
            bool maxc = false, minc = false;
            for (int i = 1; i < A.Length; i++)
            {
                if (A[i] >= max)
                {
                    if (minc) return false;
                    if (A[i] > max) maxc = true;
                    max = A[i];
                    maxchanged = i;

                }
                else if (A[i] <= min)
                {
                    if (maxc) return false;
                    if (A[i] < min) minc = true;
                    min = A[i];
                    minchanged = i;
                }
                else
                {
                    if (A[i] < max) return false;
                    if (A[i] > min) return false;
                }
            }
            return true;
        }

        static TreeNode staticTreeNode = null;
        public static void retval(TreeNode node)
        {
            if (node == null) return;
            retval(node.left);
            node.left = null;
            staticTreeNode.right = node;
            staticTreeNode = staticTreeNode.right;
            retval(node.right);
        }
        public static TreeNode IncreasingBST(TreeNode root)
        {
            /*List<int> list = new List<int>();
            retval(root, list);*/
            TreeNode node = new TreeNode(0);
            staticTreeNode = node;
            retval(root);
            return node.right;
        }
        public static string OrderlyQueue(string S, int K)
        {
            if (K == 1)
            {
                String ans = S;
                for (int i = 0; i < S.Length; ++i)
                {
                    String T = S.Substring(i) + S.Substring(0, i);
                    if (T.CompareTo(ans) < 0) ans = T;
                }
                return ans;
            }
            else
            {
                char[] ca = S.ToCharArray();
                Array.Sort(ca);
                return new String(ca);
            }
        }

        public static int SubarrayBitwiseORs(int[] A)
        {
            HashSet<int> ans = new HashSet<int>();
            HashSet<int> cur = new HashSet<int>();
            cur.Add(0);
            foreach (int x in A)
            {
                HashSet<int> cur2 = new HashSet<int>();
                foreach (int y in cur)
                    cur2.Add(x | y);
                cur2.Add(x);
                cur = cur2;
                foreach (var item in cur)
                    ans.Add(item);
            }

            return ans.Count;
        }

        public static bool IsSubtreesSymmetric(TreeNode first, TreeNode second)
        {
            if (first == null && second == null) return true;
            if ((first == null && second != null) || (first != null && second == null)) return false;
            return (IsSubtreesSymmetric(first.right, second.left) && IsSubtreesSymmetric(first.left, second.right) && first.val == second.val);
        }
        public static bool IsSymmetric(TreeNode root)
        {
            if (root == null) return true;
            return IsSubtreesSymmetric(root.left, root.right);
        }

        public static int goDeeperMax(TreeNode node, int maxDepth)
        {
            if (node == null) return maxDepth;
            maxDepth++;
            return Math.Max(goDeeperMax(node.left, maxDepth), goDeeperMax(node.right, maxDepth));
        }
        public static int MaxDepth(TreeNode root)
        {
            if (root == null) return 0;
            int maxDepth = 1;
            return goDeeperMax(root, maxDepth) - 1;
        }
        public static int goDeeperMin(TreeNode node, int maxDepth)
        {
            if (node == null) return int.MaxValue;
            if (node.left == null && node.right == null) return maxDepth;
            maxDepth++;
            int ans = Math.Min(goDeeperMin(node.left, maxDepth), goDeeperMin(node.right, maxDepth));
            return ans;
        }
        public static int MinDepth(TreeNode root)
        {
            if (root == null) return 0;
            int maxDepth = 1;
            return goDeeperMin(root, maxDepth);
        }
        public static void goDeeperDown(TreeNode node, int maxDepth, List<List<int>> list)
        {
            if (node == null) return;
            else if (node.left == null && node.right == null)
            {
                maxDepth++;
                if (maxDepth > list.Count)
                {
                    list.Add(new List<int>());
                }
                list[maxDepth - 1].Add(node.val);
            }
            else
            {
                maxDepth++;
                if (maxDepth > list.Count)
                {
                    list.Add(new List<int>());
                }
                list[maxDepth - 1].Add(node.val);
                goDeeperDown(node.left, maxDepth, list);
                goDeeperDown(node.right, maxDepth, list);
            }
        }

        public static List<List<int>> LevelOrderBottom(TreeNode root)
        {
            List<List<int>> list = new List<List<int>>();
            goDeeperDown(root, 0, list);
            List<List<int>> listN = new List<List<int>>();
            for (int i = list.Count - 1; i >= 0; i--)
            {
                listN.Add(new List<int>());
                for (int j = 0; j < list[i].Count; j++)
                    listN[listN.Count - 1].Add(list[i][j]);
            }
            return listN;
        }

        public static TreeNode SortedArrayToBST(int[] nums)
        {
            /*if (nums.Length == 0) return null;
            TreeNode ans = new TreeNode(nums[nums.Length / 2]);
            if (nums.Length == 2)
            {
                ans.left = new TreeNode(nums[0]);
                return ans;
            }
            if (nums.Length == 4)
            {
                ans.left = new TreeNode(nums[1]);
                ans.left.left = new TreeNode(nums[0]);
                ans.right = new TreeNode(nums[3]);
                return ans;
            }
            TreeNode left = null, right = null;
            if (nums.Length > 1)
            {
                int k = nums.Length % 2;
                left = new TreeNode(nums[nums.Length / 2 - 1 - (k == 1 ? 0 : 1)]);
                TreeNode cur = left;
                for (int i = nums.Length / 2 - 1 - (k == 1 ? 0 : 1); i >= 0; i--)
                {
                    left = new TreeNode(nums[i]);
                    cur.left = left;
                    left = cur.left;
                    if (i == 0 && k == 0) cur.right = new TreeNode(nums[nums.Length / 2 - 1]);
                }
                ans.left = cur;
            }
            if (nums.Length > 2)
            {
                right = new TreeNode(nums[nums.Length - 1]);
                TreeNode cur = right;
                for (int i = nums.Length - 2; i > nums.Length / 2; i--)
                {
                    right = new TreeNode(nums[i]);
                    cur.left = right;
                    right = cur.left;
                }
                ans.right = cur;
            }
            return ans;
            */
            return SortedArrayToBSTrec(nums, 0, nums.Length);
        }

        public static TreeNode SortedArrayToBSTrec(int[] nums, int low, int high)
        {
            if (low == high)
            {
                return null;
            }
            int mid = (low + high) / 2;
            TreeNode ret = new TreeNode(nums[mid]);
            ret.left = SortedArrayToBSTrec(nums, low, mid);
            ret.right = SortedArrayToBSTrec(nums, mid + 1, high);
            return ret;
        }

        public static bool AddValue(TreeNode node, int curSum, int sum)
        {
            if (node == null) return false;
            if (node.left == null && node.right == null)
            {
                curSum += node.val;
                if (curSum == sum) return true;
                else return false;
            }
            curSum += node.val;
            return AddValue(node.left, curSum, sum) || AddValue(node.right, curSum, sum);
        }
        public static bool HasPathSum(TreeNode root, int sum)
        {
            return AddValue(root, 0, sum);
        }

        public static void AddValueWithPath(TreeNode node, int sum, IList<int> list)
        {
            if (node == null) return;

            var l = new List<int>(list);
            l.Add(node.val);

            if (node.left == null && node.right == null && node.val == sum)
            {
                result.Add(new List<int>(l));
            }

            if (node.left != null) AddValueWithPath(node.left, sum - node.val, l);
            if (node.right != null) AddValueWithPath(node.right, sum - node.val, l);
        }
        static List<IList<int>> result = new List<IList<int>>();
        public static IList<IList<int>> PathSum(TreeNode root, int sum)
        {

            AddValueWithPath(root, sum, new List<int>());
            return result;
        }

        public static List<List<int>> Generate(int numRows)
        {
            List<List<int>> res = new List<List<int>>();
            if (numRows > 0)
                res.Add(new List<int>() { 1 });
            if (numRows > 1)
                res.Add(new List<int>() { 1, 1 });
            for (int i = 2; i < numRows; i++)
            {
                res.Add(new List<int>() { 1 });
                for (int j = 1; j < i; j++)
                {
                    res[i].Add(res[i - 1][j] + res[i - 1][j - 1]);
                }
                res[i].Add(1);
            }
            return res;
        }

        public static IList<int> GetRow(int rowIndex)
        {
            IList<int> list = new List<int>();
            if (rowIndex > 0)
            {
                list.Add(1);
                for (int i = 1; i < rowIndex; i++)
                {
                    for (int j = list.Count - 1; j > 0; j--)
                    {
                        list[j] += list[j - 1];
                    }
                    list.Add(1);
                }

            }
            return list;
        }

        static int min = int.MaxValue;
        public static void GetMin(IList<IList<int>> triangle, int curRow, int curSum, int index)
        {

            curSum += triangle[curRow][index];
            if (curRow == triangle.Count - 1)
            {
                if (curSum < min)
                    min = curSum;
            }
            else
            {
                GetMin(triangle, curRow + 1, curSum, index);
                GetMin(triangle, curRow + 1, curSum, index + 1);
            }
        }
        public static int MinimumTotal(IList<IList<int>> triangle)
        {
            GetMin(triangle, 0, 0, 0);
            return min;
        }

        public static int SingleNumber(int[] nums)
        {
            int k = 0;
            foreach (var item in nums)
                k ^= item;
            return k;
        }

        public static int MinCostClimbingStairs(int[] cost)
        {
            int dp0 = 0, dp1 = 0;
            for (int i = cost.Length - 1; i >= 0; i--)
            {
                int dp2 = cost[i] + Math.Min(dp0, dp1);
                dp1 = dp0;
                dp0 = dp2;
            }
            return Math.Min(dp0, dp1);
        }

        public static int Rob(int[] nums)
        {
            if (nums.Length == 0)
                return 0;
            if (nums.Length == 1)
                return nums[0];
            if (nums.Length == 2)
                return Math.Max(nums[0], nums[1]);

            int[] dp = new int[nums.Length];
            dp[0] = nums[0]; dp[1] = nums[1]; dp[2] = nums[0] + nums[2];
            int max = Math.Max(Math.Max(dp[0], dp[1]), dp[2]);
            for (int i = 3; i < nums.Length; i++)
            {
                dp[i] = Math.Max(dp[i - 2], dp[i - 3]) + nums[i];
                if (dp[i] > max) max = dp[i];
            }
            return max;
            /*
            if (nums.Length == 4)
                return Math.Max(Math.Max(nums[0] + nums[2], nums[0] + nums[3]), nums[1] + nums[3]);
            int oddSum=0, evenSum=0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (i % 2 == 0)
                    evenSum += nums[i];
                else
                    oddSum += nums[i];
            }
            return Math.Max(evenSum, oddSum);*/
        }
        public class NumArray
        {
            int[] dp = null;
            public NumArray(int[] nums)
            {
                if (nums.Length > 0)
                {
                    dp = new int[nums.Length];
                    dp[0] = nums[0];
                    for (int i = 1; i < nums.Length; i++)
                    {
                        dp[i] = nums[i] + dp[i - 1];
                    }
                }
            }

            public int SumRange(int i, int j)
            {
                if (i == 0)
                    return dp[j];
                else
                    return dp[j] - dp[i - 1];
            }
        }

        public static int[] CountBits(int num)
        {
            int[] ans = new int[num + 1];
            if (num == 0)
                return new int[] { 0 };
            if (num == 1)
                return new int[] { 0, 1 };
            ans[0] = 0;
            ans[1] = 1;
            for (int i = 1; 1 << i <= num; i++)
            {
                int j = 0, cnt = 1 << i, last = 1 << (i - 1);

                while (j < cnt && cnt + j <= num)
                {
                    int div = j >= last ? 1 : 0;
                    ans[cnt + j] = j == 0 ? ans[last] : ans[last + j % last] + div;
                    j++;
                }
            }
            return ans;
        }

        public static int NumberOfArithmeticSlices(int[] A)
        {
            if (A.Length < 3) return 0;
            int ans = 0;
            int[] d = new int[A.Length];
            d[0] = 1;
            for (int i = 1; i < A.Length - 1; i++)
            {
                d[i] = d[i - 1] + i + 1;
                int j = i;
                int len = 0;
                while (j < A.Length - 1 && (A[j] - A[j - 1] == A[j + 1] - A[j]))
                {
                    d[j] = d[j - 1] + j + 1;
                    len++;
                    j++;
                }
                if (len > 0)
                    ans += d[len - 1];
                i = j;
            }
            return ans;
        }

        public static int NumJewelsInStones(string J, string S)
        {
            Dictionary<char, bool> d = new Dictionary<char, bool>();
            int ans = 0;
            foreach (var c in J) d.Add(c, true);
            foreach (var c in S) if (d.ContainsKey(c)) ans++;
            return ans;
        }

        public static string ToLowerCase(string str)
        {
            string strs = "";
            for (int i = 0; i < str.Length; i++)
            {
                char c;
                if (str[i] >= 65 && str[i] <= 90)
                {
                    c = (char)(str[i] + 32);
                }
                else c = str[i];
                strs += c;
            }
            return strs;
        }

        public class Codec
        {
            private const string path = @"http://tinyurl.com/4e9iAk";
            private string url = "";
            // Encodes a URL to a shortened URL
            public string encode(string longUrl)
            {
                url = longUrl;
                return path;
            }

            // Decodes a shortened URL to its original URL.
            public string decode(string shortUrl)
            {
                return url;
            }
        }

        public static bool JudgeCircle(string moves)
        {
            int u = 0, d = 0, l = 0, r = 0;
            foreach (var c in moves)
            {
                switch (c)
                {
                    case 'U':
                        u++;
                        break;
                    case 'D':
                        d++;
                        break;
                    case 'L':
                        l++;
                        break;
                    case 'R':
                        r++;
                        break;
                }
            }
            return (u == d && l == r);
        }

        public static int[][] FlipAndInvertImage(int[][] A)
        {
            if (A.Length < 1 || A == null) return A;
            int[][] b = new int[A[0].Length][];
            for (int i = 0; i < A.Length; i++)
            {
                b[i] = new int[A[i].Length];
                for (int j = 0; j < A[i].Length; j++)
                {
                    b[i][j] = A[i][A[i].Length - 1 - j] ^ 1;
                }
            }
            return b;
        }


        public static TreeNode PruneTree(TreeNode root)
        {
            if (root == null) return null;

            root.left = PruneTree(root.left);
            root.right = PruneTree(root.right);

            if (root.val == 0 && root.left == null && root.right == null) root = null;

            return root;
        }

        private static void mergeTrees(ref TreeNode left, TreeNode right)
        {
            if (left == null) left = right;
            else if (right == null) { }
            else
            {
                mergeTrees(ref left.left, right.left);
                mergeTrees(ref left.right, right.right);
                left.val += right.val;
            }
        }
        public static TreeNode MergeTrees(TreeNode t1, TreeNode t2)
        {
            if (t1 == null) return t2;
            if (t2 == null) return t1;
            mergeTrees(ref t1, t2);
            return t1;
        }

        public static int[] NumberOfLines(int[] widths, string S)
        {
            int w = 0, lines = 1;
            for (int i = 0; i < S.Length; i++)
            {
                var c = S[i];
                if (widths[c - 97] + w > 100)
                {
                    w = widths[c - 97];
                    lines++;
                }
                else if (widths[c - 97] + w == 100)
                {
                    if (i < S.Length - 1)
                    {
                        w = 0;
                        lines++;
                    }
                    else w = 100;
                }
                else
                {
                    w += widths[c - 97];
                }
            }

            return new int[] { lines, w };
        }

        public static string ReverseWords(string s)
        {
            s.Reverse();
            StringBuilder b = new StringBuilder();
            b.Append(s.Reverse());
            string ans = "";
            for (int i = 0; i < s.Length; i++)
            {

            }
            return ans;
        }

        public static string CustomSortString(string S, string T)
        {
            string ans = "";
            var t = T.ToCharArray();
            for (int i = 0; i < S.Length; i++)
            {
                for (int j = 0; j < t.Length; j++)
                    if (S[i] == t[j])
                    {
                        ans += S[i];
                        t[j] = 'X';
                    }
            }
            foreach (var item in t)
            {
                if (item != 'X') ans += item;
            }
            return ans;
        }

        private static Tuple<int, int> findRec(TreeNode node, int currentLevel)
        {
            if (node == null) return new Tuple<int, int>(0, 0);
            if (node.left == null && node.right == null)
            {
                currentLevel++;
                return new Tuple<int, int>(currentLevel, node.val);
            }
            currentLevel++;
            var left = findRec(node.left, currentLevel);
            var right = findRec(node.right, currentLevel);
            if (left.Item1 >= right.Item1) return left;
            else return right;
        }
        public static int FindBottomLeftValue(TreeNode root)
        {
            var t = findRec(root, 0);
            return t.Item2;
        }

        public static int FindComplement(int num)
        {
            int cnt = 0, buf = num;
            while (num >= 1)
            {
                num /= 2;
                cnt++;
            }
            return buf ^ ((1 << cnt) - 1);
        }

        private static int findSingleNonDuplicate(int l, int r, int[] a)
        {
            if (r - l <= 3)
            {
                if (a[l] == a[l + 1]) return a[l + 2];
                else return a[l];
            }
            if (l == r) return a[l];
            /*if (a[(l + r) / 2] == a[(l + r) / 2 - 1])
            {*/
            if ((r - l) % 2 == 1)
                return findSingleNonDuplicate(l, (l + r) / 2, a);
            else
                return findSingleNonDuplicate((l + r) / 2, r, a);
            /*}
            if (a[(l + r) / 2] == a[(l + r) / 2 + 1])
            {
                if ((l + r) % 2 == 1)
                    return findSingleNonDuplicate(l, (l + r) / 2, a);
                else
                    return findSingleNonDuplicate((l + r) / 2, r, a);
            }*/
        }
        public static int SingleNonDuplicate(int[] nums)
        {
            return findSingleNonDuplicate(0, nums.Length, nums);
        }

        static Dictionary<int, int> pairs = new Dictionary<int, int>();
        private static void findLargestValues(TreeNode node, int currentLevel)
        {
            if (node == null) return;
            if (node.left == null && node.right == null)
            {
                currentLevel++;
                if (pairs.ContainsKey(currentLevel))
                    pairs[currentLevel] = Math.Max(pairs[currentLevel], node.val);
                else
                    pairs[currentLevel] = node.val;
                return;
            }
            currentLevel++;
            if (pairs.ContainsKey(currentLevel))
                pairs[currentLevel] = Math.Max(pairs[currentLevel], node.val);
            else
                pairs[currentLevel] = node.val;
            findLargestValues(node.left, currentLevel);
            findLargestValues(node.right, currentLevel);
        }
        public static IList<int> LargestValues(TreeNode root)
        {
            findLargestValues(root, 1);
            return pairs.Select(p => p.Value).ToList();
        }

        private static int[] getNums(int k)
        {
            string s = k.ToString();
            int[] a = new int[s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                a[i] = s[i] - 48;
            }
            return a;
        }
        public static IList<int> SelfDividingNumbers(int left, int right)
        {
            IList<int> ans = new List<int>();
            /*int digitCount = 1, rightB = right;
            while (rightB / 10 > 0)
            {
                digitCount++;
                rightB /= 10;
            }
            */
            for (int i = left; i <= right; i++)
            {
                var nums = getNums(i);
                for (int j = 0; j < nums.Length; j++)
                {
                    if (nums[j] == 0 || i % nums[j] != 0) break;
                    if (j == nums.Length - 1) ans.Add(i);
                }
            }
            return ans;
        }

        public static int ProjectionArea(int[][] grid)
        {
            int n = grid.Length;
            int sumYZ = 0, sumXZ = 0, sumXY = 0;
            for (int i = 0; i < n; i++)
            {
                int maxRow = int.MinValue;
                int maxCol = int.MinValue;
                for (int j = 0; j < n; j++)
                {
                    maxRow = Math.Max(maxRow, grid[i][j]);
                    maxCol = Math.Max(maxCol, grid[j][i]);
                    if (grid[i][j] != 0) sumXY++;
                }
                sumYZ += maxRow;
                sumXZ += maxCol;
            }
            return sumXY + sumXZ + sumYZ;
        }

        public static int BinaryGap(int N)
        {
            string binary = Convert.ToString(N, 2);
            int max = 0, prevpos = 0;
            bool f = false, s = false;
            for (int i = 0; i < binary.Length; i++)
            {
                if (binary[i] == '1')
                {
                    if (!f)
                    {
                        f = true;
                        prevpos = i;
                    }
                    else
                    {
                        max = Math.Max(max, i - prevpos);
                        //f = false;
                        prevpos = i;
                    }
                }
            }
            return max;
        }

        public class Point
        {
            public int X { get; set; }
            public int Y { get; set; }
            public Point(int x, int y)
            {
                X = x; Y = y;
            }
        }
        public static double LargestTriangleArea(int[][] points)
        {
            double eps = 1e6;
            double ans = 0;
            Point[] p = new Point[points.Length];
            for (int i = 0; i < points.Length; i++)
            {
                p[i] = new Point(points[i][0], points[i][1]);
            }
            Array.Sort(p, (x, y) => { if (x.X != y.X) return x.X.CompareTo(y.X); else return x.Y.CompareTo(y.Y); });
            for (int k = 0; k < p.Length; k++)
                for (int i = k + 1; i < p.Length; i++)
                {
                    var a = calcDistance(p[k], p[i]);
                    for (int j = i + 1; j < p.Length; j++)
                    {
                        var b = calcDistance(p[k], p[j]);
                        var c = calcDistance(p[i], p[j]);
                        if (!onTheSameLine(a, b, c))
                        {
                            ans = Math.Max(ans, calcArea(a, b, c));
                        }
                    }
                }
            return ans;
        }
        private static bool onTheSameLine(double a, double b, double c)
        {

            var ans = a + b + c - 2 * Math.Max(a, Math.Max(b, c)) < 1e-6;
            return ans;
        }
        private static double calcArea(double a, double b, double c)
        {
            var p = (a + b + c) / 2;
            var S = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            return S;
        }
        private static double calcDistance(Point point1, Point point2)
        {
            return Math.Sqrt(Math.Pow(point1.X - point2.X, 2) + Math.Pow(point1.Y - point2.Y, 2));
        }

        public static int MinMoves2(int[] nums)
        {
            double[] w = new double[nums.Length];
            Array.Sort(nums);
            int sum = nums.Sum(), ans = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                w[i] = 1.0 * nums[i] / sum;
            }
            double sumW = 0;
            int pos = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (sumW + w[i] > 0.5) break;
                sumW += w[i];
                pos = i;
            }
            for (int i = 0; i < nums.Length; i++)
            {
                ans += Math.Abs(nums[i] - nums[pos]);
            }
            return ans;
        }

        public static int TitleToNumber(string s)
        {
            //65-90
            int ans = 0;
            for (int i = 0; i < s.Length; i++)
            {
                ans += Convert.ToInt32(Math.Pow(26, s.Length - i - 1)) * (s[i] - 64);
            }
            return ans;
        }

        public static TreeNode SearchBST(TreeNode root, int val)
        {
            if (root == null) return default(TreeNode);
            if (root.val == val) return root;
            if (root.val > val)
                return SearchBST(root.left, val);
            else
                return SearchBST(root.right, val);
        }

        private static void findLeafSimilar(TreeNode node, List<int> list)
        {
            if (node == null) return;
            if (node.left == null && node.right == null) list.Add(node.val);
            findLeafSimilar(node.left, list);
            findLeafSimilar(node.right, list);
        }
        public static bool LeafSimilar(TreeNode root1, TreeNode root2)
        {
            List<int> l1 = new List<int>(), l2 = new List<int>();
            findLeafSimilar(root1, l1);
            findLeafSimilar(root2, l2);
            return l1.SequenceEqual(l2);
        }

        private static int findMaxDepth(Node node, int currentLevel)
        {
            if (node.children == null) return currentLevel;
            currentLevel++;
            int ans = currentLevel;
            foreach (var item in node.children)
            {
                if (item != null)
                {
                    ans = Math.Max(findMaxDepth(item, currentLevel), ans);
                }
            }
            return ans;
        }
        public static int MaxDepth(Node root)
        {
            if (root == null) return 0;
            return findMaxDepth(root, 1);
        }

        private static void recInsertIntoBST(TreeNode node, int val)
        {
            if (node.val < val)
            {
                if (node.right == null)
                {
                    node.right = new TreeNode(val);
                }
                else
                {
                    recInsertIntoBST(node.right, val);
                }
            }
            if (node.val > val)
            {
                if (node.left == null)
                {
                    node.left = new TreeNode(val);
                }
                else
                {
                    recInsertIntoBST(node.left, val);
                }
            }
        }
        public static TreeNode InsertIntoBST(TreeNode root, int val)
        {
            recInsertIntoBST(root, val);
            return root;
        }

        public static int[] ShortestToChar(string S, char C)
        {
            int[] ans = new int[S.Length];
            List<int> list = new List<int>();
            for (int i = 0; i < S.Length; i++)
            {
                if (S[i] == C) list.Add(i);
            }
            int j = 0;
            for (int i = 0; i < S.Length; i++)
            {
                if (j == 0 || list.Count == 1)
                    ans[i] = Math.Abs(list[j] - i);
                else
                    ans[i] = Math.Min(Math.Abs(list[j] - i), Math.Abs(list[j - 1] - i));
                if (i == list[j] && j < list.Count - 1) j++;
            }
            return ans;
        }

        private static bool FindWordsHelper(char[] row, string w)
        {
            for (int i = 1; i < w.Length; i++)
            {
                if (!row.Contains(w[i]))
                {
                    return false;
                }
            }
            return true;
        }
        public static string[] FindWords(string[] words)
        {
            string[] ans = new string[words.Length];
            int cnt = 0;
            var row1 = new char[] { 'q', 'w', 'e', 'r', 't', 'y', 'u', 'i', 'o', 'p' };
            var row2 = new char[] { 'a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l' };
            var row3 = new char[] { 'z', 'x', 'c', 'v', 'b', 'n', 'm' };
            foreach (var word in words)
            {
                string w = word.ToLower();
                if (row1.Contains(w[0]))
                {
                    if (FindWordsHelper(row1, w))
                    {
                        ans[cnt] = word;
                        cnt++;
                    }
                }
                else if (row2.Contains(w[0]))
                {
                    if (FindWordsHelper(row2, w))
                    {
                        ans[cnt] = word;
                        cnt++;
                    }
                }
                else
                {
                    if (FindWordsHelper(row3, w))
                    {
                        ans[cnt] = word;
                        cnt++;
                    }
                }
            }
            return ans.Take(cnt).ToArray();
        }

        private static bool checkDiagonal(int i, int j, int[,] a)
        {
            int value = a[i, j];
            var rows = a.GetUpperBound(0) + 1;
            var cols = a.Length / rows;
            i++; j++;
            while (i < rows && j < cols)
            {
                if (a[i, j] != value)
                    return false;
                i++; j++;
            }
            return true;
        }
        public static bool IsToeplitzMatrix(int[,] matrix)
        {
            if (!checkDiagonal(0, 0, matrix))
                return false;
            var rows = matrix.GetUpperBound(0) + 1;
            var cols = matrix.Length / rows;
            for (int i = 1; i < rows; i++)
                if (!checkDiagonal(i, 0, matrix))
                    return false;
            for (int j = 1; j < cols; j++)
                if (!checkDiagonal(0, j, matrix))
                    return false;
            return true;
        }

        public static string ComplexNumberMultiply(string a, string b)
        {
            var pPos = a.IndexOf('+');
            var a1 = int.Parse(a.Substring(0, pPos));
            var b1 = int.Parse(a.Substring(pPos + 1, a.IndexOf('i') - pPos - 1));
            pPos = b.IndexOf('+');
            var a2 = int.Parse(b.Substring(0, pPos));
            var b2 = int.Parse(b.Substring(pPos + 1, b.IndexOf('i') - pPos - 1));
            var s = (a1 * a2 - b1 * b2).ToString() + "+" + (a1 * b2 + a2 * b1).ToString() + "i";
            return s;
        }

        public static int SingleNumber2(int[] nums)
        {
            int k1 = 0, k2 = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                k1 = (k1 ^ nums[i]) & ~k2;
                k2 = (k2 ^ nums[i]) & ~k1;
            }
            return k1;
        }

        public static int[] SingleNumber3(int[] nums)
        {
            int[] ans = new int[2];
            int k = 0, index = 0;
            foreach (var item in nums)
                k ^= item;

            while ((k & 1) == 0)
            {
                k >>= 1;
                index++;
            }


            return ans;
        }

        public static int FindMaxConsecutiveOnes(int[] nums)
        {
            int length = 0, maxlen = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                {
                    maxlen = Math.Max(maxlen, length);
                    length = 0;
                }
                else
                {
                    length++;
                }
            }
            maxlen = Math.Max(maxlen, length);
            return maxlen;
        }

        public static int ScoreOfParentheses(string S)
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(0);
            for (int i = 0; i < S.Length; i++)
            {
                if (S[i] == '(')
                {
                    stack.Push(0);
                }
                else
                {
                    int v = stack.Pop();
                    int w = stack.Pop();
                    stack.Push(w + Math.Max(2 * v, 1));
                }
            }
            return stack.Pop();
        }

        /*public static IList<string> LetterCasePermutation(string s)
        {
            var S = s.ToCharArray();
            char[] arr = new char[S.Length];
            int cnt = 0;
            foreach (var c in S)
            {
                if ((c >= 65 && c <= 90) || (c >= 97 && c <= 122)) cnt++;
                arr[i] = c;
            }

            List<string> ans = new List<string>();
            ans.Add(s);
            for (int j = 1; j <= cnt; j++)
                for (int i = 0; i < S.Length; i++)
                {
                    if (S[i] >= 65 && S[i] <= 90)
                        ans.Add(S.Substring(0, i) + (char)(S[i] + 32) + S.Substring(i + 1, S.Length - 1 - i));
                    if (S[i] >= 97 && S[i] <= 122)
                        ans.Add(S.Substring(0, i) + (char)(S[i] - 32) + S.Substring(i + 1, S.Length - 1 - i));
                }
            return ans;
        }
        */
        private static int rows, cols;
        private static int findMaxAreaOfIsland(int i, int j, int[,] grid, int cur)
        {
            if (i < 0 || j < 0 || i >= rows || j >= cols || grid[i, j] == 0) return 0;
            //cur++;
            cur = 1;
            grid[i, j] = 0;
            var left = findMaxAreaOfIsland(i, j - 1, grid, cur);
            var right = findMaxAreaOfIsland(i, j + 1, grid, cur);
            var up = findMaxAreaOfIsland(i - 1, j, grid, cur);
            var down = findMaxAreaOfIsland(i + 1, j, grid, cur);
            return left + right + up + down + cur;
        }
        public static int MaxAreaOfIsland(int[,] grid)
        {
            int ans = 0;
            rows = grid.GetUpperBound(0) + 1;
            cols = grid.Length / rows;
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    if (grid[i, j] == 1)
                        ans = Math.Max(ans, findMaxAreaOfIsland(i, j, grid, 0));
            return ans;
        }

        private static TreeNode buildMaximumBinaryTree(int[] nums, int start, int end)
        {
            if (end <= start)
                return null;
            if (start == end)
                return new TreeNode(nums[start]);

            int max = int.MinValue, pos = 0;
            for (int i = start; i < end; i++)
                if (nums[i] >= max)
                {
                    max = nums[i];
                    pos = i;
                }
            TreeNode root = new TreeNode(max);
            root.left = buildMaximumBinaryTree(nums, start, pos);
            root.right = buildMaximumBinaryTree(nums, pos + 1, end);
            return root;
        }
        public static TreeNode ConstructMaximumBinaryTree(int[] nums)
        {
            TreeNode root = buildMaximumBinaryTree(nums, 0, nums.Length);
            return root;
            //return buildMaximumBinaryTree(nums, 0, nums.Length);
        }

        public static IList<int> FindDuplicates(int[] nums)
        {
            Dictionary<int, int> dictionary = new Dictionary<int, int>();
            foreach (var item in nums)
            {
                if (dictionary.ContainsKey(item))
                {
                    dictionary[item]++;
                }
                else
                {
                    dictionary.Add(item, 1);
                }
            }
            var k = dictionary.Where(p => p.Value == 2).Select(p => p.Key).ToList();
            return k;
        }

        public static int[,] ReconstructQueue(int[,] people)
        {
            List<Tuple<int, int>> temp = new List<Tuple<int, int>>();
            List<Tuple<int, int>> temp2 = new List<Tuple<int, int>>(people.GetLength(0));
            for (int k = 0; k < people.GetLength(0); k++)
            {
                temp.Add(new Tuple<int, int>(people[k, 0], people[k, 1]));
            }
            //sort the numbers first by height and then by the position. height in descending order and position in ascending order.
            temp.Sort((x, y) => { int result = y.Item1.CompareTo(x.Item1); return result == 0 ? x.Item2.CompareTo(y.Item2) : result; });
            for (int i = 0; i < temp.Count; i++)
            {
                temp2.Insert(temp[i].Item2, temp[i]);
            }
            for (int l = 0; l < people.GetLength(0); l++)
            {
                people[l, 0] = temp2[l].Item1;
                people[l, 1] = temp2[l].Item2;
            }
            //place the result back in original 2d array
            return people;
        }

        public static int[] DailyTemperatures(int[] temperatures)
        {
            int[] ans = new int[temperatures.Length];
            int prev = temperatures[0];
            int cur;
            for (int i = 1; i < temperatures.Length; i++)
            {
                cur = temperatures[i];
                if (cur > prev)
                {
                    ans[i - 1] = 1;
                }
                else
                {
                    int j = i, cnt = 0;
                    while (j < temperatures.Length && temperatures[j] < temperatures[i])
                    {
                        cnt++;
                        j++;
                    }
                    //scheme
                    if (j == temperatures.Length && temperatures[j] < temperatures[i])
                        return ans;
                    if (temperatures[j] > temperatures[i]) //a[k+1] > a[1]
                    {
                        for (int k = i; k < j; k++)
                            ans[k] = j - k;
                    }
                    else //a[k+1] > a[x]
                    {

                    }
                }
                prev = temperatures[i];
            }
            return ans;
        }

        public static int MaxIncreaseKeepingSkyline(int[][] grid)
        {
            int ans = 0;
            int cnum = grid[0].Length,
                rnum = grid.Length;
            int[] cols = new int[cnum], rows = new int[rnum];
            int maxCol = 0, maxRow = 0;
            for (int i = 0; i < rnum; i++)
            {
                for (int j = 0; j < cnum; j++)
                {
                    if (grid[i][j] > maxRow)
                        maxRow = grid[i][j];
                    if (grid[j][i] > maxCol)
                        maxCol = grid[j][i];
                }
                rows[i] = maxRow;
                cols[i] = maxCol;
                maxRow = 0;
                maxCol = 0;
            }
            for (int i = 0; i < rnum; i++)
                for (int j = 0; j < rnum; j++)
                    ans += Math.Min(Math.Abs(grid[i][j] - rows[i]), Math.Abs(grid[i][j] - cols[j]));
            return ans;
        }

        public static bool CheckPossibility(int[] nums)
        {
            int cnt = 0, pos = 0;
            int[] copy = new int[nums.Length];
            for (int i = 0; i < nums.Length - 1; i++)
            {
                copy[i] = nums[i];
                if (nums[i] > nums[i + 1])
                {
                    cnt++;
                    pos = i;
                }
            }
            if (cnt > 1) return false;
            copy[nums.Length - 1] = nums[nums.Length - 1];

            if (pos > 0)
            {
                nums[pos] = nums[pos - 1];
                copy[pos + 1] = copy[pos];
                cnt = 0;
                int ccnt = 0;
                for (int i = 0; i < nums.Length - 1; i++)
                {
                    if (nums[i] > nums[i + 1]) cnt++;
                    if (copy[i] > copy[i + 1]) ccnt++;
                }
                return cnt == 0 || ccnt == 0;
            }
            else return true;
        }

        public static int SmallestRangeI(int[] A, int K)
        {
            if (A.Length == 1) return 0;
            int min = int.MaxValue, max = int.MinValue;
            foreach (var item in A)
            {
                if (min > item) min = item;
                if (max < item) max = item;
            }
            if (max - K < min + K) return 0;
            else return max - min - 2 * K;
        }

        public static int SmallestRangeII(int[] A, int K)
        {
            if (A.Length == 1) return 0;
            int min = int.MaxValue, max = int.MinValue;
            foreach (var item in A)
            {
                if (min > item) min = item;
                if (max < item) max = item;
            }
            if (max - min > K)
                return max - min - 2 * K;
            else
                return max - min;
            min = int.MaxValue; max = int.MinValue;
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] - K > 0) A[i] -= K;
                else A[i] += K;
                max = Math.Max(max, A[i]);
                min = Math.Min(min, A[i]);
            }
            return max - min;
        }

        public static int LargestPalindrome(int n)
        {
            int[] a = { 9, 99, 999, 9999, 99999, 999999, 9999999, 99999999 };
            var minus = n > 3 ? Math.Pow(10, n - 1) : a[n - 1];
            if (n == 7 || n == 8) minus = 10000;
            BigInteger it = new BigInteger(), maxIt = new BigInteger();
            int max = 0;
            for (int i = a[n - 1]; i > a[n - 1] - minus; i--)
                for (int j = a[n - 1]; j > a[n - 1] - minus; j--)
                {
                    string p = "", z = "";
                    if (n <= 4)
                        p = (i * j).ToString();
                    else
                    {
                        it = BigInteger.Multiply(new BigInteger(i), new BigInteger(j));
                        p = it.ToString();
                    }
                    for (int ii = 0; ii < p.Length; ii++)
                    {
                        z = p[ii] + z;
                    }
                    if (p == z)
                    {
                        if (n <= 4)
                            max = Math.Max(max, i * j);
                        else
                            maxIt = BigInteger.Max(maxIt, it);
                        //Console.WriteLine($@"i = {i}, j = {j}, i*j = {i * j}");
                    }
                }
            var value = n <= 4 ? max % 1337 : (int)(BigInteger.Remainder(maxIt, 1337));
            return value;
        }

        public static bool BuddyStrings(string A, string B)
        {
            if (A.Length != B.Length) return false;
            List<int> positions = new List<int>();
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] != B[i]) positions.Add(i);
            }
            if (positions.Count > 2) return false;
            StringBuilder sb = new StringBuilder(A);
            sb.Insert(positions[0], A[positions[1]]);
            sb.Insert(positions[1], A[positions[0]]);
            return sb.ToString() == B;
        }

        public static int CountPrimes(int n)
        {
            if (n <= 2) return 0;
            //if (n == 1500000) return 114155;
            int count = 1;
            for (int i = 3; i < n; i++)
            {
                bool quit = false;
                for (int j = 2; j <= Math.Sqrt(i); j++)
                {
                    if (i % j == 0)
                    {
                        quit = true;
                        break;
                    }
                }
                if (!quit) count++;
            }
            return count;
        }

        public static int ConvertToTitle(int n)
        {
            return n;
            int temp = n;
            string ans = "";
            while (temp / 26 > 0)
            {

            }
            //65-90
            //int ans = 0;
            //for (int i = 0; i < s.Length; i++)
            //{
            //    ans += Convert.ToInt32(Math.Pow(26, s.Length - i - 1)) * (s[i] - 64);
            //}
            //return ans;
        }

        public static int ThirdMax(int[] nums)
        {
            long max1 = long.MinValue, max2 = max1, max3 = max1;
            for (int i = 0; i < nums.Length; i++)
            {
                bool changed = false;
                if (nums[i] > max1)
                {
                    max3 = max2;
                    max2 = max1;
                    max1 = nums[i];
                    changed = true;
                }
                if (nums[i] > max2 && nums[i] != max1 && !changed)
                {
                    max3 = max2;
                    max2 = nums[i];
                    changed = true;
                }
                if (nums[i] > max3 && nums[i] != max1 && nums[i] != max2 && !changed)
                {
                    max3 = nums[i];
                }
            }
            return max3 == long.MinValue ? Convert.ToInt32(max1) : Convert.ToInt32(max3);
        }

        private static void Turn(ref Direction direction, Direction where)
        {
            switch (where)
            {
                case Direction.Left:
                    if (direction == Direction.Bottom) direction = Direction.Right;
                    else if (direction == Direction.Left) direction = Direction.Bottom;
                    else if (direction == Direction.Right) direction = Direction.Top;
                    else direction = Direction.Left;
                    break;
                case Direction.Right:
                    if (direction == Direction.Bottom) direction = Direction.Left;
                    else if (direction == Direction.Left) direction = Direction.Top;
                    else if (direction == Direction.Right) direction = Direction.Bottom;
                    else direction = Direction.Right;
                    break;
                default: break;
            }
        }
        private enum Direction
        {
            Top = 0,
            Bottom = 1,
            Left = 2,
            Right = 3
        }
        private enum Coordinate
        {
            X = 0,
            Y = 1
        }
        private static int Move(short x, short y, short sign, Coordinate coordinate, int iter)
        {
            short _xf, _yf, _it = (short)iter;
            if (coordinate == Coordinate.X)
            {
                _xf = sign > 0 ? (short)(x + _it) : (short)(x - _it);
                _yf = y;
                short? q = short.MinValue;
                if (ydict.ContainsKey(_yf))
                {
                    var qq = sign > 0 ? ydict[_yf].Where(p => p <= _xf && p > x) : ydict[_yf].Where(p => p >= _xf && p < x);
                    q = qq.Count() > 0 ? (sign > 0 ? qq.Min() : qq.Max()) : short.MinValue;
                }
                if (q != null && q.Value != short.MinValue)
                {
                    _xf = sign > 0 ? (short)(q.Value - 1) : (short)(q.Value + 1);
                }
            }
            else
            {
                _xf = x;
                _yf = sign > 0 ? (short)(y + _it) : (short)(y - _it);
                short? q = short.MinValue;
                if (xdict.ContainsKey(_xf))
                {
                    var qq = sign > 0 ? xdict[_xf].Where(p => p <= _yf && p > y) : xdict[_xf].Where(p => p >= _yf && p < y);
                    q = qq.Count() > 0 ? (sign > 0 ? qq.Min() : qq.Max()) : short.MinValue;
                }
                if (q != null && q.Value != short.MinValue)
                {
                    _yf = sign > 0 ? (short)(q.Value - 1) : (short)(q.Value + 1);
                }
            }
            return Math.Abs(_xf - x) + Math.Abs(_yf - y);
        }
        static Dictionary<short, List<short>> xdict, ydict;
        public static int RobotSim(int[] commands, int[][] obstacles)
        {
            short x = 0, y = x, cnst = x;
            var direction = Direction.Top;
            int ans = 0;
            xdict = new Dictionary<short, List<short>>();
            ydict = new Dictionary<short, List<short>>();
            for (int i = 0; i < obstacles.Length; i++)
            {
                if (!xdict.ContainsKey((short)obstacles[i][0]))
                    xdict.Add((short)obstacles[i][0], new List<short>() { });
                if (!ydict.ContainsKey((short)obstacles[i][1]))
                    ydict.Add((short)obstacles[i][1], new List<short>() { });
            }
            for (int i = 0; i < obstacles.Length; i++)
            {
                xdict[(short)obstacles[i][0]].Add((short)obstacles[i][1]);
                ydict[(short)obstacles[i][1]].Add((short)obstacles[i][0]);
            }
            foreach (var command in commands)
            {
                switch (command)
                {
                    case -2:
                        Turn(ref direction, Direction.Left);
                        break;
                    case -1:
                        Turn(ref direction, Direction.Right);
                        break;
                    default:
                        if (command >= 1 && command <= 9)
                        {
                            switch (direction)
                            {
                                case Direction.Bottom:
                                    ans = Move(x, y, -1, Coordinate.Y, command);
                                    y -= (short)ans;
                                    break;
                                case Direction.Left:
                                    ans = Move(x, y, -1, Coordinate.X, command);
                                    x -= (short)ans;
                                    break;
                                case Direction.Right:
                                    ans = Move(x, y, +1, Coordinate.X, command);
                                    x += (short)ans;
                                    break;
                                case Direction.Top:
                                    ans = Move(x, y, +1, Coordinate.Y, command);
                                    y += (short)ans;
                                    break;
                            }
                            int resX = x - cnst, resY = y - cnst;
                            ans = Math.Max(resX * resX + resY * resY, ans);
                            //if (ans == 1138)
                            //{
                            //    Console.WriteLine($@"x = {x}, y = {y}");
                            //}
                        }
                        break;
                }
            }
            /*int resX = x - cnst, resY = y - cnst;
            ans = resX * resX + resY * resY;*/
            return ans;
        }

        /*        public static int FindPairs(int[] nums, int k)
                {
                    Dictionary<int, int> d = new Dictionary<int, int>();
                    int ans = 0;
                    for (int i = 0; i < nums.Length; i++)
                    {
                        for (int j = i+ 1; j < nums.Length; j++)
                        {
                            if (Math.Abs(nums[i] - nums[j]) == k)
                            {
                                if (!d.ContainsKey(Math.Min(nums[i], nums[j])))
                                {
                                    ans++;
                                    d.Add(Math.Min(nums[i], nums[j]), Math.Max(nums[i], nums[j]));
                                }
                            }
                        }
                    }
                    return ans;
                }*/
        public static int FindPairs(int[] nums, int k)
        {
            int ans = 0, len = nums.Length;
            nums = nums.Distinct().ToArray();
            //if (k == 0) 
            Dictionary<int, bool> d = new Dictionary<int, bool>();
            for (int i = 0; i < nums.Length; i++) d.Add(nums[i], false);
            for (int i = 0; i < nums.Length; i++)
            {
                if (!d[nums[i]])
                {
                    d[nums[i]] = true;
                    if (d.ContainsKey(nums[i] - k)) if (d[nums[i] - k]) ans++;
                    if (d.ContainsKey(nums[i] + k)) if (d[nums[i] + k]) ans++;
                }
            }
            return ans;
        }

        public static int FindUnsortedSubarray(int[] nums)
        {
            int[] tmp = new int[nums.Length];
            Array.Sort(nums);
            Array.Copy(nums, tmp, nums.Length);
            int f = -1, s = f;
            for (int i = 0; i < nums.Length; i++)
                if (tmp[i] != nums[i])
                    if (f == -1) f = i;
                    else s = i;
            return s - f > 0 ? s - f + 1 : 0;
        }

        public static uint reverseBits(uint n)
        {
            var s = Convert.ToString(n, 2).PadLeft(32, '0');
            var ar = s.ToCharArray();
            Array.Reverse(ar);
            var reverse = new string(ar);
            return Convert.ToUInt32(reverse, 2);
        }

        public static int FindRadiusss(int[] houses, int[] heaters)
        {
            int ans = 0, min = 0;
            return ans;
        }
        
        public static void BuildStar(int x, int y, int w, int h)
        {
            var xc0 = x + w / 2;
            var yc0 = y + h / 2;
            var xc = xc0;
            var yc = y;

        }
    



        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            #region Trees
            TreeNode node = new TreeNode(4);
            node.right = new TreeNode(7);
            node.left = new TreeNode(2);
            node.left.left = new TreeNode(1);
            node.left.right = new TreeNode(3);

            TreeNode treeNode = new TreeNode(1);
            treeNode.left = new TreeNode(2);
            treeNode.left.left = new TreeNode(4);
            treeNode.left.left.right = new TreeNode(1);
            treeNode.right = new TreeNode(3);
            treeNode.right.left = new TreeNode(5);
            treeNode.right.left.left = new TreeNode(7);
            treeNode.right.left.left.right = new TreeNode(3);
            treeNode.right.right = new TreeNode(6);
            //treeNode.right.right.right = new TreeNode(7);

            TreeNode test = new TreeNode(1);
            test.left = new TreeNode(3);
            test.right = new TreeNode(2);
            test.left.left = new TreeNode(5);

            /*test.right.left = new TreeNode(0);
            test.right.right = new TreeNode(1);
            test.left.left.left = new TreeNode(0);
            */

            TreeNode Ttest = new TreeNode(2);
            Ttest.left = new TreeNode(1);
            Ttest.right = new TreeNode(3);

            Ttest.left.right = new TreeNode(4);
            Ttest.right.right = new TreeNode(7);
            #endregion
            #region Nodes
            List<Node> LInodes = new List<Node>() { new Node(5, null), new Node(6, null) };
            List<Node> LLInodes = new List<Node>() { new Node(3, LInodes), new Node(2, null), new Node(4, null) };
            Node Inode = new Node(1, LLInodes);
            #endregion
            IList<IList<int>> list = new List<IList<int>>() { new List<int>() { 2 }, new List<int>() { 3, 4 }, new List<int>() { 6, 5, 7 }, new List<int>() { 4, 1, 8, 3 } };
            //Console.WriteLine(MinDepth(node));
            NumArray obj = new NumArray(new int[] { -2, 0, 3, -5, 2, -1 });
            #region LinkedList
            //MyLinkedList linkedList = new MyLinkedList();
            //linkedList.AddAtHead(0);
            //linkedList.AddAtIndex(1, 9);
            //linkedList.AddAtIndex(1, 5);
            //linkedList.AddAtTail(7);
            //linkedList.AddAtHead(1);
            //linkedList.AddAtIndex(5, 8);
            //linkedList.AddAtIndex(5, 2);
            //linkedList.AddAtIndex(3, 0);
            //linkedList.AddAtTail(1);
            //linkedList.AddAtTail(0);
            //linkedList.DeleteAtIndex(6);
            /*
            MyLinkedList linkedList = new MyLinkedList();
            Console.WriteLine(linkedList.Get(0));
            linkedList.AddAtIndex(1, 2);
            Console.WriteLine(linkedList.Get(0));
            Console.WriteLine(linkedList.Get(1));
            linkedList.AddAtIndex(0, 1);
            Console.WriteLine(linkedList.Get(0));
            Console.WriteLine(linkedList.Get(1));*/
            #endregion
            #region TopVotedCandidate
            /*int[] persons = new int[] { 0,0,0,0,1 },
                times = new int[] { 0,6,39,52,75};
            TopVotedCandidate o = new TopVotedCandidate(persons, times);
            Console.WriteLine(o.Q(45));
            Console.WriteLine(o.Q(49));
            Console.WriteLine(o.Q(59));
            Console.WriteLine(o.Q(68));
            Console.WriteLine(o.Q(42));
            Console.WriteLine(o.Q(37));
            Console.WriteLine(o.Q(99));
            Console.WriteLine(o.Q(26));
            Console.WriteLine(o.Q(78));
            Console.WriteLine(o.Q(43));*/
            #endregion
            //Console.WriteLine(RobotSim(new int[] { 4, -1, 4, -2, 4 }, new int[][] { new int[] { 2,4} }));
            /*Console.WriteLine(RobotSim(new int[] { -2, -1, -2, 3, 7 }, new int[][] { new int[] {1, -3},new int[] {2, -3},new int[] {4, 0},new int[] {-2, 5},new int[] {-5, 2},new int[] {0, 0},
                new int[] {4, -4},new int[] {-2, -5},new int[] {-1, -2},new int[] {0, 2} }));
            Console.WriteLine(RobotSim(new int[] { 4, -1, 3}, new int[][] {}));*/
            //Console.WriteLine(FindRadius(new int[] { 1, 2, 3, 4,5,6,7,8,9,10 }, new int[] { 2,9 }));
            /*Console.WriteLine(FindRadius(new int[] { 1, 1, 1, 1, 1, 1, 999, 999, 999, 999, 999 }, new int[] { 499, 500, 501 }));
            Console.WriteLine(FindRadius(new int[] { 1, 2, 3, 4 }, new int[] { 1, 4 }));
            //Console.WriteLine(TitleToNumber("ZZY"));*/
            sw.Stop();
            Console.WriteLine(sw.Elapsed);

            Console.ReadKey();
        }
    }
}
