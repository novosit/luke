var assert          = require("assert");
var fs              = require("fs");
var Kata            = require('./Kata.js');

////////////////////////
if ( typeof describe === "undefined" ) {
  console.log("You have to run this test with the command `node ../mocha/bin/mocha test.js`\r\n");
  process.exit();
}

function compare(input, expected)
{
  assert.equal( Kata.add(input), expected );
}

describe("String Calculator Kata (simplified)", function() {
  it("Empty string", function() {
    compare("", 0);
  });
  it("One number (1)", function() {
    compare("1", 1);
  });
  it("Two numbers (1,2)", function() {
    compare("1,2", 3);
  });

  it("Variable amount of numbers", function() {
    compare("1,2,1,1,1,1", 7);
  });

  it("Handle newlines as delimeters instead of just commas", function() {
    compare("1\r\n2\r\n1\r\n1\r\n1,1", 7);
  });

  it("The 'no need to prove it' test for an invalid input (“1,2,\\n” => 3).", function() {
    compare("1,2,\n", 3);
  });

  it("Handle newlines as delimeters instead of just commas part 2", function() {
    compare("1,2\r\n1,1\r\n1,1\r\n", 7);
  });

  it("Support different delimeters", function() {
    compare("//;\n1;2", 3);
  });

  it("Support different delimeters + previous requirements", function() {
    compare("//;\n1;2,1\r\n1,1;1", 7);
  });

  it("Simple test for negative number", function() {
    var input = "1,-1";
    var expected = "negatives not allowed {-1}";

    assert.throws( function() {
      Kata.add(input);
    }, Error, expected);
  });

  it("Simple test for negative numbers (multiple)", function() {
    var input = "-1,1,-2,3,-4";
    var expected = "negatives not allowed {-1,-2,-4}";
    assert.throws( function() {
      Kata.add(input);
    }, Error, expected);
  });

  it("Simple test for negative numbers (multiple) + multiple delimeters", function() {
    var input = "-1,1,-2,\r\n3,-4\n6\n-7,-9";
    var expected = "negatives not allowed {-1,-2,-4,-7,-9}";
    assert.throws( function() {
      Kata.add(input);
    }, Error, expected);
  });

  it("Simple test for negative numbers (multiple) + custom delimeter", function() {
    var input = "//x\n-1,1x-2,3,-4\r\nx";
    var expected = "negatives not allowed {-1,-2,-4}";
    assert.throws( function() {
      Kata.add(input);
    }, Error, expected);
  });
});