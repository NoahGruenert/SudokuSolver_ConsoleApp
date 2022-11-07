// See https://aka.ms/new-console-template for more information
using System.Diagnostics.Metrics;
using System.Diagnostics;
using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Xml;
using System.Collections;
using System.Reflection.Metadata.Ecma335;

class SudokuConsole
{

   static void Main()
   {
      SudokuConsole Q = new SudokuConsole();

      //BLANK SUDOKU TEMPLATE
      /*
      int[,] StarterGrid = new int[9, 9]                                  //size 9 COUNTING BEGINS AT 0
      {
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },

            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },

            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
      };
      */

      //EASY
      /*
      int[,] StarterGrid = new int[9, 9]                                  
      {
         { 1, 6, 0, 2, 0, 3, 4, 0, 0 },         //Row 1
         { 3, 9, 7, 0, 0, 0, 0, 0, 8 },         //Row 2 
         { 0, 0, 2, 8, 1, 9, 0, 0, 6 },         //Row 3

         { 2, 7, 0, 0, 6, 5, 9, 0, 0 },         //Row 4
         { 0, 8, 9, 0, 0, 0, 6, 4, 0 },         //Row 5
         { 6, 4, 0, 0, 0, 0, 2, 7, 0 },         //Row 6

         { 0, 2, 6, 0, 0, 1, 0, 9, 0 },         //Row 7
         { 0, 0, 0, 0, 8, 0, 0, 1, 7 },         //Row 8
         { 7, 0, 0, 3, 0, 4, 0, 6, 0 }         //Row 9
      };
      */
      //EASY 2
      /*
      int[,] StarterGrid = new int[9, 9]                                  
      {
         { 4, 9, 6, 0, 7, 0, 0, 0, 0 },         //Row 1
         { 0, 0, 8, 9, 0, 3, 0, 0, 0 },         //Row 2 
         { 7, 5, 0, 8, 0, 2, 0, 1, 9 },         //Row 3

         { 0, 0, 0, 0, 0, 0, 0, 2, 5 },         //Row 4
         { 0, 0, 1, 7, 2, 0, 4, 9, 0 },         //Row 5
         { 8, 0, 7, 0, 9, 0, 3, 6, 0 },         //Row 6

         { 0, 8, 0, 0, 0, 7, 9, 0, 0 },         //Row 7
         { 0, 6, 0, 0, 5, 4, 0, 3, 0 },         //Row 8
         { 0, 0, 0, 2, 8, 9, 1, 5, 6 }         //Row 9
      };
      */
      //EASY 3
      /*
      int[,] StarterGrid = new int[9, 9]                                  
      {
         { 3, 0, 0, 7, 0, 1, 9, 2, 0 },         //Row 1
         { 7, 0, 6, 0, 0, 9, 8, 0, 0 },         //Row 2 
         { 8, 9, 0, 0, 2, 6, 4, 0, 3 },         //Row 3

         { 0, 0, 2, 0, 0, 8, 0, 3, 4 },         //Row 4
         { 0, 7, 0, 3, 1, 0, 0, 0, 0 },         //Row 5
         { 5, 0, 0, 0, 0, 0, 2, 1, 0 },         //Row 6

         { 9, 1, 0, 2, 4, 0, 0, 6, 0 },         //Row 7
         { 0, 8, 0, 0, 0, 0, 3, 4, 0 },         //Row 8
         { 2, 0, 4, 8, 0, 3, 1, 0, 0 }         //Row 9
      };
      */
      //EASY 4
      /*
      int[,] StarterGrid = new int[9, 9]                                 
      {
            { 0, 0, 0, 8, 0, 5, 4, 2, 7 },
            { 0, 0, 7, 2, 0, 3, 9, 0, 5 },
            { 0, 2, 4, 7, 0, 1, 0, 0, 0 },

            { 7, 4, 0, 0, 8, 6, 1, 0, 0 },
            { 0, 0, 8, 9, 1, 0, 7, 0, 4 },
            { 0, 1, 0, 0, 3, 0, 0, 9, 8 },

            { 0, 0, 0, 0, 0, 0, 0, 0, 1 },
            { 9, 0, 1, 3, 7, 0, 0, 0, 6 },
            { 2, 0, 0, 0, 5, 0, 3, 4, 0 },
      };
      */

      //EASY 5
      /*
      int[,] StarterGrid = new int[9, 9]                                  
      {
            { 0, 8, 6, 4, 7, 0, 9, 0, 3 },
            { 0, 0, 0, 9, 0, 1, 0, 8, 0 },
            { 1, 0, 0, 0, 3, 8, 0, 0, 4 },

            { 0, 5, 0, 0, 0, 0, 4, 0, 9 },
            { 0, 0, 3, 5, 0, 9, 0, 6, 2 },
            { 2, 9, 1, 0, 0, 6, 0, 0, 8 },

            { 0, 0, 2, 8, 1, 0, 0, 0, 0 },
            { 8, 1, 0, 3, 0, 4, 7, 0, 0 },
            { 4, 3, 0, 2, 6, 0, 0, 0, 0 },
      };
      */

      //MEDIUM 1
      /*
      int[,] StarterGrid = new int[9, 9]                                  
    {
          { 0, 0, 0, 0, 9, 7, 0, 0, 0 },         //Row 1
          { 0, 0, 0, 0, 1, 0, 0, 7, 2 },         //Row 2 
          { 9, 0, 2, 0, 0, 4, 0, 0, 0 },         //Row 3

          { 0, 8, 0, 0, 0, 0, 3, 0, 0 },         //Row 4
          { 6, 0, 0, 0, 0, 2, 0, 1, 0 },         //Row 5                    
          { 0, 0, 0, 0, 5, 3, 0, 2, 9 },         //Row 6

          { 0, 5, 6, 0, 0, 0, 1, 0, 0 },         //Row 7
          { 7, 0, 0, 0, 6, 0, 0, 9, 0 },         //Row 8
          { 0, 4, 0, 0, 0, 0, 0, 0, 0 }         //Row 9
    };
      */
      //MEDIUM 2
      /*
      int[,] StarterGrid = new int[9, 9]                                 
    {
         { 0, 1, 0, 0, 0, 0, 0, 0, 0 },         //Row 1
         { 0, 0, 8, 0, 0, 7, 1, 2, 0 },         //Row 2 
         { 9, 0, 0, 0, 0, 3, 0, 8, 5},         //Row 3

         { 6, 0, 9, 4, 0, 2, 0, 1, 0 },         //Row 4
         { 0, 3, 1, 0, 0, 0, 0, 0, 6 },         //Row 5                    
         { 0, 0, 0, 0, 0, 0, 7, 0, 0 },         //Row 6

         { 0, 5, 0, 0, 1, 0, 3, 0, 8 },         //Row 7
         { 0, 0, 0, 5, 0, 0, 0, 0, 0 },         //Row 8
         { 0, 9, 0, 0, 4, 0, 0, 0, 0 }         //Row 9
    };
      */
      // MEDIUM 3
      /*
      int[,] StarterGrid = new int[9, 9]                                  
      {
            { 0, 0, 3, 5, 0, 8, 0, 2, 7 },
            { 6, 0, 7, 0, 0, 0, 9, 0, 5 },
            { 0, 0, 0, 0, 9, 0, 0, 0, 0 },

            { 0, 3, 8, 2, 1, 0, 0, 6, 0 },
            { 0, 0, 0, 0, 0, 0, 1, 0, 0 },
            { 0, 0, 2, 7, 3, 4, 0, 0, 8 },

            { 0, 0, 5, 0, 0, 0, 0, 0, 0 },
            { 7, 0, 6, 0, 5, 1, 3, 0, 0 },
            { 0, 0, 0, 4, 7, 0, 2, 0, 0 },
      };
      */

      //MEDIUM 4
      /*
      int[,] StarterGrid = new int[9, 9]                                
      {
            { 0, 0, 0, 1, 0, 0, 0, 0, 0 },
            { 4, 2, 0, 0, 7, 0, 0, 1, 0 },
            { 0, 6, 0, 2, 0, 0, 0, 0, 0 },

            { 9, 0, 4, 0, 0, 0, 1, 5, 3 },
            { 0, 5, 0, 0, 0, 1, 9, 0, 0 },
            { 0, 1, 3, 0, 0, 9, 0, 0, 2 },

            { 7, 0, 0, 0, 3, 0, 8, 0, 0 },
            { 0, 0, 0, 0, 1, 0, 6, 4, 9 },
            { 1, 9, 0, 8, 0, 0, 3, 0, 0 },
      };
      */

      //MEDIUM 5
      /*
      int[,] StarterGrid = new int[9, 9]                                 
      {
            { 0, 7, 3, 0, 0, 0, 8, 0, 0 },
            { 0, 0, 0, 7, 0, 0, 0, 4, 0 },
            { 0, 5, 0, 4, 0, 9, 0, 0, 6 },

            { 0, 0, 5, 0, 0, 2, 0, 0, 9 },
            { 7, 0, 0, 9, 0, 0, 1, 0, 0 },
            { 2, 1, 0, 0, 0, 0, 5, 0, 8 },

            { 0, 0, 0, 2, 0, 7, 0, 1, 3 },
            { 3, 0, 0, 0, 9, 5, 6, 8, 0 },
            { 0, 0, 7, 8, 0, 0, 0, 0, 0 },
      };
      */
      //HARD 
      /*
      int[,] StarterGrid = new int[9, 9]                                 
   {
         { 0, 2, 8, 0, 0, 0, 7, 0, 0 },         
         { 0, 0, 7, 0, 0, 0, 0, 9, 3 },         
         { 0, 0, 0, 0, 0, 0, 4, 0, 0},        

         { 0, 0, 4, 0, 0, 0, 3, 0, 0 },         
         { 0, 0, 0, 0, 0, 5, 0, 1, 0 },                          
         { 0, 8, 0, 1, 6, 9, 0, 0, 0 },      

         { 0, 0, 0, 0, 1, 0, 0, 0, 9 },        
         { 5, 0, 0, 0, 0, 0, 0, 3, 0 },        
         { 0, 0, 9, 2, 0, 4, 0, 0, 0 }       
   };
      */
      //HARD 2
      /*
      int[,] StarterGrid = new int[9, 9]                                 
      {
            { 0, 0, 4, 0, 0, 2, 5, 0, 0 },
            { 0, 0, 0, 0, 3, 0, 0, 0, 0 },
            { 0, 0, 3, 0, 0, 9, 0, 7, 2 },

            { 0, 0, 5, 0, 0, 6, 0, 0, 1 },
            { 8, 0, 0, 1, 0, 0, 4, 6, 9 },
            { 1, 9, 0, 0, 0, 4, 0, 0, 5 },

            { 0, 7, 0, 4, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 7, 6, 0, 0, 0, 0 },
            { 0, 6, 0, 0, 2, 0, 3, 4, 0 },
      };
      */

      //HARD 3
      /*
      int[,] StarterGrid = new int[9, 9]                                 
      {
            { 0, 2, 6, 0, 4, 3, 0, 0, 0 },
            { 0, 0, 0, 6, 0, 0, 0, 0, 0 },
            { 0, 0, 3, 0, 0, 0, 2, 0, 5 },

            { 5, 6, 8, 0, 0, 0, 0, 0, 2 },
            { 0, 0, 0, 0, 0, 0, 9, 0, 1 },
            { 0, 0, 7, 0, 0, 0, 0, 3, 0 },

            { 0, 1, 0, 0, 0, 0, 0, 4, 6 },
            { 7, 0, 0, 0, 6, 0, 0, 0, 0 },
            { 0, 8, 0, 9, 7, 4, 0, 0, 0 },
      };
      */

      // HARD 4
      /*
      int[,] StarterGrid = new int[9, 9]                                  
      {
            { 0, 0, 6, 0, 9, 0, 0, 0, 1 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 4, 0, 0, 0, 2, 0, 7, 0, 0 },

            { 9, 0, 0, 0, 4, 0, 0, 0, 6 },
            { 8, 0, 0, 0, 0, 0, 0, 0, 5 },
            { 7, 0, 0, 0, 8, 9, 0, 1, 0 },

            { 0, 0, 4, 2, 0, 0, 0, 5, 0 },
            { 0, 0, 3, 0, 1, 0, 0, 0, 2 },
            { 0, 0, 0, 8, 0, 5, 0, 0, 0 },
      };
      */

      //HARD 5
      /*
      int[,] StarterGrid = new int[9, 9]                                 
      {
            { 2, 0, 0, 4, 0, 0, 0, 1, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 6, 4 },
            { 8, 0, 0, 0, 1, 0, 5, 0, 0 },

            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 2, 0, 0, 0, 3, 1, 0, 0 },
            { 9, 0, 0, 0, 5, 0, 7, 0, 0 },

            { 0, 6, 0, 0, 4, 0, 0, 0, 0 },
            { 0, 7, 0, 0, 9, 0, 2, 0, 0 },
            { 0, 3, 0, 5, 0, 0, 6, 0, 7 },
      };
      */
      //MASTER DIFFICULTY
      /*
      int[,] StarterGrid = new int[9, 9]                                  
  {
         { 0, 0, 7, 0, 0, 0, 0, 0, 6 },         //Row 1
         { 0, 0, 0, 0, 8, 0, 0, 0, 0 },         //Row 2 
         { 6, 0, 0, 0, 5, 4, 1, 0, 0},         //Row 3

         { 0, 0, 9, 0, 4, 3, 0, 5, 0 },         //Row 4
         { 0, 0, 0, 7, 0, 0, 3, 0, 0 },         //Row 5                    
         { 4, 0, 0, 8, 0, 0, 0, 0, 0 },         //Row 6

         { 0, 2, 0, 0, 0, 0, 0, 9, 0 },         //Row 7
         { 7, 0, 0, 0, 6, 1, 5, 0, 0 },         //Row 8
         { 0, 0, 0, 3, 0, 0, 0, 0, 0 }         //Row 9
  };
      */

      //MASTER 2
      /*
      int[,] StarterGrid = new int[9, 9]                                  
      {
            { 0, 8, 0, 0, 6, 7, 1, 0, 3 },
            { 0, 0, 4, 0, 8, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 2, 0, 0 },

            { 0, 4, 0, 0, 0, 1, 8, 0, 7 },
            { 5, 0, 0, 9, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 6, 0 },

            { 0, 0, 9, 1, 0, 0, 3, 0, 6 },
            { 0, 3, 0, 0, 0, 0, 0, 2, 0 },
            { 0, 0, 0, 0, 0, 6, 0, 4, 0 },
      };
      */
      //MASTER 3
      /*
      int[,] StarterGrid = new int[9, 9]                                 
      {
            { 9, 0, 0, 0, 2, 0, 0, 0, 0 },
            { 0, 0, 6, 0, 0, 0, 0, 8, 0 },
            { 0, 3, 0, 9, 0, 1, 0, 0, 7 },

            { 8, 0, 0, 5, 0, 2, 0, 7, 0 },
            { 0, 5, 0, 0, 4, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 3, 0, 0, 0, 2 },

            { 0, 9, 0, 7, 0, 5, 0, 0, 1 },
            { 3, 0, 0, 0, 0, 0, 9, 0, 0 },
            { 0, 0, 0, 4, 0, 0, 0, 0, 0 },
      };
      */
      //MASTER 4
      /*
      int[,] StarterGrid = new int[9, 9]                                 
      {
            { 9, 0, 8, 0, 0, 0, 0, 7, 0 },
            { 0, 0, 0, 0, 0, 2, 0, 0, 0 },
            { 0, 1, 0, 9, 3, 0, 4, 0, 0 },

            { 7, 0, 0, 2, 5, 0, 0, 4, 0 },
            { 0, 0, 0, 0, 0, 1, 2, 0, 0 },
            { 0, 5, 0, 0, 0, 6, 0, 0, 0 },

            { 0, 3, 0, 5, 4, 0, 9, 0, 0 },
            { 0, 0, 0, 0, 6, 0, 0, 0, 0 },
            { 1, 0, 0, 0, 0, 0, 0, 0, 3 },
      };
      */
      //MASTER 5
      
      int[,] StarterGrid = new int[9, 9]                                  
      {
            { 0, 0, 0, 3, 9, 0, 0, 0, 5 },
            { 0, 2, 8, 0, 0, 6, 1, 0, 0 },
            { 4, 0, 0, 0, 0, 0, 0, 0, 0 },

            { 0, 6, 3, 0, 0, 8, 2, 0, 0 },
            { 0, 7, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 2, 0, 0, 0, 1, 0 },

            { 7, 0, 0, 0, 0, 0, 3, 0, 0 },
            { 1, 0, 0, 0, 0, 4, 0, 0, 0 },
            { 0, 3, 4, 0, 6, 0, 0, 9, 0 },
      };
      


      int[,,] Grid = new int[9, 9, 10];                              // 9 x 9 x 10 because 9x9 is sudoku flat, with 9 floors above for candidates
                                                                     //and first floor k=0; is reserved for the correct number
      for (int i = 0; i < 9; i++)                                    //For every row
      {
         for (int j = 0; j < 9; j++)                                 // for every column (meaning for item in the row)
         {
            if (StarterGrid[i, j] > 0)                               //If StarterGrid provides a value
            {
               Grid[i, j, 0] = StarterGrid[i, j];                    // put that value on the ground floor
               for (int k = 1; k < 10; k++)                           //then we will modify the K
               {
                     Grid[i, j, k] = 0;                             //when StarterGrid provides a value, make all K 0, because that field doesnt have any candidates
               }
            }
            else
            {

               for (int k = 1; k < 10; k++)                                
               {
                  Grid[i, j, k] = k;                                 //when StarterGrid does not provide a value, fill the K values of grid with candidates
               }
            }
         }
      }


      Q.CandidateClearance(Grid);                                    //reinitialize all possible candidates and then clear invalid all candidates
      Q.Printer(Grid);                                               // print Empty Sudoku for user (9x9x0)

      Stopwatch SW = new Stopwatch();                          
      SW.Start();                                                    //start the stopwatch
      Q.Solver(Grid);                                                //solve the sudoku and print it (built in)
      SW.Stop();                                                     //stop the stopwatch
      Console.WriteLine($"Time Elapsed: {SW.ElapsedMilliseconds}");  //print the elapse time for solving
   }

