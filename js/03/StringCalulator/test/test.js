var assert = require('assert');
var calculator = require("../app/stringCalculator.js");

(function callWithEmptyInput()
{
    assert.equal(0, calculator.add(''));
})();

(function callWihtOneParameter()
{
    assert.equal(2, calculator.add('2'));
})();

(function callWihtTwoCommaSeparedParameter()
{
    assert.equal(6, calculator.add('2,4'));
})();

(function callWihtTwoNewLineSeparedParameter()
{
    assert.equal(6, calculator.add('2\n4'));
})();

(function callWihtNParameterAndCombinedDelimiter()
{
    assert.equal(12, calculator.add('2\n4,6'));
})();

(function callWihtNParameterAndCustomDelimiter()
{
    assert.equal(16, calculator.add('3-8-5','-'));
})();

(function callWihtNegativeValues()
{
    assert.throws(function(){ calculator.add('-3,8,-5,1');}, /negatives not allowed {-3,-5}/ );
})();