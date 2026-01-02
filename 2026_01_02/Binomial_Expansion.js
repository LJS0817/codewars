//https://www.codewars.com/kata/540d0fdd3b6532e5c3000b5b/train/javascript
/*
The purpose of this kata is to write a program that can do some algebra.

Write a function expand that takes in an expression with a single, one character variable, and expands it. The expression is in the form (ax+b)^n where a and b are integers which may be positive or negative, x is any single character variable, and n is a natural number. If a = 1, no coefficient will be placed in front of the variable. If a = -1, a "-" will be placed in front of the variable.

The expanded form should be returned as a string in the form ax^b+cx^d+ex^f... where a, c, and e are the coefficients of the term, x is the original one character variable that was passed in the original expression and b, d, and f, are the powers that x is being raised to in each term and are in decreasing order.

If the coefficient of a term is zero, the term should not be included. If the coefficient of a term is one, the coefficient should not be included. If the coefficient of a term is -1, only the "-" should be included. If the power of the term is 0, only the coefficient should be included. If the power of the term is 1, the caret and power should be excluded.

Examples:
expand("(x+1)^2");      // returns "x^2+2x+1"
expand("(p-1)^3");      // returns "p^3-3p^2+3p-1"
expand("(2f+4)^6");     // returns "64f^6+768f^5+3840f^4+10240f^3+15360f^2+12288f+4096"
expand("(-2a-4)^0");    // returns "1"
expand("(-12t+43)^2");  // returns "144t^2-1032t+1849"
expand("(r+0)^203");    // returns "r^203"
expand("(-x-1)^2");     // returns "x^2+2x+1"
*/
function expand(expr) {
  let input = expr.split('^')
  
  let n = Number(input[1])
  if(n == 0) return '1';
  
  input[0] = input[0].slice(1, input[0].length - 1);
  let X = input[0][input[0].search(/[a-zA-Z]/)];
  
  const translate = (f, n, x, arr=[]) => {
    if(n == 0) return arr;
    let F = f.split(x).map(num => { 
      if(num == '-') num = '-1';
      return Number(num)
    });
    
    if(F[0] == 0) F[0] = 1;
    
    if(arr.length == 0) { 
      arr = F;
      return translate(f, n - 1, x, arr);
    }
    
    let tmp = [[], []];
    for(let i = 0; i < arr.length; i++) {
      tmp[0].push(arr[i] * F[0])
      tmp[1].push(arr[i] * F[1])
    }
    arr = [];
    for(let i = 0; i < tmp[0].length + 1; i++) {
      if(i == 0) arr.push(tmp[0][i]);
      else if(i < tmp[0].length) arr.push(tmp[0][i] + tmp[1][i - 1]);
      else arr.push(tmp[1][i - 1]);
    }
    return translate(f, n - 1, x, arr);
  }
  
  
  let rstArr = translate(input[0], n, X);

  let rst = '';
  for(let i = 0; i < rstArr.length; i++) {
    if(rstArr[i] == 0) continue;
    let op = i > 0 && rstArr[i] > 0 ? "+" : "";
    let a = i < rstArr.length - 1 && (rstArr[i] == 1 || rstArr[i] == -1) ? (rstArr[i] == -1 ? "-" : "") : rstArr[i];
    let s = i < rstArr.length - 1 && rstArr.length - 1 - i > 1 ? "^"+(n-i) : "";
    let x = i < rstArr.length - 1 ? X : "";
    rst += `${op}${a}${x}${s}`
  }
  return rst;
}