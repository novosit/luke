var Graph = require('./Graph.js');
var assert = require("assert");
var fs = require("fs");
const debug = false;

////////////////////////
if (typeof describe === "undefined") {
  console.log("You have to run this test with the command `node ../mocha/bin/mocha test.js`\r\n");
  process.exit();
}

function normalizeLineBreaks(str) {
  return str.replace(/\r?\n|\r/gm, '\n');
}

function compare(input, output) {
  var input = fs.readFileSync(input, "utf-8");
  var output = fs.readFileSync(output, "utf-8");

  if (debug) {
    console.log(input, "\n-----------\n", output + "\n");
  }

  var data = Graph.getGraphDataFromInput(input.split("\n"));
  var graph = new Graph(data.nodes, data.map, data.start, data.end);

  var actual = graph.getOutput();

  assert.equal(normalizeLineBreaks(actual), normalizeLineBreaks(output));
}

describe("Weighting Paths", function () {
  it("Case 1", function () {
    compare('./tests/input01.txt', './tests/output01.txt');
  });

  it("Case 2", function () {
    compare('./tests/input02.txt', './tests/output02.txt');
  });

  it("Case 3", function () {
    compare('./tests/input03.txt', './tests/output03.txt');
  });

  it("Case 4", function () {
    compare('./tests/input04.txt', './tests/output04.txt');
  });
});
