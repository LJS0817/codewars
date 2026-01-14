//https://www.codewars.com/kata/5324945e2ece5e1f32000370
/*
Given the string representations of two integers, return the string representation of the sum of those integers.

For example:

sumStrings('1','2') // => '3'
A string representation of an integer will contain no characters besides the ten numerals "0" to "9".

I have removed the use of BigInteger and BigDecimal in java

Python: your solution need to work with huge numbers (about a milion digits), converting to int will not work.
*/
using System;
using System.Numerics;
public static class Kata
{
    public static string sumStrings(string a, string b)
    {
      a = a.Length < 1 ? "0" : a;
      b = b.Length < 1 ? "0" : b;
      if(BigInteger.TryParse(a, out BigInteger nA) && BigInteger.TryParse(b, out BigInteger nB)) return (nA + nB).ToString();
      else return "";
    }
}