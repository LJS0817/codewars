//https://www.codewars.com/kata/52bb6539a4cf1b12d90005b7
/*
Write a method that takes a field for well-known board game "Battleship" as an argument and returns true if it has a valid disposition of ships, false otherwise. Argument is guaranteed to be 10*10 two-dimension array. Elements in the array are numbers, 0 if the cell is free and 1 if occupied by ship.

Battleship (also Battleships or Sea Battle) is a guessing game for two players. Each player has a 10x10 grid containing several "ships" and objective is to destroy enemy's forces by targetting individual cells on his field. The ship occupies one or more cells in the grid. Size and number of ships may differ from version to version. In this kata we will use Soviet/Russian version of the game.


Before the game begins, players set up the board and place the ships accordingly to the following rules:
There must be single battleship (size of 4 cells), 2 cruisers (size 3), 3 destroyers (size 2) and 4 submarines (size 1). Any additional ships are not allowed, as well as missing ships.
Each ship must be a straight line, except for submarines, which are just single cell.

The ship cannot overlap or be in contact with any other ship, neither by edge nor by corner.
*/
function validateBattlefield(field) {
  let copied = field.slice();
  const SIZE = 10;
  
  const MAX_COUNT = [1, 2, 3, 4];
  let count = [0, 0, 0, 0];
  
  const getShipIndex = (pos, dir, cnt=0) => {
    if(cnt == MAX_COUNT.length) return [];
    if(pos[1] >= SIZE || pos[0] >= SIZE) return [];
    return copied[pos[1]][pos[0]] == 1 ? [pos, ...getShipIndex([pos[0] + dir[0], pos[1] + dir[1]], dir, cnt+1)] : [];
  }
  
  const isValidShip = (axis) => {
    let cAxis = axis.slice();
    let dir = axis[1].slice();
    axis = [[axis[0][0][0] - dir[0], axis[0][0][1] - dir[1]], ...axis[0], [axis[0][axis[0].length - 1][0] + dir[0], axis[0][axis[0].length - 1][1] + dir[1]]]
    dir = [dir[1], dir[0]]
    let sum = 0;
    for(let i = 0; i < axis.length; i++) {
      for(let j = -1; j <= 1; j++) {
        let pos = [axis[i][0] + dir[0] * j, axis[i][1] + dir[1] * j]
        if(pos[0] < 0 || pos[0] >= SIZE || pos[1] < 0 || pos[1] >= SIZE) continue;

        sum += copied[pos[1]][pos[0]]
      }
    }
    return sum == axis.length - 2;
  }
  
  for(let i = 0; i < copied.length; i++) {
    for(let j = 0; j < copied[i].length; j++) {
      if(copied[i][j] == 0) continue;
      let ver = getShipIndex([j, i], [0, 1]);
      let hor = getShipIndex([j, i], [1, 0]);
      
      let axis = ver.length > hor.length ? [ver, [0, 1]] : [hor, [1, 0]];
      let rst = isValidShip(axis)
      if(rst) {
        for(let i = 0; i < axis[0].length; i++) {
          copied[axis[0][i][1]][axis[0][i][0]] = 0
        }
        count[4 - axis[0].length]++;
        if(count[4 - axis[0].length] > MAX_COUNT[4 - axis[0].length]) return false;
      } 
    }
  }
  return count[0] == MAX_COUNT[0] && count[1] == MAX_COUNT[1] && count[2] == MAX_COUNT[2] && count[3] == MAX_COUNT[3];
}