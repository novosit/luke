var fs 				= require('fs');
var readline 		= require('readline');
var CodeGenerator 	= require('./CodeGenerator.js');

var rl = readline.createInterface({
  input: process.stdin,
  output: process.stdout,
});

var input = '';
rl.on('line', function(line){
	input += line + "\r\n";
});

rl.on('close', function() {
	console.log("\r\n");
	console.log( CodeGenerator.get( JSON.parse( input ) ) );
});
