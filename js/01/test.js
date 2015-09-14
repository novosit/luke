var assert = require("assert");
var fs = require("fs");
var CodeGenerator = require("./CodeGenerator.js");
const debug = false;

////////////////////////
console.log("If you want to see both the input and the output of each test instead of just the test result, go to test.js and change the debug constant to true in line 4.\r\n");

if (typeof describe === "undefined") {
  console.log("You have to run this test with the command `node ../mocha/bin/mocha test.js`\r\n");
  process.exit();
}

function normalizeLineBreaks(str) {
  return str.replace(/\r?\n|\r/gm, '\n');
}

function compare(input, output) {
  var input = JSON.parse(fs.readFileSync(input, "utf-8"));
  var output = fs.readFileSync(output, "utf-8");

  if (debug) {
    console.log("\r\n", input, "\r\n-----------\r\n", output);
  }

  var actual = CodeGenerator.get(input);

  assert.equal(normalizeLineBreaks(actual), normalizeLineBreaks(output));
}

describe("CodeGenerator API Unit Tests", function () {
  it("Input A) from problem specification examples. Immutable, and public by default", function () {
    compare("./tests/input01.json", "./tests/output01.cs");
  });
  it("Input B) from problem specification examples. Mutable and public.", function () {
    compare("./tests/input02.json", "./tests/output02.cs");
  });
  it("Input C) from problem specification examples. With collection property.", function () {
    compare("./tests/input03.json", "./tests/output03.cs");
  });
  //
  it("Colllection of DateTime property.", function () {
    compare("./tests/input04.json", "./tests/output04.cs");
  });
  it("Integer (Int32) type. Explicit mutable class.", function () {
    compare("./tests/input05.json", "./tests/output05.cs");
  });
  it("Integer (Int32) type. Explicit immutable class.", function () {
    compare("./tests/input06.json", "./tests/output06.cs");
  });
  it("Internal, immutable class. All property's visibility, type, mutability and cardinality possibilities.", function () {
    compare("./tests/input07.json", "./tests/output07.cs");
  });
  it("Internal, mutable class. All property's visibility, type and cardinality possibilities.", function () {
    compare("./tests/input08.json", "./tests/output08.cs");
  });
});
