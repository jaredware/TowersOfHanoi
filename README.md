# TowersOfHanoi
Console Application for Automated Solution of the Towers of Hanoi Problem - With Visual Display

This solution will recieve an input number of the amount of blocks in the tower and then calculate the most efficient route to move them from the start peg to the end peg.

## Getting Started


## Prerequisites
This project will only require Visual Studio 2017 or above to utilise the program as it is unbuilt. This solution is not aimed at being a consumer product and so the code release and debug versions are only to be examined. Therefore there is no installation needed.

## Assembly Information
### Global Variables
    const int TOWER_HEIGHT
    const string START_TAG
    const string END_TAG
    const string AUX_TAG
    static Stack<string> startPegStack = new Stack<string>(TOWER_HEIGHT + 1)
    static Stack<string> endPegStack = new Stack<string>(TOWER_HEIGHT + 1)
    static Stack<string> auxPegStack = new Stack<string>(TOWER_HEIGHT + 1)
    static int MoveCounter

### Methods
    /// Main Executable Method
    public static void Main(string[] args)
    
    /// Algorithm Method for solving the tower movements
    private static void SolveTowers(int blockCount, string pegOne, string pegTwo, string pegThree)
    
    /// Method to build and display a new tower and peg combo
    private static void BuildNewTower()
   
    /// Method to display the current tower and peg status and clear the previous data
    private static void DisplayStacks()
    
    /// Helper method to format a text piece to fit in a specific amount of characters by centering it
    private static string FormatTextPiece(int characterCount, string textpiece)
## Built With
- Visual Studio Enterprise 2017
- .NET Framework (**C#**) Console

## Versioning
Assembly Version: (**1.0.0.1**)

Assembly File Version: (**1.0.0.1**)

## Author
- Jared Ware - Lead Developer - Student BCAD313 (**2019**)

## License
This product is the intellectual property of the author involved and belongs to the organization of Varsity College **Copyright © 2019**
