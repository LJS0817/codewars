//https://www.codewars.com/kata/587136ba2eefcb92a9000027
/*
Introduction
Snakes and Ladders is an ancient Indian board game regarded today as a worldwide classic. It is played between two or more players on a gameboard having numbered, gridded squares. A number of "ladders" and "snakes" are pictured on the board, each connecting two specific board squares. (Source Wikipedia)


Task
Your task is to make a simple class called SnakesLadders. The test cases will call the method play(die1, die2) independantly of the state of the game or the player turn. The variables die1 and die2 are the die thrown in a turn and are both integers between 1 and 6. The player will move the sum of die1 and die2.

The Board

Rules
There are two players and both start off the board on square 0.
Player 1 starts and alternates with player 2.
You follow the numbers up the board in order 1=>100
If the value of both die are the same then that player will have another go.
Climb up ladders. The ladders on the game board allow you to move upwards and get ahead faster. If you land exactly on a square that shows an image of the bottom of a ladder, then you may move the player all the way up to the square at the top of the ladder. (even if you roll a double).
Slide down snakes. Snakes move you back on the board because you have to slide down them. If you land exactly at the top of a snake, slide move the player all the way to the square at the bottom of the snake or chute. (even if you roll a double).
Land exactly on the last square to win. The first person to reach the highest square on the board wins. But there's a twist! If you roll too high, your player "bounces" off the last square and moves back. You can only win by rolling the exact number needed to land on the last square. For example, if you are on square 98 and roll a five, move your game piece to 100 (two moves), then "bounce" back to 99, 98, 97 (three, four then five moves.)
If the Player rolled a double and lands on the finish square “100” without any remaining moves then the Player wins the game and does not have to roll again.
Returns
Return "Player n Wins!" Where n is winning player that has landed on square 100 without any remainding moves left.

Return "Game over!" if a player has won and another player tries to play.

Otherwise return Player n is on square x. Where n is the current player and x is the sqaure they are currently on.

Good luck and enjoy!
*/
class SnakesLadders
{
  int p1;
  int p2;
  bool p1Turn;
  bool isOver;
  int[] map;
  public SnakesLadders()
  {
    isOver = false;
    p1Turn = true;
    p1 = -1;
    p2 = -1;
    map = new int[100];
    for(int i = 0; i < map.Length; i++) map[i] = 0;
    
    map[1] = 37;
    map[6] = 13;
    map[7] = 30;
    map[14] = 25;
    map[15] = 5;
    map[20] = 41;
    map[27] = 83;
    map[35] = 43;
    map[45] = 24;
    map[48] = 10;
    map[50] = 66;
    map[61] = 18;
    map[63] = 59;
    map[70] = 90;
    map[73] = 52;
    map[77] = 97;
    map[86] = 93;
    map[88] = 67;
    map[91] = 87;
    map[94] = 74;
    map[98] = 79;
  }
  public string play(int die1, int die2)
  {
    if(isOver) return "Game over!";
    int sum = die1 + die2;
    if(p1Turn) {
      p1 += sum;
      if(p1 >= map.Length) p1 = (map.Length - 1) - (p1 % (map.Length - 1));
      if(map[p1] != 0) p1 = map[p1];
    } else {
      p2 += sum;
      if(p2 >= map.Length) p2 = (map.Length - 1) - (p2 % (map.Length - 1));
      if(map[p2] != 0) p2 = map[p2];
    }
    string rst = "Player " + (p1Turn ? "1" : "2");
    if((p1Turn && p1 == map.Length - 1) || (!p1Turn && p2 == map.Length - 1)) {
      rst += " Wins!";
      isOver = true;
    } else {
      rst += " is on square " + ((p1Turn ? p1 : p2) + 1);
    }
    if(die1 != die2) p1Turn = !p1Turn;
    return rst;
  }
}