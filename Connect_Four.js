//https://www.codewars.com/kata/56882731514ec3ec3d000009
/*
Connect Four
Take a look at wiki description of Connect Four game:

Wiki Connect Four

The grid is 6 row by 7 columns, those being named from A to G.

You will receive a list of strings showing the order of the pieces which dropped in columns:

  piecesPositionList = ["A_Red",
                        "B_Yellow",
                        "A_Red",
                        "B_Yellow",
                        "A_Red",
                        "B_Yellow",
                        "G_Red",
                        "B_Yellow"]
The list may contain up to 42 moves and shows the order the players are playing.

The first player who connects four items of the same color is the winner.

You should return "Yellow", "Red" or "Draw" accordingly.
*/

function whoIsWinner(piecesPositionList){
  const MAX_ROW = 6;
  const MAX_COLUMN = 7;
  let winner = '';
  
  let board = [];
  
  for(let i = 0; i < MAX_COLUMN; i++) {
    board.push([]);
  }
  
  const convertPiece = (str) => {
    const info = str.split('_');
    return [info[0].charCodeAt(0) - 65, info[1][0]];
  }
  
  const check = (flag, pos, dir, prev=[]) => {
    if((pos[0] < 0 || pos[0] > MAX_ROW || pos[1] < 0 || pos[1] > board[pos[0]].length - 1) || flag != board[pos[0]][pos[1]]) return 0;
    
    
    let p = [pos[0] - dir[0], pos[1] - dir[1]];
    if(prev != [] && (p[0] == prev[0] && p[1] == prev[1])) p = [-1, -1];
    
    let p2 = [pos[0] + dir[0], pos[1] + dir[1]];
    if(prev != [] && (p2[0] == prev[0] && p2[1] == prev[1])) p2 = [-1, -1];
    
    
    return check(flag, p, dir, pos) + 1 +  check(flag, p2, dir, pos)
  }
  
  const pushPiece = (p) => {
    board[p[0]].push(p[1])
    let c1 = check(p[1], [p[0], board[p[0]].length - 1], [0, 1]);
    let c2 = check(p[1], [p[0], board[p[0]].length - 1], [1, 0]);
    let c3 = check(p[1], [p[0], board[p[0]].length - 1], [1, -1]);
    let c4 = check(p[1], [p[0], board[p[0]].length - 1], [1, 1]);
    if(c1 >= 4 || c2 >= 4 || c3 >= 4 || c4 >= 4) winner = p[1] == 'Y' ? "Yellow" : "Red";
  }
  
  let piece;
  while(piecesPositionList.length > 0 && winner == '') {
    piece = convertPiece(piecesPositionList.shift());
    pushPiece(piece);
  }
  
  if(winner == '') winner = 'Draw';
  return winner;
}