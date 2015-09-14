# Shortest Weighted Path Challenge (js/03) #

Install dependencies

    $ npm install

To run the unit tests, `cd` into this directory and type

    $ npm t

To run the main program, `cd` into this directory and type. 
    
    $ node run.js
    
Keep in mind that you will have to use STDIN to view the output. See below.

##### From input file 
To run the program with a local file as the input:

    $ node run.js < ./tests/input01.txt

##### From command line input 
To get the output directly from a command line input without using a document/file, run the program, then paste the contents of the clipboard into the console or type it by hand. The ^D character at the bottom represent the End-of-Transmission signal.

```sh
    $ node run.js
    A B C D E F G H
    A H

    A B 10
    A C 15
    C H 20
    B H 15
    ^D
```