   public bool Consistent(int[,,] Grid)                  //method to check for consistency
   {
      int i;
      int j;
      int l;
      int e;
      int k;
      bool Consistency = true;
      for (i = 0; i < 9; i++)             //for all rows
      {
         for (j = 0; j < 9; j++)          //for all columns
         {
            for (l = 0; l < 9; l++)   //Items in given Row i
            {
               if ((Grid[i, j, 0] == Grid[i, l, 0]) & (Grid[i, j, 0] != 0) & (j != l))
               {
                  Consistency = false;
               }
            }
            for (e = 0; e < 9; e++)   //items in given column j
            {
               if ((Grid[i, j, 0] == Grid[e, j, 0]) & (Grid[e, j, 0] != 0) & (i != e))
               {
                  Consistency = false;
               }
            }
            int N = i / 3;
            int M = j / 3;

            for (k = 0; k < 3; k++)
            {
               for (l = 0; l < 3; l++)
               {


                  if (((N * 3) + k) != i | ((M * 3) + l) != j)
                  {
                     if ((Grid[i, j, 0] == Grid[((N * 3) + k), ((M * 3) + l), 0]) & (Grid[((N * 3) + k), ((M * 3) + l), 0] != 0))
                     {
                        Consistency = false;
                     }
                  }

               }
            }

         }
      }
      return Consistency;
   }
   public bool Resolved(int[,,] Grid)                             //Method to check for whether the sudoku is solved
   {
      int i;
      int j;
      bool Resolved = true;
      for (i = 0; i < Grid.GetLength(0); i++)
      {
         for (j = 0; j < Grid.GetLength(1); j++)
         {
            if (Grid[i, j, 0] == 0)
            {
               Resolved = false;
            }
         }
      }
      return Resolved;
   }

