/*
 * Kata.js
 *
 * @author Ronald Rey Lovera
 * @contact reyronald@gmail.com
 * @date August 13, 2015
 */

// Using the 'Revealing Module Pattern' to only expose
// the properties that we need visible from outside,
// in this case the `add` function.
// Also, with this pattern our `DELIMETERS` array
// acts as a private static property or constant, from an OOP perspective.

// Because of the simplicity of this challenge, there's
// no need to instantiate Kata, so we don't define a constructor.
// In other words, this could also be perceived as an abstract class.
var Kata = (function() {
	// Private constant
	const DELIMETERS =  [
		',',
		'\r\n',
		'\n\r',
		'\n',
		'\r',
		'\\n',
		'\\\\n',
	];

	return {
		add : add
	};

	////////////////////

	// Public static function
	function add(input)
	{
		if (!input)
			return 0;

		// Is there a custom delimeter? Find it.
		// Wrap it in an array so that we can concat it with our default delimeters.
		var delimeterMatches = /\/\/(.*?)+(\n|\\n|\r\n|\n\r)/.exec(input);
		var customDelimeter = delimeterMatches && typeof delimeterMatches[1] !== "undefined" ? [delimeterMatches[1]] : [];

		// Regular expresion to match all possible delimeters, including custom ones.
		// Then using it in our .split() to get an array of the numbers.
		var numbers = input.split( new RegExp( DELIMETERS.concat(customDelimeter).join("|") ) );

		// The numbers array can contain non-valid string of numbers, like '//' or '',
		// in those cases we just ignore the current iteration and continue to the next one.
		var sum = 0;
		var negatives = [];
		for (var i in numbers) {
			var n = Number(numbers[i]);
			
			if (isNaN(n)) continue;

			sum += n;

			if (n < 0)
				negatives.push(n);
		}

		// Throwing exception if there are negatives.
		if (negatives.length > 0)
			throw new Error('negatives not allowed {' + negatives.join() + '}');

		return sum;
	}
})();

module.exports = Kata;