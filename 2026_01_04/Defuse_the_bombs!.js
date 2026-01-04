//https://www.codewars.com/kata/54d558c72a5e542c0600060f
/*
There are a series of 10 bombs about to go off! Defuse them all! Simple, right?

Note: This is not an ordinary Kata, but more of a series of puzzles. The point is to figure out what you are supposed to do, then how to do it. Instructions are intentionally left vague.
*/
for(let i = 0; i < 5; i++) Bomb.diffuse(Bomb.key)

Bomb.diffuse(Bomb.key)

Bomb.diffuse(global.BombKey)

function diffuseTheBomb() { return true; }
Bomb.diffuseTheBomb=diffuseTheBomb
Bomb.diffuse()

Bomb.diffuse(3.14159)

const date = new Date()
date.setFullYear(date.getFullYear() - 4)
Bomb.diffuse(date)

Bomb.key = 42;
Bomb.diffuse(Object.freeze({key:43}));

function obj(n) {
  this.number = n;
}

obj.prototype.valueOf = function () {
  this.number += 3
  return this.number;
};

Bomb.diffuse(new obj(6));

Math.cnt = 0
function random() {
  Math.cnt++;
  return Math.cnt % 2 == 0 ? 0.5 : 1;
}
Math.random = random;
Bomb.diffuse(Bomb.key);

Array.prototype.valueOf = function() {
  return 14;
}
Bomb.diffuse(Buffer.from('yes'));