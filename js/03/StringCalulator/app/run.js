/* */
var calculator = require("./stringCalculator.js");
var readline = require('readline'),
    rl = readline.createInterface(process.stdin, process.stdout);

console.log('\nEnter values to calculate, to finish and empty line.\n');

rl.setPrompt('Enter the values: > ');
rl.prompt();

var lines= [];
var result = 0;
var delimiter;
rl.on('line', function(line) {
    switch(line.trim()) {
        case '':
        {
            result = calculator.add(lines.join(","), delimiter);
            rl.close();
            break;
        }
        default:
        {
            var newDelimiter = getDelimiter(line);
            delimiter = delimiter || newDelimiter;
            if (newDelimiter == null) {
                lines.push(line);
            }
            break;
        }
    }
    rl.prompt();
}).on('close', function() {
    console.log('The input was: ' + lines.join(","));
    console.log('The result was: ' + result);
    process.exit(0);
});


function getDelimiter(input) {

    var delimiter = input;
    if(delimiter.length == 0)
    {
        return null;
    }

    if((delimiter.substring(0, 2) != '//'))
    {
        return null;
    }

    delimiter = delimiter.substring(3, delimiter.length -1);
    if(delimiter.length == 0)
    {
        return null;
    }

    return delimiter;
}