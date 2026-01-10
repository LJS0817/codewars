//https://www.codewars.com/kata/52bc74d4ac05d0945d00054e
/*
Write a function named first_non_repeating_letter† that takes a string input, and returns the first character that is not repeated anywhere in the string.

For example, if given the input 'stress', the function should return 't', since the letter t only occurs once in the string, and occurs first in the string.

As an added challenge, upper- and lowercase letters are considered the same character, but the function should return the correct case for the initial letter. For example, the input 'sTreSS' should return 'T'.

If a string contains all repeating characters, it should return an empty string ("");

† Note: the function is called firstNonRepeatingLetter for historical reasons, but your function should handle any Unicode character.
*/
public class Kata
{
  public static string FirstNonRepeatingLetter(string s)
  {
    if(s.Length == 0) return "";
    string tmp = s.ToLower();
    for(int i = 0; i < s.Length; i++)  {
      if(tmp.LastIndexOf(tmp[i]) == tmp.IndexOf(tmp[i])) return s.Substring(i, 1);
    }
    return "";
  }
}