   public void Solver(int[,,] Grid)                                     //solver method
   {
      int i;
      int j;
      int k;
      bool Continue = true;
      Console.WriteLine("Solving your Sudoku...");
      while (Resolved(Grid) == false & Continue == true)                //loop until puzzle is solved or solver cannot find any more values
      {
         Continue = false;
         CandidateClearance(Grid);
         for (i = 0; i < Grid.GetLength(0); i++)
         {
            for (j = 0; j < Grid.GetLength(1); j++)
            {
               CandidateClearance(Grid);
               Continue = Continue | PutItIn(Grid, i, j);
            }
         }
         for (i = 0; i < Grid.GetLength(0); i++)
         {
            for (j = 0; j < Grid.GetLength(1); j++)
            {
               CandidateClearance(Grid);
               Continue = Continue | rowUniqueCandidateFinder(Grid, i, j);
               Continue = Continue | colUniqueCandidateFinder(Grid, i, j);
               Continue = Continue | boxUniqueCandidateFinder(Grid, findMyBox(Grid, i, j), i, j);
            }
         }

         if (Continue == false)
         {
            Continue = Continue | Simulation(Grid);
         }

         //Console.WriteLine($"Consistency is {Consistent(Grid)}");
         //Printer(Grid);
      }
      Printer(Grid);
      Console.WriteLine($"Resolved is {Resolved(Grid)}");
      Console.WriteLine($"Continue is {Continue}");
   }

