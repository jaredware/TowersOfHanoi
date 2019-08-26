using System;
using System.Collections.Generic;
using System.Text;

namespace TowersOfHanoi
{
    class Program
    {
        #region Global Variables
        const int TOWER_HEIGHT = 3;// Change to the amount of blocks in the tower
        const string START_TAG = "Start";
        const string END_TAG = "End";
        const string AUX_TAG = "Auxiliary";
        static Stack<string> startPegStack = new Stack<string>(TOWER_HEIGHT + 1);
        static Stack<string> endPegStack = new Stack<string>(TOWER_HEIGHT + 1);
        static Stack<string> auxPegStack = new Stack<string>(TOWER_HEIGHT + 1);
        static int MoveCounter = 0;
        #endregion

        /// <summary> Main Executable Method
        /// </summary>
        static void Main(string[] args)
        {
            BuildNewTower();

            SolveTowers(TOWER_HEIGHT, START_TAG, END_TAG, AUX_TAG);

            Console.WriteLine($"Total Moves Made: {MoveCounter}");

            // Final Read Line 
            Console.ReadLine();
        }

        /// <summary> Algorithm Method for solving the tower movements
        /// </summary>
        private static void SolveTowers(int blockCount, string pegOne, string pegTwo, string pegThree)
        {
            try
            {
                if (blockCount > 0)
                {
                    // First Nested Method Call
                    SolveTowers(blockCount - 1, pegOne, pegThree, pegTwo);
                    
                    switch (pegOne)
                    {
                        case START_TAG:// Current Peg
                            switch (pegTwo)
                            {
                                case END_TAG:// Destination Peg
                                    endPegStack.Push(startPegStack.Pop());
                                    break;
                                case AUX_TAG:// Destination Peg
                                    auxPegStack.Push(startPegStack.Pop());
                                    break;
                            }
                            break;
                        case END_TAG:// Current Peg
                            switch (pegTwo)
                            {
                                case START_TAG:// Destination Peg
                                    startPegStack.Push(endPegStack.Pop());
                                    break;
                                case AUX_TAG:// Destination Peg
                                    auxPegStack.Push(endPegStack.Pop());
                                    break;
                            }
                            break;
                        case AUX_TAG:// Current Peg
                            switch (pegTwo)
                            {
                                case START_TAG:// Destination Peg
                                    startPegStack.Push(auxPegStack.Pop());
                                    break;
                                case END_TAG:// Destination Peg
                                    endPegStack.Push(auxPegStack.Pop());
                                    break;
                            }
                            break;
                    }
                    // User output
                    Console.WriteLine($"Next Move:\n{pegOne}  >>>  {pegTwo}\n\nCurrent Move Counter:{MoveCounter}");
                    MoveCounter++;
                    System.Threading.Thread.Sleep(500);
                    DisplayStacks();

                    // Second Nested Method Call
                    SolveTowers(blockCount - 1, pegThree, pegTwo, pegOne);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("WE HAVE ENCOUNTERED AN ERROR, THIS DEVICE WILL SELF DESTRUCT");
                return;
            }
        }

        /// <summary> Method to build and display a new tower and peg combo
        /// </summary>
        private static void BuildNewTower()
        {
            string chrLiveVals;

            for (int i = TOWER_HEIGHT; i >= 1; i--)
            {
                chrLiveVals = "";
                for (int j = 0; j < 2*i-1; j++)
                {
                    chrLiveVals += "=";
                }
                startPegStack.Push(chrLiveVals);
            }
            DisplayStacks();
        }

        /// <summary> Method to display the current tower and peg status and clear the previous data
        /// </summary>
        private static void DisplayStacks()
        {
            Console.Clear();

            StringBuilder outputData = new StringBuilder($"{FormatTextPiece(30, START_TAG)}{FormatTextPiece(30, END_TAG)}{FormatTextPiece(30, AUX_TAG)}\n");// 90 character width (30 per peg)

            // Arrays to hold each line segment
            string[] startPegValues = new string[TOWER_HEIGHT];
            string[] endPegValues = new string[TOWER_HEIGHT];
            string[] auxPegValues = new string[TOWER_HEIGHT];

            int counter = 0;
            foreach (string line in startPegStack) { startPegValues[counter] = line; counter++; }
            counter = 0;
            foreach (string line in endPegStack) { endPegValues[counter] = line; counter++; }
            counter = 0;
            foreach (string line in auxPegStack) { auxPegValues[counter] = line; counter++; }

            // Sort all empty stack items (peg pieces) to the top
            Array.Sort(startPegValues, (a, b) => b == null ? 1 : a == null ? -1 : b.CompareTo(b));
            Array.Sort(endPegValues, (a, b) => b == null ? 1 : a == null ? -1 : b.CompareTo(b));
            Array.Sort(auxPegValues, (a, b) => b == null ? 1 : a == null ? -1 : b.CompareTo(b));

            for (int i = 0; i < TOWER_HEIGHT; i++)
            {
                outputData.Append($"{FormatTextPiece(30, startPegValues[i])}{FormatTextPiece(30, endPegValues[i])}{FormatTextPiece(30, auxPegValues[i])}\n");
            }

            Console.WriteLine(outputData);
        }


        /// <summary> Helper method to format a text piece to fit in a specific amount of characters by centering it
        /// </summary>
        private static string FormatTextPiece(int characterCount, string textpiece)
        {
            if (textpiece == null) { textpiece = "|"; }
            if(characterCount < textpiece.Length) { return "Logic Error, Text too large for space allocated in format"; }

            int textLength = textpiece.Length;
            char[] textChrArr = textpiece.ToCharArray();
            string output = "";

            int whiteCount = (characterCount - textLength)/2;

            // Population of output characters
            for (int i = 1; i <= whiteCount; i++) { output += " "; }
            for (int i = 0; i < textLength; i++) { output += textChrArr[i]; }
            for (int i = 1; i <= whiteCount; i++) { output += " "; }
            return output;
        }
    }
}
