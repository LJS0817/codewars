//https://www.codewars.com/kata/587731fda577b3d1b0001196
/*
Write a method (or function, depending on the language) that converts a string to camelCase, that is, all words must have their first letter capitalized and spaces must be removed.

Examples (input --> output):
"hello case" --> "HelloCase"
"camel case word" --> "CamelCaseWord"
Don't forget to rate this kata! Thanks :)
*/
namespace Kata
{
  public static class Problem
  {
    public static string CamelCase(this string str)  
    {  
      string[] s = str.Split(' ');
      string rst = "";
      for(int i = 0; i < s.Length; i++) {
        if(s[i].Length == 0) continue;
        rst += s[i][0].ToString().ToUpper() + s[i][1..];
      }
      return rst;
    }
  }
}