   public bool Simulation(int[,,] Grid)   
   {
      int i;
      int j;
      int k;
      int a;
      int b;
      bool Continue = false;
      bool copyChanged = false;
      if (Consistent(Grid) != true)
      {
         return copyChanged;
      }
      int[,,] Copy = new int[9, 9, 10];

      Copier(Grid, Copy);

      for (i = 0; i < Copy.GetLength(0); i++)
      {
         for (j = 0; j < Copy.GetLength(1); j++)
         {
            if (Copy[i, j, 0] == 0)
            {
               for (k = 1; k < Copy.GetLength(2); k++)
               {
                  if (Copy[i, j, k] != 0)
                  {

                     Copy[i, j, 0] = k;
                     copyChanged = true;

                     for (int z = 1; z < Copy.GetLength(2); z++)
                     {
                        Copy[i, j, z] = 0;               //clear remaining candidates for tested value in Copy       TRY REINITIALIZING THE CANDIDATES AT SOME POINT

                     }

                     if (Consistent(Copy) == true)
                     {
                        Continue = true;
                        while (Resolved(Copy) != true && Continue == true)
                        {
                           for (a = 0; a < Copy.GetLength(0); a++)
                           {
                              for (b = 0; b < Copy.GetLength(1); b++)
                              {

                                 CandidateClearance(Copy);
                                 Continue = PutItIn(Copy, a, b);
                              }
                           }

                           for (a = 0; a < Copy.GetLength(0); a++)
                           {
                              for (b = 0; b < Copy.GetLength(1); b++)
                              {
                                 CandidateClearance(Copy);

                                 Continue = Continue | rowUniqueCandidateFinder(Copy, a, b);
                                 Continue = Continue | colUniqueCandidateFinder(Copy, a, b);
                                 CandidateClearance(Copy);
                                 Continue = Continue | boxUniqueCandidateFinder(Copy, findMyBox(Copy, a, b), a, b);
                              }
                           }
                        }
                        if (Resolved(Copy))  //If resolved, 
                        {
                           Copier(Copy, Grid);     //Replace the original Grid with the newly solved copy
                           copyChanged = true;     //indicate that the Copy was changed 

                        }
                        else
                        {                             //if unresolved, but cannot continue (broke out of While loop)
                           Grid[i, j, k] = 0;         //Remove K as a possible candidate, and try the next candidate of I J
                           Copier(Grid, Copy);        //Restore the Copy to the way the Grid was before Simulation
                           copyChanged = true;        //indicate that the Copy was changed (because a candidate was removed

                        }
                     }
                  }
               }
            }
         }
      }
      return copyChanged;
   }



