#region Problem 1: int.Parse vs Convert.ToInt32
//string? input = Console.ReadLine();

//try
//{
//    int parsedValue = int.Parse(input!);
//    Console.WriteLine($"int.Parse result: {parsedValue}");

//    int convertedValue = Convert.ToInt32(input!);
//    Console.WriteLine($"Convert.ToInt32 result: {convertedValue}");
//}
//catch (Exception ex)
//{
//    Console.WriteLine($"Exception caught: {ex.Message}");
//}
//What is the difference between int.Parse and Convert.ToInt32 when handling null inputs?
/*
 int.Parse throws an exception on null.
Convert.ToInt32 returns 0 on null without throwing.
 */
#endregion

//===============================================================

#region Problem 2: int.TryParse Usage
//using System;

//class Program
//{
//    static void Main()
//    {
//        Console.WriteLine("Please enter a number:");
//        string? input = Console.ReadLine();

//        if (int.TryParse(input, out int number))
//        {
//            Console.WriteLine($"Valid number: {number}");
//        }
//        else
//        {
//            Console.WriteLine("Error: Invalid number entered.");
//        }
//    }
//}
//Question: Why is TryParse recommended over Parse in user-facing applications?
/*
 TryParse provides a safer, faster, and more user-friendly way to validate and convert user input compared to Parse, which throws exceptions on bad input.
 */
#endregion

//==============================================================

#region Problem 3: GetHashCode() Method
/*
 using System;

class Program
{
    static void Main()
    {
        object obj;

        obj = 100;
        Console.WriteLine($"int GetHashCode: {obj.GetHashCode()}");

        obj = "Hello"; 
        Console.WriteLine($"string GetHashCode: {obj.GetHashCode()}");

        obj = 99.99; 
        Console.WriteLine($"double GetHashCode: {obj.GetHashCode()}");
    }
}

 */
//Question: Explain the real purpose of the GetHashCode() method
/*
 GetHashCode is a fast way to generate an integer that helps collections organize and find objects efficiently making operations like searching and comparison much quicker
 */
#endregion

#region Problem 4: Reference Equality
/*
using System;
using System.Text;

class Program
{
    static void Main()
    {

       StringBuilder sb1 =new StringBuilder("Hello");
       StringBuilder sb2 = sb1;
        sb2.Clear();
        sb2.Append("hello:D"); 
        Console.WriteLine(sb2);

    }
}
*/
//Question: What is the significance of reference equality in .NET?
/*
 Reference equality is fundamental in .NET for understanding object identity, 
 controlling program behavior, and optimizing performance by distinguishing 
  whether two references point to the same object instance or not.*
 */
#endregion

#region Problem 5: String Immutability
// using System;
//using System.Text;

//using System;

//class Program
//{
//    static void Main()
//    {
//        string str = "Hello";

//        Console.WriteLine($"Before modification: {str} - HashCode: {str.GetHashCode()}");

//        str += " Hi Willy";

//        Console.WriteLine($"After modification: {str} - HashCode: {str.GetHashCode()}");
//    }
//}

//Question: Why string is immutable in C# ?
/*
 Immutability makes strings safer, more efficient, and easier to use.
 */
#endregion

#region Problem 6: StringBuilder vs String Concatenation
// using System;
//using System.Text;

//class Program
//{
//    static void Main()
//    {
//        StringBuilder str = new StringBuilder("Hello");

//        Console.WriteLine($"Before modification: {str} - HashCode: {str.GetHashCode()}");

//        str.Append( " Hi Willy");

//        Console.WriteLine($"After modification: {str} - HashCode: {str.GetHashCode()}");
//    }
//}
//How does StringBuilder address the inefficiencies of string concatenation?

/*
StringBuilder improves efficiency by modifying a single mutable buffer instead of creating new string objects on every concatenation. 
This reduces memory allocations and boosts performance especially with many or large string changes.
 */

//Question: Why is StringBuilder faster for large-scale string modifications?
/*because it updates a single mutable buffer without creating new string instances each time*/
#endregion

#region Problem 7: String Formatting Methods
/*
 using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter first integer: ");
        int input1 = int.Parse(Console.ReadLine());

        Console.Write("Enter second integer: ");
        int input2 = int.Parse(Console.ReadLine());

        int sum = input1 + input2;

        // 1. Concatenation
        Console.WriteLine("Sum is " + sum);

        // 2. Composite formatting
        Console.WriteLine(string.Format("Sum is {0}", sum));

        // 3. String interpolation
        Console.WriteLine($"Sum is {sum}");
    }
}
 */

//Question: Which string formatting method is most used and why?
/*
 String interpolation is the most used method because it is simpler, more readable, and easier to maintain than concatenation or composite formatting. */
#endregion

#region Problem 8: StringBuilder Methods
/*
 using System;
using System.Text;

class Program
{
    static void Main()
    {
        StringBuilder sb = new StringBuilder("Hello World");

        // Append text
        sb.Append(" from C#");

        // Replace a substring
        sb.Replace("World", "Developers");

        // Insert text at a specific position
        sb.Insert(0, "Say: ");

        // Remove a portion of text
        sb.Remove(0, 5);

        Console.WriteLine(sb.ToString());
    }
}
 */
//Question: Explain how StringBuilder is designed to handle frequent modifications compared to strings.

/*
 StringBuilder allows changes to the same mutable buffer, avoiding new object creation. This makes it more efficient than strings for frequent modifications.
 */
#endregion