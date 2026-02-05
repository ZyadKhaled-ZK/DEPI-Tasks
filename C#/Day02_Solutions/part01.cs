#region Part01 - Problem: Add both single-line and multi-line comments in the following code segment explaining its purpose

int x = 10;
int y = 20;
int sum = x + y;
Console.WriteLine(sum);

#endregion


#region Part01 - Question: What is the shortcut to comment and uncomment a selected block of code in Visual Studio?

// Comment shortcut: Ctrl + K, then Ctrl + C
// Uncomment shortcut: Ctrl + K, then Ctrl + U

#endregion


#region Part01 - Problem: Identify and fix the errors in this code snippet:
// int x = "10";
// console.WriteLine(x + y);

int fixedX = 10;
int fixedY = 20;
Console.WriteLine(fixedX + fixedY);

#endregion


#region Part01 - Question: Explain the difference between a runtime error and a logical error with examples

/*
Runtime error example:
int a = 10;
int b = 0;
int result = a / b;  // Causes runtime error: division by zero

Logical error example:
int c = 10;
int d = 20;
int sum = c - d;  // Logical error: should be c + d
*/

#endregion


#region Part01 - Problem: Declare variables using proper naming conventions to store:
/*
string fullName = "Your Full Name";
int age = 25;
decimal monthlySalary = 3500.50m;
bool isStudent = false;
*/
#endregion


#region Part01 - Question: Why is it important to follow naming conventions such as PascalCase in C#?

// Answer: It improves code readability by visually separating words, making the code easier to maintain and understand.

#endregion


#region Part01 - Problem: Write a program to demonstrate that changing the value of a reference type affects all references pointing to that object

/*
using System;

class Program
{
    class Person
    {
        public string Name { get; set; }
    }

    static void Main()
    {
        Person p1 = new Person();
        p1.Name = "Alice";

        Person p2 = p1;
        p2.Name = "Bob";

        Console.WriteLine(p1.Name); // Outputs "Bob"
        Console.WriteLine(p2.Name); // Outputs "Bob"
    }
}
*/

#endregion


#region Part01 - Question: Explain the difference between value types and reference types in terms of memory allocation

// Value types are stored on the stack and copied by value.
// Reference types are stored on the heap and variables hold references to these objects.

#endregion


#region Part01 - Problem: Create a program that calculates the following using variables x = 15 and y = 4:
// Sum, Difference, Product, Division result, Remainder

/*
using System;

class Program
{
    static void Main()
    {
        int x = 15;
        int y = 4;

        int sum = x + y;
        int difference = x - y;
        int product = x * y;
        double divisionResult = (double)x / y;
        int remainder = x % y;

        Console.WriteLine("Sum: " + sum);
        Console.WriteLine("Difference: " + difference);
        Console.WriteLine("Product: " + product);
        Console.WriteLine("Division result: " + divisionResult);
        Console.WriteLine("Remainder: " + remainder);
    }
}
*/

#endregion


#region Part01 - Question: What will be the output of the following code? Explain why:
// int a = 2, b = 7;
// Console.WriteLine(a % b);

// Output: 2
// Explanation: When the left operand is smaller than the right operand, the modulus returns the left operand itself.

#endregion


#region Part01 - Problem: Write a program that checks if a given number is both:
// Greater than 10 and Even

/*
using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int number = int.Parse(Console.ReadLine());

        if (number > 10 && number % 2 == 0)
        {
            Console.WriteLine("The number is greater than 10 and even.");
        }
        else
        {
            Console.WriteLine("The number does not meet the conditions.");
        }
    }
}
*/

#endregion


#region Part01 - Question: How does the && (logical AND) operator differ from the & (bitwise AND) operator?

// && : Short-circuits; if the first condition is false, the second is not evaluated.
// & : Both conditions are always evaluated.

#endregion


#region Part01 - Problem: Implement a program that takes a double input from the user and casts it to an int. Use both implicit and explicit casting, then print the results

/*
using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter a double number: ");
        double doubleValue = double.Parse(Console.ReadLine());

        int intValue = (int)doubleValue;  // explicit casting
        double implicitDouble = intValue; // implicit casting

        Console.WriteLine("Original double value: " + doubleValue);
        Console.WriteLine("After explicit cast to int: " + intValue);
        Console.WriteLine("Implicitly cast int back to double: " + implicitDouble);
    }
}
*/

#endregion


#region Part01 - Question: Why is explicit casting required when converting a double to an int?

// Because converting from double to int can cause loss of data (truncation of decimal part), so explicit cast is required to tell the compiler you accept this.

#endregion


#region Part01 - Problem: Write a program that: (G01 Bonus, G02 mandatory)
// Prompts the user for their age as a string.
// Converts the string to an integer using Parse.
// Checks if the age is valid (e.g., greater than 0).

/*
using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter your age: ");
        string ageInput = Console.ReadLine();

        int age = int.Parse(ageInput);

        if (age > 0)
            Console.WriteLine("Your age is valid: " + age);
        else
            Console.WriteLine("Invalid age! Age must be greater than 0.");
    }
}
*/

#endregion


#region Part01 - Question: What exception might occur if the input is invalid and how can you handle it?

// If input is not numeric, int.Parse throws FormatException.
// Use try-catch block to handle it gracefully.

#endregion


#region Part01 - Problem: Write a program that demonstrates the difference between prefix and postfix increment operators using a variable x

/*
using System;

class Program
{
    static void Main()
    {
        int x = 5;
        Console.WriteLine(x++); // Prints 5, then x = 6
        Console.WriteLine(++x); // Increments to 7, then prints 7
    }
}
*/

#endregion


#region Part01 - Question: Given the code below, what is the value of x after execution? Explain why
// int x = 5;
// int y = ++x + x++;

// x after execution: 7
// y = 6 + 6 = 12
// Explanation:
// ++x increments before using the value (x becomes 6)
// x++ uses current value (6) then increments x to 7

#endregion
