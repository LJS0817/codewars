//https://www.codewars.com/kata/53697be005f803751e0015aa
/*
Step 1: Create a function called encode() to replace all the lowercase vowels in a given string with numbers according to the following pattern:

a -> 1
e -> 2
i -> 3
o -> 4
u -> 5
For example, encode("hello") would return "h2ll4". There is no need to worry about uppercase vowels in this kata.

Step 2: Now create a function called decode() to turn the numbers back into vowels according to the same pattern shown above.

For example, decode("h3 th2r2") would return "hi there".

For the sake of simplicity, you can assume that any numbers passed into the function will correspond to vowels.
*/
public static class VowelCode
{
  public static string Encode(string msg)
  {
    return msg.Replace('a', '1').Replace('e', '2').Replace('i', '3').Replace('o', '4').Replace('u', '5');
  }
  
  public static string Decode(string msg)
  {
    return msg.Replace('1', 'a').Replace('2', 'e').Replace('3', 'i').Replace('4', 'o').Replace('5', 'u');
  }
}