   public void CandidateClearance(int[,,] Grid)
   {
      int i;
      int j;
      int k;
      for (i = 0; i < Grid.GetLength(0); i++)      //for all rows
      {
         for (j = 0; j < Grid.GetLength(1); j++)   //for all items in a row
         {
            for (k = 1; k < Grid.GetLength(2); k++)   //for all candidates
            {
               Grid[i, j, k] = k;                        //initialize ALL candidates 1-9
            }
         }
      }
      for (i = 0; i < Grid.GetLength(0); i++)        //for all rows
      {
         for (j = 0; j < Grid.GetLength(1); j++)     //for all columns
         {
            if (Grid[i, j, 0] != 0)                      //if the Grid has a nonzero value in the Field
            {
               for (k = 1; k < Grid.GetLength(2); k++)
               {
                  Grid[i, j, k] = 0;                     //set all candidates that it might have to 0, since it is already a resolved field
               }
            }
         }
      }

      for (i = 0; i < Grid.GetLength(0); i++)     //for all rows
      {
         for (j = 0; j < Grid.GetLength(1); j++)  //for all columns
         {
            RowCandidateRemoval(Grid, i, j);          //eliminate ineligible candidates by row
            ColCandidateRemoval(Grid, i, j);          //eliminate ineligible candidates by column
            BoxCandidateRemoval(Grid, i, j);          //eliminate ineligible candidates by box
         }
      }
   }

