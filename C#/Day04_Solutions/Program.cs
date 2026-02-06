#region Part 01 - Problem 01:
/*
using System;

class Program
{
    static void Main()
    {
        // 1.new int[size]
        int[] arr1 = new int[3];  
        arr1[0] = 10;
        arr1[1] = 20;
        arr1[2] = 30;

        Console.WriteLine("new int[size]:");
        for (int i = 0; i < arr1.Length; i++)
        {
            Console.WriteLine($"arr1[{i}] = {arr1[i]}");    
        }

        // 2. list
        int[] arr2 = new int[] { 40, 50, 60 };

        Console.WriteLine("\nlist:");
        for (int i = 0; i < arr2.Length; i++)
        {
            Console.WriteLine($"arr2[{i}] = {arr2[i]}");
        }

        // 3. array syntax sugar
        int[] arr3 = { 70, 80, 90 };

        Console.WriteLine("\nArray syntax sugar:");
        for (int i = 0; i < arr3.Length; i++)
        {
            Console.WriteLine($"arr3[{i}] = {arr3[i]}");
        }

        // 4.  IndexOutOfRangeException
        try
        {
            Console.WriteLine("\n OutOfRange index:");
            Console.WriteLine(arr3[5]); 
        }
        catch (IndexOutOfRangeException e)
        {
            Console.WriteLine($"Exception caught: {e.Message}");
        }
    }
}
*/
#endregion

#region Part 01 - Problem 02:
/*
using System;

class Program
{
    static void Main()
    {
        // Create two arrays
        int[] arr1 = { 1, 2, 3 };
        int[] arr2 = { 4, 5, 6 };

        // shallow copy
        arr2 = arr1;

        Console.WriteLine("Shallow Copy:");
        Console.WriteLine("Before :");
        Console.WriteLine($"arr1[0]: {arr1[0]}");  // 1
        Console.WriteLine($"arr2[0]: {arr2[0]}");  // 1

        // Modify arr2
        arr2[0] = 100;

        Console.WriteLine("After:");
        Console.WriteLine($"arr1[0]: {arr1[0]}");  // 100 (changed because shallow copy)
        Console.WriteLine($"arr2[0]: {arr2[0]}");  // 100

        // Perform deep copy using Clone
        arr2 = (int[])arr1.Clone();

        Console.WriteLine("\nDeep Copy:");
        Console.WriteLine("Before:");
        Console.WriteLine($"arr1[0]: {arr1[0]}");  // 100
        Console.WriteLine($"arr2[0]: {arr2[0]}");  // 100

        // Modify arr2
        arr2[0] = 200;

        Console.WriteLine("After:");
        Console.WriteLine($"arr1[0]: {arr1[0]}");  // 100 (unchanged because deep copy)
        Console.WriteLine($"arr2[0]: {arr2[0]}");  // 200
    }
}
*/
#endregion

#region Part 01 - Problem 03:
/*
using System;

class Program
{
    static void Main()
    {
        int[,] grades = new int[3, 3];

        for (int student = 0; student < grades.GetLength(0); student++)
        {
            for (int subject = 0; subject < grades.GetLength(1); subject++)
            {
                Console.Write($"Enter grade for student {student + 1}, subject {subject + 1}: ");
                grades[student, subject] = int.Parse(Console.ReadLine()!);
            }
        }

        Console.WriteLine("\nGrades for each student:");
        for (int student = 0; student < grades.GetLength(0); student++)
        {
            Console.Write($"Student {student + 1}: ");
            for (int subject = 0; subject < grades.GetLength(1); subject++)
            {
                Console.Write(grades[student, subject] + " ");
            }
            Console.WriteLine();
        }
    }
}
*/
#endregion

#region Part 01 - Problem 04:
/*
using System;

class Program
{
    static void Main()
    {
        int[] arr = { 5, 3, 8, 1, 2 };

        Console.WriteLine("Original array:");
        PrintArray(arr);

        // 1. Sort
        Array.Sort(arr);
        Console.WriteLine("\nAfter Sort:");
        PrintArray(arr);

        // 2. Reverse
        Array.Reverse(arr);
        Console.WriteLine("\nAfter Reverse:");
        PrintArray(arr);

        // 3. IndexOf
        int index = Array.IndexOf(arr, 8);
        Console.WriteLine($"\nIndexOf 8: {index}");

        // 4. Copy
        int[] arrCopy = new int[5];
        Array.Copy(arr, arrCopy, arr.Length);
        Console.WriteLine("\n(arrCopy):");
        PrintArray(arrCopy);

        // 5. Clear
        Array.Clear(arrCopy, 1, 2);
        Console.WriteLine("\nAfter Clear):");
        PrintArray(arrCopy);

        static void PrintArray(int[] array)
        {
            foreach (int item in array)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}
*/
#endregion

#region Part 01 - Problem 05:
/*
using System;

class Program
{
    static void Main()
    {
        int[] arr = { 10, 20, 30, 40, 50 };

        // 1. For
        Console.WriteLine("for:");
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write($"{arr[i]} ");
        }
        Console.WriteLine();

        // 2. Foreach
        Console.WriteLine("foreach:");
        foreach (int item in arr)
        {
            Console.Write($"{item} ");
        }
        Console.WriteLine();

        // 3. While loop
        Console.WriteLine("while:");
        int index = arr.Length - 1;
        while (index >= 0)
        {
            Console.Write($"{arr[index]} ");
            index--;
        }
        Console.WriteLine();
    }
}
*/
#endregion

