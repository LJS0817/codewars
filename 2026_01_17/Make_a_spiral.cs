//
/*
Your task, is to create a NxN spiral with a given size.

For example, spiral with size 5 should look like this:

00000
....0
000.0
0...0
00000
and with the size 10:

0000000000
.........0
00000000.0
0......0.0
0.0000.0.0
0.0..0.0.0
0.0....0.0
0.000000.0
0........0
0000000000
Return value should contain array of arrays, of 0 and 1, with the first row being composed of 1s. For example for given size 5 result should be:

[[1,1,1,1,1],[0,0,0,0,1],[1,1,1,0,1],[1,0,0,0,1],[1,1,1,1,1]]
Because of the edge-cases for tiny spirals, the size will be at least 5.

General rule-of-a-thumb is, that the snake made with '1' cannot touch to itself.
*/
public class Spiralizor
{
  public static int[] GetDir(int dir) {
    return new int[2] { dir == 1 ? 1 : (dir == 3 ? -1 : 0), dir == 0 ? 1 : (dir == 2 ? -1 : 0)};
  }
    public static int[,] Spiralize(int size)
    {
      int[,] rst = new int[size, size];
      int[] pos = new int[2] {size - 1, 0};
      int dirState = 3;
      for(int i = 0; i < size; i++)
        for(int j = 0; j < size; j++)
          rst[i, j] = (i == 0 || i == size - 1 || j == size - 1) ? 1 : 0;
      
      int[] dir = new int[2];
      for(int i = 0, cnt = 0, startSize = size - 3; i < size - 3; i++) {
        dir = GetDir(dirState);
        dirState = dirState + 1 < 4 ? dirState + 1 : 0;
        System.Console.WriteLine(dir[0] + "     "  + dir[1]);
        for(int j = 0; j < startSize; j++) {
          pos[0] += dir[0];
          pos[1] += dir[1];
          rst[pos[0], pos[1]] = 1;
        }
        cnt++;
        if(cnt > 1) {
          startSize -= 2;
          cnt = 0;
        }
      }
      return rst;      
    }
}