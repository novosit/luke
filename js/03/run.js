var Graph 		= require('./Graph.js');
var readline 	= require('readline');

var rl = readline.createInterface({
  input: process.stdin,
  output: process.stdout,
});

var input = [];
rl.on('line', function(line){
	input.push(line);
});

rl.on('close', function() {
	var data = Graph.getGraphDataFromInput(input);

	var graph = new Graph(data.nodes, data.map, data.start, data.end);

	console.log("\r\n");
	console.log( graph.getOutput() );
});