   public void Copier(int[,,] Origin, int[,,] Target)             //method for mapping one array onto another, used by Simulation
   {
      int x;
      int y;
      int z;
      for (x = 0; x < 9; x++)                     //for all rows
      {
         for (y = 0; y < 9; y++)                  //for all columns
         {
            for (z = 0; z < 10; z++)              //for all candidates
            {
               Target[x, y, z] = Origin[x, y, z];     //fill Target (Copy) matrix with values of Origin matrix
            }
         }
      }
   }

   /************************************PRINTER METHODS*****************************************************************************/

   public void Printer(int[,,] Grid)
   {

      int i = 0;
      int j = 0;
      for (i = 0; i < Grid.GetLength(0); i++)                  //for all rows
      {
         for (j = 0; j < Grid.GetLength(1); j++)               //for all columns
         {
            Console.Write($" {Grid[i, j, 0]} ");               //print the value of the field
         }
         Console.WriteLine("");                                //breakline to make it look nice after the last item in a row (J of 9)
      }
      Console.WriteLine("");                                   //breakline to make it look nice at the very end

   }

   public void CandidatePrinter(int[,,] Grid, int i, int j)                   //method for printing the valid candidates of a field
   {
      int k = 0;
      if (Grid[i, j, 0] > 0)
      {
         Console.WriteLine($"{Grid[i, j, 0]} is the value in for Row {i} Column {j}.");
         //print the Field value of a given point I J
      }
      else
      {
         Console.WriteLine($"Row {i} Column {j} has no value yet.");
         Console.WriteLine($"The candidates for Row {i} Column {j} are: ");
         for (k = 1; k < 10; k++)
         {
            if (Grid[i, j, k] > 0)                                //for each nonzero candidate K
            {
               Console.Write($" {Grid[i, j, k]}");                //print K
               Console.Write(", ");                               //Print a comma and space for readability
            }
         }
         Console.WriteLine("");                                   //print a breakline for readability
      }
   }