#region Part 01 - Problem 06:
/*
using System;

class Program
{
    static void Main()
    {
        int number;
        bool Valid;

        do
        {
            Console.Write("enter a positive odd number: ");
            string input = Console.ReadLine();

            Valid = int.TryParse(input, out number) && number > 0 && number % 2 != 0;

            if (!Valid)
            {
                Console.WriteLine("enter a positive odd number.");
            }

        } while (!Valid);

        Console.WriteLine($"valid positive odd number: {number}");
    }
}
*/
#endregion

#region Part 01 - Problem 07:
/*
using System;

class Program
{
    static void Main()
    {
        int[,] matrix = {
            { 1, 2, 3, 4 },
            { 5, 6, 7, 8 },
            { 9, 10, 11, 12 }
        };

        for (int row = 0; row < matrix.GetLength(0); row++)  
        {
            for (int col = 0; col < matrix.GetLength(1); col++)  
            {
                Console.Write(matrix[row, col] + "\t");  
            }
            Console.WriteLine();  
        }
    }
}
*/
#endregion

#region Part 01 - Problem 08:
/*
using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter a month number between (1-12): ");
        string input = Console.ReadLine();
        int monthNumber;

        if (int.TryParse(input, out monthNumber) && monthNumber >= 1 && monthNumber <= 12)
        {
            string monthNameIfElse;
            if (monthNumber == 1) monthNameIfElse = "January";
            else if (monthNumber == 2) monthNameIfElse = "February";
            else if (monthNumber == 3) monthNameIfElse = "March";
            else if (monthNumber == 4) monthNameIfElse = "April";
            else if (monthNumber == 5) monthNameIfElse = "May";
            else if (monthNumber == 6) monthNameIfElse = "June";
            else if (monthNumber == 7) monthNameIfElse = "July";
            else if (monthNumber == 8) monthNameIfElse = "August";
            else if (monthNumber == 9) monthNameIfElse = "September";
            else if (monthNumber == 10) monthNameIfElse = "October";
            else if (monthNumber == 11) monthNameIfElse = "November";
            else monthNameIfElse = "December";

            Console.WriteLine($"Using if else: Month name is {monthNameIfElse}");

            string monthNameSwitch;
            switch (monthNumber)
            {
                case 1: monthNameSwitch = "January"; break;
                case 2: monthNameSwitch = "February"; break;
                case 3: monthNameSwitch = "March"; break;
                case 4: monthNameSwitch = "April"; break;
                case 5: monthNameSwitch = "May"; break;
                case 6: monthNameSwitch = "June"; break;
                case 7: monthNameSwitch = "July"; break;
                case 8: monthNameSwitch = "August"; break;
                case 9: monthNameSwitch = "September"; break;
                case 10: monthNameSwitch = "October"; break;
                case 11: monthNameSwitch = "November"; break;
                case 12: monthNameSwitch = "December"; break;
                default: monthNameSwitch = "Invalid month"; break;
            }

            Console.WriteLine($"Using switch: Month name is {monthNameSwitch}");
        }
        else
        {
            Console.WriteLine("Invalid input!  enter a number between 1 and 12.");
        }
    }
}
*/
#endregion

#region Part 01 - Problem 09:
/*
using System;

class Program
{
    static void Main()
    {
        int[] numbers = { 5, 2, 8, 2, 9, 1, 5 };

        Console.WriteLine("Original array:");
        foreach (int num in numbers)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();

        Array.Sort(numbers);

        Console.WriteLine("Sorted array:");
        foreach (int num in numbers)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();

        int valueToFind = 5;

        int fIndex = Array.IndexOf(numbers, valueToFind);
        Console.WriteLine($"First  of {valueToFind} is at index: {fIndex}");

        int lIndex = Array.LastIndexOf(numbers, valueToFind);
        Console.WriteLine($"Last of {valueToFind} is at index: {lIndex}");
    }
}
*/
#endregion

#region Part 01 - Problem 10:
/*
using System;

class Program
{
    static void Main()
    {
        int[] numbers = { 3, 7, 2, 9, 4 };

        // Sum for 
        int sumf = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            sumf += numbers[i];
        }
        Console.WriteLine($"Sum using for : {sumf}");

        // Sum foreach 
        int sumFe = 0;
        foreach (int num in numbers)
        {
            sumFe += num;
        }
        Console.WriteLine($"Sum using foreach : {sumFe}");
    }
}
*/
#endregion

#region Part 02 - Problem 01:
/*
using System;

class Program
{
    enum DayOfWeek
    {
        Monday = 1,
        Tuesday =2,
        Wednesday=3,
        Thursday=4,
        Friday=5,
        Saturday=6,
        Sunday=7
    }

    static void Main()
    {
        Console.Write("Enter a number (1-7) for the day of the week: ");
        string input = Console.ReadLine()!;

        if (int.TryParse(input, out int dayNumber) && dayNumber >= 1 && dayNumber <= 7)
        {
            DayOfWeek day = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), dayNumber.ToString());
            Console.WriteLine($"The day is: {day}");
        }
        else
        {
            Console.WriteLine("Invalid.enter a number between 1 and 7.");
        }
    }
}
*/
#endregion