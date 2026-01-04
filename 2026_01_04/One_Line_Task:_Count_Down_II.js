//https://www.codewars.com/kata/58f85908bc60c645d5000095
/*
Task
Count down 3 times to an positive integer n, return these 3 numbers as a string.

Code Limit
Less than 25 characters.

Example
For n = 1, the output should be `"321".

count down from 3 to 1

For n = 10, the output should be `"121110".

count down from 12 to 10

For n = 100, the output should be `"102101100".

count down from 102 to 100
*/


countDown=n=>n+2+[n+1]+n