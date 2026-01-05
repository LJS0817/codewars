//https://www.codewars.com/kata/58e61f3d8ff24f774400002c
/*
This is the second part of this kata series. First part is here.

We want to create an interpreter of assembler which will support the following instructions:

mov x, y - copy y (either an integer or the value of a register) into register x.
inc x - increase the content of register x by one.
dec x - decrease the content of register x by one.
add x, y - add the content of the register x with y (either an integer or the value of a register) and stores the result in x (i.e. register[x] += y).
sub x, y - subtract y (either an integer or the value of a register) from the register x and stores the result in x (i.e. register[x] -= y).
mul x, y - same with multiply (i.e. register[x] *= y).
div x, y - same with integer division (i.e. register[x] /= y).
label: - define a label position (label = identifier + ":", an identifier being a string that does not match any other command). Jump commands and call are aimed to these labels positions in the program.
jmp lbl - jumps to the label lbl.
cmp x, y - compares x (either an integer or the value of a register) and y (either an integer or the value of a register). The result is used in the conditional jumps (jne, je, jge, jg, jle and jl)
jne lbl - jump to the label lbl if the values of the previous cmp command were not equal.
je lbl - jump to the label lbl if the values of the previous cmp command were equal.
jge lbl - jump to the label lbl if x was greater or equal than y in the previous cmp command.
jg lbl - jump to the label lbl if x was greater than y in the previous cmp command.
jle lbl - jump to the label lbl if x was less or equal than y in the previous cmp command.
jl lbl - jump to the label lbl if x was less than y in the previous cmp command.
call lbl - call to the subroutine identified by lbl. When a ret is found in a subroutine, the instruction pointer should return to the instruction next to this call command.
ret - when a ret is found in a subroutine, the instruction pointer should return to the instruction that called the current function.
msg 'Register: ', x - this instruction stores the output of the program. It may contain text strings (delimited by single quotes) and registers. The number of arguments isn't limited and will vary, depending on the program.
end - this instruction indicates that the program ends correctly, so the stored output is returned (if the program terminates without this instruction it should return the default output: see below).
; comment - comments should not be taken in consideration during the execution of the program.

Output format:
The normal output format is a string (returned with the end command). For Scala and Rust programming languages it should be incapsulated into Option.

If the program does finish itself without using an end instruction, the default return value is:

-1 (as an integer)

Input format:
The function/method will take as input a multiline string of instructions, delimited with EOL characters. Please, note that the instructions may also have indentation for readability purposes.

For example:

program = """
; My first program
mov  a, 5
inc  a
call function
msg  '(5+1)/2 = ', a    ; output message
end

function:
    div  a, 2
    ret
"""
assembler_interpreter(program)
The above code would set register a to 5, increase its value by 1, calls the subroutine function, divide its value by 2, returns to the first call instruction, prepares the output of the program and then returns it with the end instruction. In this case, the output would be (5+1)/2 = 3.
*/
function getCommandLine(line) { return line.match(/'[^']*'|[^ \t,]+/g) || []; }

function findFunctions(lines, variables) { 
  let functionName = '';
  for(let i = 0; i < lines.length; i++) {
    if(lines[i].length > 0) {
      if(lines[i][0].indexOf(':') > 0) {
        variables[lines[i][0]] = [];
        functionName = lines[i][0];
      } else if(functionName != '') {
        variables[functionName].push(lines[i]);
      }
    } else if(functionName != '') functionName = '';
  }
}

function compare(v, a, cond) {
  let cmpData = v['cmp']
  delete v['cmp']
  if(cond(cmpData[0], cmpData[1])) return run(v, ['jmp', a[0]])
}

const commands = {
  'mov': (v, [a, b]) => { v[a] = parseInt(v[b] != undefined ? v[b] : b); },
  'inc': (v, [a]) => { v[a]++; },
  'dec': (v, [a]) => { v[a]--; },
  'add': (v, [a, b]) => { v[a] += parseInt(v[b] != undefined ? v[b] : b); },
  'sub': (v, [a, b]) => { v[a] -= parseInt(v[b] != undefined ? v[b] : b); },
  'mul': (v, [a, b]) => { v[a] *= parseInt(v[b] != undefined ? v[b] : b); },
  'div': (v, [a, b]) => { v[a] = parseInt(v[a] / parseInt(v[b] != undefined ? v[b] : b)); },
  'jmp': (v, a) => {
    for(let i = 0; i < v[a+':'].length; i++) {
      if(run(v, v[a+':'][i]) == 3) return 3;
    }
    v['throwError']=true;
  },
  'cmp': (v, [a, b]) => {
    a = v[a] != undefined ? v[a] : a;
    b = v[b] != undefined ? v[b] : b;
    v['cmp'] = [a, Number(b)];
  },
  'jne': (v, a) => compare(v, a, (x, y) => x != y),
  'je': (v, a) => compare(v, a, (x, y) => x == y),
  'jge': (v, a) => compare(v, a, (x, y) => x >= y) ,
  'jg': (v, a) => compare(v, a, (x, y) => x > y),
  'jle': (v, a) => compare(v, a, (x, y) => x <= y),
  'jl': (v, a) => compare(v, a, (x, y) => x < y),
  'call': (v, a) => {
    for(let i = 0; i < v[a+':'].length; i++) {
      if(run(v, v[a+':'][i]) == 3) return 3;
    }
    v['throwError']=true;
  },
  'ret': (v, a) => 3,
  'msg': (v, a) => {
    v['rst'] = ''
    for(let i = 0; i < a.length; i++) {
      if(a[i] == ';') break;
      v['rst'] += v[a[i]] != undefined ? v[a[i]] : a[i];
    }
    v['rst'] = v['rst'].trim().replaceAll('\'', '')
  },
  'end': (v, a) => {},
  ';': (v, a) => {},
}

function run(v, ls) {
  return commands[ls[0]](v, ls.slice(1));
}

function assemblerInterpreter(program) {
  let variables = {};
  let lines = program.split('\n').map((i) => getCommandLine(i))
  findFunctions(lines, variables);
  let point = 0;
  while(lines[point][0] != 'end') {
    run(variables, lines[point])
    if(variables['throwError']) return -1;
    point++;
  }
  return variables['rst'];
}