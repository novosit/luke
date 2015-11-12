 var Calculator = {};

 Calculator.add = calculate;

 function calculate (input, delimiter){
     if(input.length == 0)
     {
         return 0;
     }
     return sum(input, delimiter);
};

function sum(input, delimiter ){
    if(delimiter == null)
    {
        delimiter = /[\n,]+/;
    }

    var terms = input.split(delimiter);
    var negatives = getNegativeValuesFromInput(terms);
    if(negatives.length > 0)
    {
        var message = 'negatives not allowed {' + negatives.join(",") + '}';
        throw new Error(message);
    }

    var result= 0;
    terms.map(function(term){
        result += Number(term);
    });

    return result;
}

 function getNegativeValuesFromInput(terms) {
    return terms.filter(function(term){
        if(Number(term) < 0)
        {
            return term;
        }
    });
 }

module.exports = Calculator;