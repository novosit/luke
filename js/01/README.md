# Code Generator API Challenge (js/01) #

Install dependencies

    $ npm install

To run the unit tests, `cd` into this directory and type

    $ npm t

To run the main program, `cd` into this directory and type. 
    
    $ node run.js
    
Keep in mind that you will have to use STDIN to view the output. See below.

##### From input file 
To run the program with a JSON document as the input:

    $ node run.js < ./tests/input01.json

##### From command line input 
To get the output directly from a command line input without using a document/file, run the program, then paste the contents of the clipboard into the console or type it by hand. The ^D character at the bottom represent the End-of-Transmission signal.

```sh
    $ node run.js
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
    ^D
```
