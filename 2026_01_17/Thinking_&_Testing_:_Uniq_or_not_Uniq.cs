//https://www.codewars.com/kata/56d949281b5fdc7666000004
/*
No Story

No Description

Only by Thinking and Testing

Look at result of testcase, guess the code!
*/
using System;
using System.Linq;
using System.Collections.Generic;

namespace myjinxin
{
    public class Kata
    {
      public int[] RemoveDup(int[] arr) {
        HashSet<int> rst = new HashSet<int>();
        for(int i = 0; i < arr.Length; i++) {
          rst.Add(arr[i]);
        }
        return rst.ToArray();
      }
      public int[] Testit(int[] a, int[] b){
        int[] rst = RemoveDup(a).Concat(RemoveDup(b)).ToArray();
        Array.Sort(rst);
        return rst;
      }
    }
}