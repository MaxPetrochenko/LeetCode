using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Solved
{
    internal class IsValidSudokuClass
    {
        public bool IsValidSudoku(char[][] board)
        {
            var qqq = new char[9, 9];

            int[][] a = new int[9][];
            int q = 0;
            for(int i = 0; i < 9; i++)
            {
                a[i] = new int[9];
                for(int j = 0; j < 9; j++)
                {
                    a[i][j] = board[i][j] != '.' ? board[i][j] - '0' : --q;
                }
            }

            for(int i = 0; i < 9; i++)
                for(int j = 0; j < 9; j++)
                    for(int k = j + 1; k < 9; k++)
                    {
                        if(a[i][j] == a[i][k]) return false;
                        if(a[j][i] == a[k][i]) return false;
                    }

            for(int i = 0; i < 3; i++)
                for(int j = 0; j < 3; j++)
                    for(int l = 0; l < 3; l++)
                        for(int r = 0; r < 3; r++)
                        {
                            if(l == i && j == r) continue;
                            if(a[i][j] == a[l][r]) return false;
                            if(a[i][j + 3] == a[l][r + 3]) return false;
                            if(a[i][j + 6] == a[l][r + 6]) return false;
                            if(a[i + 3][j] == a[l + 3][r]) return false;
                            if(a[i + 3][j + 3] == a[l + 3][r + 3]) return false;
                            if(a[i + 3][j + 6] == a[l + 3][r + 6]) return false;
                            if(a[i + 6][j] == a[l + 6][r]) return false;
                            if(a[i + 6][j + 3] == a[l + 6][r + 3]) return false;
                            if(a[i + 6][j + 6] == a[l + 6][r + 6]) return false;
                        }


            return true;
        }
    }
}