   /*********************************************************************************************************************************/

   public void RowCandidateRemoval(int[,,] Grid, int i, int l)
   {
      int j;
      //for given point I,L
      for (j = 0; j < Grid.GetLength(1); j++)                       //search each item in Row I
      {
         if (Grid[i, j, 0] > 0)                                         //if Item has nonzero field,
         {
            Grid[i, l, Grid[i, j, 0]] = 0;                              //remove that  value as a candidate of I,L                     
         }
      }
   }

   public void ColCandidateRemoval(int[,,] Grid, int e, int j)
   {
      int i;
      //for a given point E J
      for (i = 0; i < Grid.GetLength(0); i++)                    //search each item in Col J
      {
         if (Grid[i, j, 0] > 0)                                      //if Item has nonzero field
         {
            Grid[e, j, Grid[i, j, 0]] = 0;                           //remove that value as a candidate of E,J
         }
      }
   }

   public void BoxCandidateRemoval(int[,,] Grid, int i, int j)
   {
      int boxByRow = i / 3;
      int boxByCol = j / 3;
      int[] Box = new int[9];
      int c = 0;
      int e;
      int l;
      int f;
      for (e = 0; e < 9; e++)                              //for each row
      {
         if (e / 3 == i / 3)                                   //if this row matches the boxID of the given field [i,j,k]
         {
            for (l = 0; l < 9; l++)                        //for each item in the given row 
            {
               if (l / 3 == j / 3)                             //if this items column matches the boxID of the given field [i,j,k]
               {

                  Box[c] = Grid[e, l, 0];                         //provide the Box array with the value of k=0 for that item in the box [e,l,0]
                  c++;
               }
            }
         }
      }
      foreach (int number in Box)                               //looking at all the other values in my box
      {

         for (f = 0; f < 9; f++)
         {
            if (Box[f] > 0)                                    //If there is a non-zero value inside my box
            {
               Grid[i, j, (Box[f])] = 0;                          //then that value can no longer be my candidate
            }
         }
      }
   }

   public int[,,] findMyBox(int[,,] Grid, int i, int j)
   {
      int boxByRow = i / 3;
      int boxByCol = j / 3;
      int[,,] BoxAndCandidates = new int[3, 3, 10];
      int e;
      int l;
      int k;
      for (e = 0; e < 3; e++)                                 //if this row has the same boxId as the provided field [i,j,k]
      {
         for (l = 0; l < 3; l++)                           //if this item has the same boxID as the provided field [i,j,k]
         {

            for (k = 0; k < 10; k++)                     // for every item k in the K index of Grid
            {
               BoxAndCandidates[e, l, k] = Grid[e + (boxByRow * 3), l + (boxByCol * 3), k];
               //assign [i,j,k] to BoxAndCandidates[][v] at the given c (0-8)

            }
         }
      }
      return BoxAndCandidates;
   }

   /********************************************************UNIQUE CANDIDATE FINDERS***************************************************************************/

   public bool boxUniqueCandidateFinder(int[,,] Grid, int[,,] boxAndCandidates, int i, int j)
   {
      int eFinder = i % 3;
      int lFinder = j % 3;
      bool Success = false;
      bool Unique = false;
      int UniqVal = 0;
      int v;
      int e;
      int l;
      int k;
      if (boxAndCandidates[eFinder, lFinder, 0] == 0)
      {
         for (v = 1; v < 10; v++)                     // for every item v in the K index of this unresolved field
         {
            if (boxAndCandidates[eFinder, lFinder, v] > 0)            //whenever k != 0
            {

               for (e = 0; e < 3; e++)                                 //in each row of the box
               {
                  for (l = 0; l < 3; l++)                           //in each item of each row (each column)
                  {

                     if (e == eFinder && l == lFinder)
                     {
                        continue;
                     }

                     if (boxAndCandidates[eFinder, lFinder, v] != boxAndCandidates[e, l, v])              //check if k of box field == k of search field in box
                     {

                        //Console.WriteLine($" Row {eFinder} Col {lFinder} k= {v} It is  Row {e} Col {l} k= {v}");

                        Unique = true;
                        UniqVal = v;
                        //Console.WriteLine($"A Unique candidate was found for Row {i} Col {j}! It is {UniqVal}");



                     }
                     else
                     {
                        Unique = false;
                        break;
                     }
                  }
                  if (Unique == false)
                  {
                     break;
                  }
               }

            }

         }
         if (Unique == true)
         {
            //Console.WriteLine($"By Unique Value Box elimination, {UniqVal} is the only candidate for Row {i} Column {j}.");
            //Console.WriteLine($"{UniqVal} assigned as the value for Row {i} Column {j}.");
            Success = true;
            Grid[i, j, 0] = UniqVal;                  //Fill the final candidate into position

            for (k = 1; k < 10; k++)
            {
               Grid[i, j, k] = 0;               //clear out the candidate list because the value was filled in
            }
         }
      }
      return Success;
   }

