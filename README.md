# SudokuConsole

Sudoku
This program can solve the 9x9 classic Sudoku Puzzle, https://en.wikipedia.org/wiki/Sudoku
My algorithm takes the 9x9 puzzle and scans it for empty fields (zeros). Every field with a zero is given a list of candidates, 1-9. A 9x9x10 array is initialized, where the original puzzle occupies the "basement" (9x9x0). The candidates of a field fill the remaining "floors" of the 3D array. If 2 is a candidate for Row 0 Column 3, then 0x3x2 will hold a 2. If not, it will hold a 0. 

A field in the basement can be filled in once it has one and only one candidate (nonzero value) in the levels above it. 
Once a field is filled, all of its candidates are changed to 0s. 

The program runs a loop that checks for consistency (have the rules of the puzzle been upheld?), and resolution (has the puzzle been solved yet). If the puzzle is still consistent but unresolved, it will continue attempting to insert values.
 
Values are first inserted if they are the only candidate for a given field. This is called Single Value Elimination and is performed by the PutItIn method. 
Second, if a candidate is the only candidate for that number among its row, column or box, it can be declared as the only candidate for that field. (If a 9 has nowhere to go in Row 3 except Row 3 Column 7, then it must go there, even if Row 3 Column 7 has other viable candidates in addition to 9.) I have elected to call this Unique Candidate Elimination, and it can happen by Row, by Column, or by Box.

Whenever Unique Candidate Elimination finds a unique candidate, put it in is called, since the Unique Candidate became the only candidate for its field, and we can then insert it into the solution of the puzzle. 

Finally, if neither Single Value nor Unique Candidate elimination are successful, the program enters a Simulation. It attempts to insert the first possible candidate of the next open field, and then evaluates the puzzle again by Single Value and Unique Candidate eliminations, like before. If an inconsistency is created, the simulation removes that value from the candidate list. If not, the Simulation will eventually solve the puzzle, because candidates may be False Positives, but there are no False Negatives, as candidates are considered valid until demonstrated to be invalid. 

Once the puzzle has been completed, it is returned to the user.

I have commented out the Console.WriteLine codes which show which values are being found and filled in, but they can be re-enabled easily in each method, to give an overview of each step the Solver is going through. 

At the top of the program, I have commented out 20 different unsolved sudokus, with the intention that the user can easily decomment one to be passed to the solver. These hardcoded puzzles are just examples, and a user could hard code their own unsolved sudoku in, using the blank template at the very top. 


You can read the full code in the Program.cs file of this repository.


There were man different learnings along the way in creating this program, especially since I used this exercise as an opportunity to practice algorithm design. The 9x9x10 array is one way to handle the candidates, but other potential solutions might use Cell objects with various attributes, or a Jagged Array where each candidate list of a field is held by its own array. 

One other potential way of eliminating candidates is referred to as preemptivity, and you can read more about it here.
https://pi.math.cornell.edu/~mec/Summer2009/meerkamp/Site/Solving_any_Sudoku_II.html
My program does not use preemptivity, because so far, I have found that my methods are effective enough that this method is not required. I wrote a method based on preemptivity, but I chose to simplify my final version of the solver and disinclude any check for preemptivity.

