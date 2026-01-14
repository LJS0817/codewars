//https://www.codewars.com/kata/58ad317d1541651a740000c5
/*
Task
You are given a string s. Every letter in s appears once.

Consider all strings formed by rearranging the letters in s. After ordering these strings in dictionary order, return the middle term. (If the sequence has a even length n, define its middle term to be the (n/2)th term.)

Example
For s = "abc", the result should be "bac".

 The permutations in order are: "abc", "acb", "bac", "bca", "cab", "cba" So, The middle term is "bac".

Input/Output
[input] string s
unique letters (2 <= length <= 26)

[output] a string
middle permutation.
*/
using System.Collections.Generic;
using System.Numerics;
using System.Linq;
using System;

namespace myjinxin
{
  public class Kata
  {
    public string MiddlePermutation(string s){
      int len = s.Length;
      BigInteger max = 1;
      
      for(BigInteger i = 1; i < len; i++) max *= i;
      
      List<char> ch = s.ToList();
      ch.Sort();
      string rst = "";
      int pos = (len - 1) / 2;
      BigInteger curDiv = (max*(BigInteger)len) / 2;
      
      while(ch.Count > 0) {
        rst += ch[pos].ToString();
        ch.RemoveAt(pos);
        
        if(ch.Count == 0) break;
        pos = curDiv == 0 || (curDiv % max) == 0 ? ch.Count - 1 : (int)(curDiv / max) - 1;
        curDiv %= max;
        max /= ch.Count;
      }
      return rst;
    }
  }
}