//https://www.codewars.com/kata/52a89c2ea8ddc5547a000863
/*
You are given a node that is the beginning of a linked list. This list contains a dangling piece and a loop. Your objective is to determine the length of the loop.

For example in the following picture the size of the dangling piece is 3 and the loop size is 12:



# Use the `next' method to get the following node.
node.next
Notes:

do NOT mutate the nodes!
in some cases there can be just a loop, with no dangling piece.
Don't miss dmitry's article in the discussion after you pass the Kata !!
*/
public class Kata{
  public static int getLoopSize(LoopDetector.Node startNode){
    LoopDetector.Node slow = startNode;
    LoopDetector.Node fast = startNode;
    
    while(fast != null && fast.next != null) {
      slow = slow.next;
      fast = fast.next.next;
      if(slow == fast) {
        int cnt = 1;
        fast = fast.next;
        while(slow != fast) {
          fast = fast.next;
          cnt++;
        }
        return cnt;
      }
    }
    return 0;
  }
}