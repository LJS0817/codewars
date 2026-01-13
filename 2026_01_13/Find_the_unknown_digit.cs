//https://www.codewars.com/kata/546d15cebed2e10334000ed9
/*
To give credit where credit is due: This problem was taken from the ACMICPC-Northwest Regional Programming Contest. Thank you problem writers.

You are helping an archaeologist decipher some runes. He knows that this ancient society used a Base 10 system, and that they never start a number with a leading zero. He's figured out most of the digits as well as a few operators, but he needs your help to figure out the rest.

The professor will give you a simple math expression, of the form

[number][op][number]=[number]
He has converted all of the runes he knows into digits. The only operators he knows are addition (+),subtraction(-), and multiplication (*), so those are the only ones that will appear. Each number will be in the range from -1000000 to 1000000, and will consist of only the digits 0-9, possibly a leading -, and maybe a few ?s. If there are ?s in an expression, they represent a digit rune that the professor doesn't know (never an operator, and never a leading -). All of the ?s in an expression will represent the same digit (0-9), and it won't be one of the other given digits in the expression. No number will begin with a 0 unless the number itself is 0, therefore 00 would not be a valid number.

Given an expression, figure out the value of the rune represented by the question mark. If more than one digit works, give the lowest one. If no digit works, well, that's bad news for the professor - it means that he's got some of his runes wrong. output -1 in that case.

Complete the method to solve the expression to find the value of the unknown rune. The method takes a string as a paramater repressenting the expression and will return an int value representing the unknown rune or -1 if no such rune exists.
*/
public class Runes
{
  public static int solveExpression(string expression)
  {
    string[] num = new string[3];
    char op = ' ';
    int rst = 0;
    
    int m = expression.IndexOf('-', 1);
    if(m > 0 && expression.IndexOf('*') < 0 && expression.IndexOf('+') < 0) expression = expression.Substring(0, m) + "_" + expression.Substring(m + 1, expression.Length - m - 1);
    
    for(int i = 0; i <= 9; i++) {
      if(expression.IndexOf((char)('0' + i)) > -1) continue;
      num = expression.Replace('?', (char)('0' + i)).Split(new char[4] {'+', '_', '*', '='});
      if(op == ' ') op = expression[num[0].Length];
      if(int.TryParse(num[0], out int n1) && int.TryParse(num[1], out int n2) && int.TryParse(num[2], out int n3)) {
        if(n1.ToString().Length != num[0].Length || n2.ToString().Length != num[1].Length || n3.ToString().Length != num[2].Length) continue;
        if(op == '+') rst = n1 + n2;
        else if(op == '_') rst = n1 - n2;
        else rst = n1 * n2;

        if(rst == n3) return i;
      } else continue;
    }
    
    return -1;
  }
}