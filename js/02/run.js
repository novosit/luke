var Kata 		= require('./Kata.js');
var readline 	= require('readline');

var rl = readline.createInterface({
  input: process.stdin,
  output: process.stdout,
});

var input = '';
rl.on('line', function(line){
	input += line + "\r\n";
});

rl.on('close', function() {
	console.log( Kata.add(input) );
});
