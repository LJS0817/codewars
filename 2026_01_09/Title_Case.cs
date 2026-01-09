//https://www.codewars.com/kata/5202ef17a402dd033c000009
/*
A string is considered to be in title case if each word in the string is either (a) capitalised (that is, only the first letter of the word is in upper case) or (b) considered to be an exception and put entirely into lower case unless it is the first word, which is always capitalised.

Write a function that will convert a string into title case, given an optional list of exceptions (minor words). The list of minor words will be given as a string with each word separated by a space. Your function should ignore the case of the minor words string -- it should behave in the same way even if the case of the minor word string is changed.

Arguments (Haskell)
First argument: space-delimited list of minor words that must always be lowercase except for the first word in the string.
Second argument: the original string to be converted.
Arguments (Other languages)
First argument (required): the original string to be converted.
Second argument (optional): space-delimited list of minor words that must always be lowercase except for the first word in the string. The JavaScript/CoffeeScript tests will pass undefined when this argument is unused.
Example
Kata.TitleCase("a clash of KINGS", "a an the of")   => "A Clash of Kings"
Kata.TitleCase("THE WIND IN THE WILLOWS", "The In") => "The Wind in the Willows"
Kata.TitleCase("the quick brown fox")               => "The Quick Brown Fox"
*/
public class Kata
{
  public static string TitleCase(string title, string minorWords="")
  {
    if(title.Length < 1) return "";
    
    string[] str = title.ToLower().Split(' ');
    string[] words = minorWords == null ? new string[0] : minorWords.Split(' ');
    string rst = "";
    
    for(int i = 0; i < str.Length; i++) {
      str[i] = str[i].ToUpper()[0] + (str[i].Length > 1 ? str[i].Substring(1) : "");
      foreach(string w in words) {
        if(str[i].ToLower() == w.ToLower()) {
          if(i == 0) break;
          str[i] = str[i].ToLower();
          break;
        }
      }
      rst += ((i > 0 ? " " : "") + str[i]);
    }
    return rst;
  }
}