   public bool rowUniqueCandidateFinder(int[,,] Grid, int i, int j)
   {
      bool Success = false;
      bool Unique = false;
      int UniqVal = 0;
      int k;
      int l;
      int z;
      for (k = 1; k < 10; k++)        //for all candidates K at point I J
      {
         if (Grid[i, j, k] > 0)           //nonzero candidates
         {
            Unique = true;
            for (l = 0; l < Grid.GetLength(1); l++)  //check the other fields in this row I for this candidate K
            {
               if (l != j)                               //dont check the J field of Row I, because it will obviously have K as a candidate
               {

                  if (Grid[i, l, k] == Grid[i, j, k])
                  {

                     Unique = false;
                  }

               }
            }
            if (Unique == true)
            {
               UniqVal = k;
               //Console.WriteLine($"By Unique Value Row elimination, {UniqVal} is the only candidate for Row {i} Column {j}.");
               //Console.WriteLine($"{UniqVal} assigned as the value for Row {i} Column {j}.");
               Grid[i, j, 0] = UniqVal;                  //Fill the final candidate into position
               Success = true;

               for (z = 1; z < 10; z++)
               {
                  Grid[i, j, z] = 0;               //clear out the candidate list because the value was filled in
                                                   //Grid[i, z-1, k] = 0;             //DIRTY I dont think we need this:
                                                   // if another field in row I has K as a candidate, we would not be getting here in the first place
                                                   // since it would not be unique

               }
               //Console.WriteLine($"Consistency is {Consistent(Grid)}");
            }
         }
      }
      return Success;
   }

   public bool colUniqueCandidateFinder(int[,,] Grid, int i, int j)
   {
      bool Success = false;
      bool Unique = false;
      int UniqVal = 0;
      int k;
      int e;
      int z;
      for (k = 1; k < 10; k++)              //for all candidates K at point I J
      {
         if (Grid[i, j, k] > 0)                 //nonzero candidates
         {
            Unique = true;
            for (e = 0; e < Grid.GetLength(0); e++)        //search the other fields or Column J
            {
               if (e != i)                                     //disregard field I J
               {
                  if (Grid[e, j, k] == Grid[i, j, k])          //if another field has K as a candidate, K is not unique
                  {

                     Unique = false;
                  }
               }
            }
            if (Unique == true)
            {
               UniqVal = k;
               //Console.WriteLine($"By Unique Value Column elimination, {UniqVal} is the only candidate for Row {i} Column {j}.");
               //Console.WriteLine($"{UniqVal} assigned as the value for Row {i} Column {j}.");
               Grid[i, j, 0] = UniqVal;                  //Fill the final candidate into position
               Success = true;

               for (z = 1; z < 10; z++)
               {
                  Grid[i, j, z] = 0;               //clear out the candidate list because the value was filled in
                  //Grid[i, z - 1, k] = 0;           //DIRTY: Goal is to remove the Un

               }

               // Console.WriteLine($"Consistency is {Consistent(Grid)}");
            }
         }

      }
      return Success;
   }
   /************************************************************************************************************************************/
   public bool PutItIn(int[,,] Grid, int i, int j)
   {
      int[] zValues = new int[Grid.GetLength(2)];
      var c = 0;
      int k;
      for (k = 1; k < 10; k++)
      {
         zValues[k] = Grid[i, j, k];
      }

      c = zValues.Count(k => k != 0);

      if (c == 1)
      {
         foreach (int number in zValues)
         {
            if (number != 0)
            {
               //Console.WriteLine($"It looks like {number} is the only candidate for Row {i} Column {j}.");
               //Console.WriteLine($"{number} assigned as the value for Row {i} Column {j}.");
               Grid[i, j, 0] = number;             //Fill the final candidate into position
               for (k = 1; k < 10; k++)
               {
                  Grid[i, j, k] = 0;               //clear out the candidate list because the value was filled in
               }

            }
         }
         //Console.WriteLine($"Consistency is {Consistent(Grid)}");
         return true;
      }
      else
      {
         return false;
      }
   }

}