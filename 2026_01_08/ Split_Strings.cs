//https://www.codewars.com/kata/515de9ae9dcfc28eb6000001
/*
Complete the solution so that it splits the string into pairs of two characters. If the string contains an odd number of characters then it should replace the missing second character of the final pair with an underscore ('_').

Examples:

* 'abc' =>  ['ab', 'c_']
* 'abcdef' => ['ab', 'cd', 'ef']
*/
import System;

public class SplitString
{
  public static string[] Solution(string str) {
    string[] rst = new string[(int)Math.Ceiling(str.Length / 2.0D)];
    for(int i = 0; i < str.Length; i += 2) {
      rst[(int)(i / 2)] = str[i].ToString() + (i + 1 >= str.Length ? "_" : str[i + 1]);
    }
    return rst;
  }
}