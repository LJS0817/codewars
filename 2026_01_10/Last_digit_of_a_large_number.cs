//
/*
Define a function that takes in two non-negative integers a and b and returns the last decimal digit of a^b. Note that a and b  may be very large!
Examples
GetLastDigit(4, 1)            // returns 4
GetLastDigit(4, 2)            // returns 6
GetLastDigit(9, 7)            // returns 9    
GetLastDigit(10, 10000000000) // returns 0
*/
namespace Solution
{
  using System.Numerics;
  class LastDigit
  {
    public static int GetLastDigit(BigInteger n1, BigInteger n2)
    {
      return (int)BigInteger.ModPow(n1, n2, 10);
    }
  }
}