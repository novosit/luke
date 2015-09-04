# Welcome young padawan! #


Show your skills using the following tools:

- JavaScript,
- C# (C Sharp), and
- TDD (any xUnit framework)

Here you have 3 programming challenges. You need to solve at least one using C# and one using JavaScript, which means, your solutions must contain both languages but you still get to solve all 3 of them. For the JS ones, create a file named `run.js` that can be executed from node.js (version 0.12.4+, you can use `--harmony` if you like) to prove your solution.

Do use TDD for any 2 challenges and include your tests in the final solution. For the JS ones have the tests run by executing `node test.js`

Allocate your solutions under the `dot_net` or `js` folders accordingly and separate each one from the other by its own folder, such as `dot_net/01/`, `dot_net/02/`, `js/03/`

***How to deliver the solution?***

Just fork this repo and submit your solution as a pull request from your **own personal github account**.

***Due date*** 

The last day to submit your solution is *** Sep. 30, 2015 ***.

---
## What aspects will we evaluate about your solutions? ##

Be aware, some assessments are subjective, such as our beliefs about good software engineering practices.

- **Your solution must work:** Please do not submit solutions not doing what was asked.
- **.NET solution:** Must run using only MSBuild tool, use .NET Framework 4.5 or any higher version
  - Put it inside `/dot_net` directory
- **JavaScript Solution:** Must run using the following command `node run.js`, will use node v12 or higher. `--harmony` is allowed
  - Put it inside `/js` directory
- **OOP Principles:** We use Object Oriented technologies, we are looking for people with solid knowledge about OO principles. To name a few, we like you to know about:
  - S.O.L.I.D., 
  - Loosely coupled components, 
  - High cohesive components,
  - Encapsulation, polymorphism, and inheritance
  
  JS solutions can be more flexible about OO principles as long as they are intuitive enough.
  
- **Code Cleanness:** We love clean code. If you only care about *implementing what was asked*, and do not care a bit about *how it was implemented*, this may not be the place for you to work. 
  - Don't be confused ***we expect your code to work (do what was asked)***, but we will read your source code carefully to see how clean and well organized it is.
- **Maintainability:** Just to enforce the point, we need people able to produce code that can be read, and changed easily by anyone different from its original author.
- **Industry conventions**: You must follow all accepted industry conventions for the tool at hand:
  - Naming conventions for the language C# / JavaScript
  - File / class / method / variable declaration and organization
- **Automated tests:** Both solution must come with a suite of unit tests.
- **Self-explained:** Your solutions must be organized in such a way that allows us to review it and test it without contacting you. If you need to do any clarification use the `README.md` file.

## What aspects will we evaluate about YOU? ##
If your code works, and we like it. We will make an appointment for an interview. You will be required to pass another set of technical and non-technical tests. Here we will list some, not all, aspects that we will be evaluating in that second round:

- **English level:** We need people able to read technical and non technical documentation in English. We also need people able to produce, at least, technical documentation / specifications in English. You need to be able to learn new things about your work using an English source. *We are not looking for a native speaker level, but if you already have that level of knowledge, your are welcome.*
- **Spanish level:** As with English, we expect you to be able to communicate effectively orally and written with your peers, clients and our executives. We do not want to have to oversee every communication you produce.
- **Team Player:** We use Agile, specifically Scrum and XP. We need you to be comfortable working as a team member. You will be required to talk and listen to others. We expect you to learn from others and teach others. We don't like the *us vs. them* mentality.
- **Self taught and eager to learn new things:** We can teach you a lot of things. Things related specifically to our product, software development skills and best practices, but with very frequently we face problems unknown for everyone on the team. In such situations we need you to seek and discover the solutions for yourself.


---
## Challenge One: Code Generator ##
### Before you start: ###
- Remember to use TDD

### Description ###
You need to implement a simple code generator API. The input will be a JSON document describing simple data structures. The output is the corresponding C# class definition. The resulting class MUST COMPILE using the .NET Framework 4.5 or higher. The API should handle the following:

- *About type:* Name space, name, visibility, mutability, and description using the following properties:
  - `"name"`: Represents the type's name. No matter the case used to describe it, the resulting case used should respect C#'s conventions. i.e: `employee` must result in a class named `Employee`.
  - `"visibility"`: valid values are `"public"`, and `"internal"`. The default is `"public"`.
  - `"mutable"`: boolean property `true` or `false`. Indicates if the entire data structure will mutable or not. The default is `false`. A class considered immutable (`"mutable": false`), can not allow property values to change. You should crate the appropriate constructor(s) to give initial values to all properties.
    - `"mutable": true`: A mutable class have read/write properties, but one or more properties could be declared as immutable, to those must be read only and assigned at construction time.
  - `"description"`: Description is an optional string used to generate XML-Doc for the class.
  - `"namespace"`: Used to define the resulting class `"namespace"`. 
- *About type's properties (data elements)*: Data elements share some attributes with types, and have unique ones as well. The full list is: name, visibility, mutability, type, cardinality, and description.
  - `"name"`: Property name, note that if you have to declare any hidden data element in order to ensure the proper mutability strategy that is up to you. The name represents the one used to declare properties in the public interface of the class, such as: `public int Age { get; set; }`, for `"age"`.
  - `"type"`: one of `"integer"`, `"float"`, `"double"`, `"string"`, `"datetime"`, `"boolean"`.
  - `"visibility"`: valid values are `"public"`, `"protected"`, `"internal"`, and `"private"`. The default is `"public"`.
  - `"mutability"`: Only allowed if the the container (type) is mutable (`"mutable": true`). Used to allow immutable properties within mutable classes. A `"mutable": true` property within a `"mutable": true` type has no effect, the result will be the same as if the mutable attribute was not specified for the property.
  - `"description"`: Description is an optional string used to generate XML-Doc for the property.
  - `"cardinality"`: Used to define collection-type properties. Defines a range of occurrences for the given type. For simplicity we will only manage two kind of cardinality: `"one"` (default), and `"many"` (unbounded collection). Translate `"many"` as `System.Collections.Generic.IList<T>`.

