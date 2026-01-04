//https://www.codewars.com/kata/58f85bb1985886b1b5000b6f
/*
Task
Count down 3 times to an positive integer n, return these 3 numbers as a string, separated by exclamation mark(!).

Code Limit
Less than 30 characters.

Example
For n = 1, the output should be `"3!2!1".

count down from 3 to 1

For n = 10, the output should be `"12!11!10".

count down from 12 to 10

For n = 100, the output should be `"102!101!100".

count down from 102 to 100
*/
countDown=n=>n+2+`!${n+1}!`+n