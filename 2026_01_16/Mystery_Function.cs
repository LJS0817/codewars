//https://www.codewars.com/kata/56b2abae51646a143400001d
/*
The mystery function is defined over the non-negative integers. The more common name of this function is concealed in order to not tempt you to search the Web for help in solving this kata, which most definitely would be a very dishonorable thing to do.

Assume n has m bits. Then mystery(n) is the number whose binary representation is the entry in the table T(m) at index position n, where T(m) is defined recursively as follows:

T(1) = [0, 1]
T(m + 1) is obtained by taking two copies of T(m), reversing the second copy, prepending each entry of the first copy with 0 and each entry of the reversed copy with 1, and then concatenating the two. For example:

T(2) = [ 00, 01, 11, 10 ]
and

T(3) = [ 000, 001, 011, 010, 110, 111, 101, 100 ]
mystery(6) is the entry in T(3) at index position 6 (with indexing starting at 0), i.e., 101 interpreted as a binary number. So, mystery(6) returns 5.

Your mission is to implement the function mystery, where the argument may have up to 63 bits. Note that T(63) is far too large to compute and store, so you'll have to find an alternative way of implementing mystery.

You are also asked to implement mystery_inv ( or mysteryInv ), the inverse of mystery. Finally, you are asked to implement a function name_of_mystery ( or nameOfMystery ), which shall return the name that mystery is more commonly known as. After passing all tests you are free to learn more about this function on Wikipedia or another place.

Hint: If you don't know the name of mystery, remember there is information in passing as well as failing a test.
*/
using System;
public class MysteryFunction
{
   public static long Mystery(long n)
   {
     long cnt = (long)Math.Log2(n) + 1L;
     long sq = (long)Math.Pow(2, cnt);
     string bi = "";
     bool reverseTrig = false;
     for(int i = 0; i < cnt; i++) {
       long half = sq / 2;
       bi = ((n < half) ? (reverseTrig ? "1" : "0") : (reverseTrig ? "0" : "1")) + bi;
       sq -= half;
       if(n >= half) n -= half;
       if(bi[0] == '1') reverseTrig = !reverseTrig; 
     }
     long rst = 0;
     for(int i = 0; i < cnt; i++) {
       rst += (long)(Math.Pow(2, i) * int.Parse(bi[i]+""));
     }
     return rst;
   }

   public static long MysteryInv(long n)
   {
     long cnt = (long)Math.Log2(n) + 1L;;
     long sq = (long)Math.Pow(2, cnt);
     string bi = "";
     bool reverseTrig = false;
     for(int i = 0; i < cnt; i++) {
       bi = bi + (n / Math.Pow(2, cnt - 1 - i) >= 1 ? "1" : "0");
       if(bi[bi.Length - 1] == '1') n -= (long)Math.Pow(2, cnt - 1 - i);
     }
     long rst = 0;
     for(int i = 0; i < cnt; i++) {
       if(bi[i] == '1') reverseTrig = !reverseTrig; 
       long half = sq / 2;
       rst += (reverseTrig ? half : 0);
       sq -= half;
     }
     return rst;
   }

   public static string NameOfMystery()
   {
     return "gray code";
   }
}