### Examples ###
- **A)** Input (JSON document): Immutable, and public by default.

		{
			"namespace": "Company.Accounting",
			"name": "Employee",
			"description": "Represents an employee",
			"properties": [
				{
					"name": "id",
					"type": "string",
					"description": "Employee's unique Identifier"
				},
				{
					"name": "name",
					"type": "string"
				}
			]
		}
- **A)** Output (C# class file):

		using System;

		namespace Company.Accounting
		{
		    /// <summary>
		    /// Represents an employee
		    /// </summary>
		    public class Employee
		    {
		        private readonly String id;
		        private readonly String name;
	
				/// <summary>
		        /// Employee's unique Identifier
		        /// </summary>
		        public String Id
		        {
		            get { return id; }
		        }
		
		        public String Name
		        {
		            get { return name; }
		        }
		
		        public Employee(String id, String name)
		        {
		            this.id = id;
		            this.name = name;
		        }
		    }
		}

- **B)** Input (JSON document): Mutable, and public.

		{
			"namespace": "Company.Accounting",
			"name": "Employee",
			"description": "Represents an employee",
			"mutable": true,
			"properties": [ ... ]
		}
- **B)** Output (C# class file):

		using System;

		namespace Company.Accounting
		{
		    /// <summary>
		    /// Represents an employee
		    /// </summary>
		    public class Employee
		    {
				/// <summary>
		        /// Employee's unique Identifier
		        /// </summary>
		        public String Id { get; set; }
		
		        public String Name { get; set; }
		    }
		}

- **C)** Input (JSON document): With collection property.

		{
			"namespace": "Company.Accounting",
			"name": "Employee",
			"description": "Represents an employee",
			"mutable": true,
			"properties": [ 
				{
					"name": "pastPositions",
					"type": "string",
					"cardinality": "many"
				}
			]
		}
- **C)** Output (C# class file):

		using System;
		using System.Collections.Generic;

		namespace Company.Accounting
		{
		    /// <summary>
		    /// Represents an employee
		    /// </summary>
		    public class Employee
		    {
		        public IList<String> PastPositions { get; set; }
		    }
		}


**Notes:**

- *References:* You could either put the required references with `using` statements or with full-qualified names like `System.Collections.Generic.IList<System.String> PastPositions { get; set; }`.
- *Constructors:* For immutable properties (all or some), you must provide a constructor suitable to pass all read only properties. Additionally you could provide some other constructors, but all of then must allow to pass all of the read only properties.

- **Your solution must take the input JSON from STDIN and output your solution as STDOUT**


---
## Challenge Two: String Calculator Kata (simplified) ##
See original kata description here [String Calculator Kata @ osherove.com](http://osherove.com/tdd-kata-1/ "String Calculator Kata").

### Before you start: ###
- Remember to use TDD

### Description ###
- *Create a simple String calculator with a method int `Add(string numbers)`*
  - The method can take 0, 1 or 2 numbers, and will return their sum (for an empty string it will return `0`) for example `“”` or `“1”` or `“1,2”`
  - Start with the simplest test case of an empty string and move to 1 and two numbers
  - Remember to solve things as simply as possible so that you force yourself to write tests you did not think about
  - Remember to refactor after each passing test
- *Allow the Add method to handle an unknown amount of numbers*
- *Allow the Add method to handle new lines between numbers (instead of commas)*
  - the following input is OK:  `“1\n2,3”`  (will equal `6`)
  - the following input is NOT OK:  `“1,\n”` (not need to prove it just clarifying)
- *Support different delimiters*
  - to change a delimiter, the beginning of the string will contain a separate line that looks like this:   `“//[delimiter]\n[numbers…]”` for example `“//;\n1;2”` should return three where the default delimiter is `‘;’` .
  - the first line is optional. all existing scenarios should still be supported
- *Calling Add with a negative number will throw an exception with message `“negatives not allowed”`* 
  - and the negative that was passed
  - if there are multiple negatives, show all of them in the exception message
  - message format will be `“negatives not allowed {num1 num2 ...}”`, where `{num1 num2 ...}` represents the list of negatives found

- **Your solution must take the input from STDIN and output your solution as STDOUT**

---
## Challenge Three: Weighting Paths ##

### Description ###
- Given a set of nodes in a graph and given a set of weighted relations (links) from a node to another node, find the least weighted path from a given node to another
- Input should be in the following format:

	A B C D E F G H ...
	
	A H
	
	{empty line}
	
	A B 10
	
	A C 15

	C H 20

	B H 15

	
- To better explain the input format:
  - First is the set of node names separated by one space. Node set should be on the first line
  - Second is the start node and end node separated by one space.
  - Third line is always blank
  - Subsequent lines until EOF represent links and weight between nodes. A B 10 means "moving from A to B weights 10"
  
- Output should be in the following format:

	A B H
	
	25

	
- To better explain the output format:
	- The first line is the least weighted path node by node separated by one space each
	- The second line is the total weight
  
- Your job is to find the least weighted path
- **Use plain backtracking, do not try to use any well-known optimized algorithm.**


- **Your solution must take the input from STDIN and output your solution as STDOUT**

---



![May The Force Be With You](./may-the-force-be-with-you.jpg)