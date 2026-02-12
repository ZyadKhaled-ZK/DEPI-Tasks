#region Problem 1 
//using System;
//class Program
//{
//    static void Main()
//    {
//        try
//        {
//            Console.Write("first integer: ");
//            int num1 = int.Parse(Console.ReadLine()!);

//            Console.Write("second integer: ");
//            int num2 = int.Parse(Console.ReadLine()!);

//            int result = num1 / num2;
//            Console.WriteLine($"Result: {result}");
//        }
//        catch (DivideByZeroException)
//        {
//            Console.WriteLine("Error: Cannot divide by zero.");
//        }
//        catch (FormatException)
//        {
//            Console.WriteLine("Error: Please enter a valid integer.");
//        }
//        finally
//        {
//            Console.WriteLine("Done!");
//        }
//    }
//}
#endregion

#region Problem 2 
//using System;
//class Program
//{
//    public static void TestDefensiveCode()
//    {
//        int X, Y, Z;

//        do
//        {
//            Console.Write("Enter first number (positive integer): ");
//        }
//        while (!int.TryParse(Console.ReadLine(), out X) || X <= 0);

//        do
//        {
//            Console.Write("Enter second number (positive integer greater than 1): ");
//        }
//        while (!int.TryParse(Console.ReadLine(), out Y) || Y <= 1);

//        try
//        {
//            Z = X / Y;
//            Console.WriteLine($"Result of {X} / {Y} = {Z}");
//        }
//        catch (DivideByZeroException)
//        {
//            Console.WriteLine("Error: Cannot divide by zero.");
//        }

//        int[] arr = { 1, 2, 3 };
//        if (arr?.Length > 69)
//        {
//            arr[69] = 90;
//        }

//        Console.WriteLine("Operation complete.");
//    }

//    static void Main()
//    {
//        TestDefensiveCode(); 
//    }
//}
#endregion

#region Problem 3
//class Program
//{
//    static void Main()
//    {
//        int? nullableInt = null;

//        int result = nullableInt ?? 10;  
//        Console.WriteLine($"Value after null: {result}");

//        if (nullableInt.HasValue)
//        {
//            Console.WriteLine($"nullableInt has a value: {nullableInt.Value}");
//        }
//        else
//        {
//            Console.WriteLine("nullableInt is null.");
//        }

//        nullableInt = 25;
//        if (nullableInt.HasValue)
//        {
//            Console.WriteLine($"nullableInt now has a value: {nullableInt.Value}");
//        }
//        else
//        {
//            Console.WriteLine("nullableInt is null.");
//        }
//    }
//}
#endregion

#region Problem 4 
//class Program
//{
//    static void Main()
//    {
//        int[] numbers = { 10, 20, 30, 40, 50 };

//        try
//        {
//            Console.WriteLine("Trying to access numbers[6]...");
//            int value = numbers[6]; 
//            Console.WriteLine($"Value at index 6: {value}");
//        }
//        catch (IndexOutOfRangeException)
//        {
//            Console.WriteLine("Error: Index is out of bounds.");
//        }
//        finally
//        {
//            Console.WriteLine("Array access operation complete.");
//        }
//    }
//}
#endregion

#region Problem 5 
//class Program
//{
//    static void Main()
//    {
//        int[,] matrix = new int[3, 3];

//        for (int i = 0; i < 3; i++)
//        {
//            for (int j = 0; j < 3; j++)
//            {
//                int value;
//                do
//                {
//                    Console.Write($"Enter value for element [{i},{j}]: ");
//                } while (!int.TryParse(Console.ReadLine(), out value));
//                matrix[i, j] = value;
//            }
//        }

//        Console.WriteLine("\nSum of each row:");
//        for (int i = 0; i < 3; i++)
//        {
//            int rowSum = 0;
//            for (int j = 0; j < 3; j++)
//            {
//                rowSum += matrix[i, j];
//            }
//            Console.WriteLine($"Row {i} sum: {rowSum}");
//        }

//        Console.WriteLine("\nSum of each column:");
//        for (int j = 0; j < 3; j++)
//        {
//            int colSum = 0;
//            for (int i = 0; i < 3; i++)
//            {
//                colSum += matrix[i, j];
//            }
//            Console.WriteLine($"Column {j} sum: {colSum}");
//        }
//    }
//}
#endregion

#region Problem 6
//class Program
//{
//    static void Main()
//    {

//        int[][] jArray = new int[3][];
//        jArray[0] = new int[2];
//        jArray[1] = new int[4];
//        jArray[2] = new int[3];


//        for (int i = 0; i < jArray.Length; i++)
//        {
//            Console.WriteLine($"Enter {jArray[i].Length} values for row {i}:");
//            for (int j = 0; j < jArray[i].Length; j++)
//            {
//                int value;
//                while (!int.TryParse(Console.ReadLine(), out value))
//                {
//                    Console.WriteLine("Invalid input. Enter an integer:");
//                }
//        jArray[i][j] = value;
//            }
//        }

//// Print all values row by row
//        Console.WriteLine("\nJagged array values:");
//        for (int i = 0; i < jArray.Length; i++)
//        {
//            Console.Write($"Row {i}: ");
//            for (int j = 0; j < jArray[i].Length; j++)
//            {
//                Console.Write(jArray[i][j] + " ");
//            }
//            Console.WriteLine();
//        }
//    }
//}
#endregion

#region Problem 7 
//class Program
//{
//    static void Main()
//    {
//        string? userInput = null;

//        Console.Write("Enter your name: ");
//        string? input = Console.ReadLine();

//        if (!string.IsNullOrWhiteSpace(input))
//        {
//            userInput = input;  
//        }

//        Console.WriteLine($"Hello, {userInput!}!");


//    }
//}
#endregion

#region Problem 8 
//class Program
//{
//    static void Main()
//    {
//        int value = 42;           
//        object box = value; 
//        Console.WriteLine($"Boxed value: {box}");

//        try
//        {
//            int unbox = (int)box; 
//            Console.WriteLine($"Unboxed value: {unbox}");

//            string invalidCast = (string)box; 
//        }
//        catch (InvalidCastException ex)
//        {
//            Console.WriteLine($"Invalid cast detected: {ex.Message}");
//        }
//    }
//}
#endregion

#region Problem 9 
//class Program
//{
//    static void SumAndMultiply(int a, int b, out int sum, out int product)
//    {
//        sum = a + b;
//        product = a * b;
//    }

//    static void Main()
//    {
//        Console.Write("Enter first integer: ");
//        int x = int.Parse(Console.ReadLine()!);

//        Console.Write("Enter second integer: ");
//        int y = int.Parse(Console.ReadLine()!);

//        int sumResult, productResult;

//        SumAndMultiply(x, y, out sumResult, out productResult);

//        Console.WriteLine($"Sum: {sumResult}");
//        Console.WriteLine($"Product: {productResult}");
//    }
//}
#endregion

#region Problem 10 
//{
//    static void PrintMultipleTimes(string message, int times = 5)
//    {
//        for (int i = 0; i < times; i++)
//        {
//            Console.WriteLine(message);
//        }
//    }

//    static void Main()
//    {
//        PrintMultipleTimes("Hello");

//        Console.WriteLine();

//        PrintMultipleTimes("Hi", 3);

//        Console.WriteLine();

//        PrintMultipleTimes(times: 2, message: "gg");
//    }
//}
#endregion

#region Problem 11 
//{
//    static void Main()
//    {
//        int[]? numbers = null;

//        Console.WriteLine($"Length of array: {numbers?.Length}");

//        numbers = new int[] { 10, 20, 30 };

//        Console.WriteLine($"Length of array after assignment: {numbers?.Length}");
//        Console.WriteLine($"First element: {numbers?[0]}");
//    }
//}
#endregion

#region Problem 12 
//class Program
//{
//    static void Main()
//    {
//        Console.Write("Enter a day of the week: ");
//        string? dayInput = Console.ReadLine()?.Trim();

//        int dayNumber = dayInput?.ToLower() switch
//        {
//            "monday" => 1,
//            "tuesday" => 2,
//            "wednesday" => 3,
//            "thursday" => 4,
//            "friday" => 5,
//            "saturday" => 6,
//            "sunday" => 7,
//            _ => 0 
//        };

//        if (dayNumber == 0)
//            Console.WriteLine("Invalid day entered.");
//        else
//            Console.WriteLine($"{dayInput} corresponds to number {dayNumber}.");
//    }
//}
#endregion

#region Problem 13 
//class Program
//{
//    static int SumArray(params int[] numbers)
//    {
//        int sum = 0;
//        foreach (int num in numbers)
//        {
//            sum += num;
//        }
//        return sum;
//    }

//    static void Main()
//    {
//        int sum1 = SumArray(1, 2, 3, 4, 5);
//        Console.WriteLine($"Sum values: {sum1}");

//        int[] arrayValues = { 10, 20, 30 };
//        int sum2 = SumArray(arrayValues);
//        Console.WriteLine($"Sum values: {sum2}");
//    }
//}
#endregion

#region Problem 14 
//class Program
//{
//    static void Main()
//    {
//        Console.Write("Enter a positive integer: ");
//        int n = int.Parse(Console.ReadLine()!);

//        for (int i = 1; i <= n; i++)
//        {
//            Console.Write(i + (i < n ? ", " : ""));
//        }
//    }
//}
#endregion

#region Problem 15 
//class Program
//{
//    static void Main()
//    {
//        Console.Write("Enter an integer: ");
//        int n = int.Parse(Console.ReadLine()!);

//        for (int i = 1; i <= 12; i++)
//        {
//            Console.Write(n * i + (i < 12 ? ", " : ""));
//        }
//    }
//}
#endregion

#region Problem 16 
//{
//    static void Main()
//    {
//        Console.Write("Enter a number: ");
//        int n = int.Parse(Console.ReadLine()!);

//        for (int i = 2; i <= n; i += 2)
//        {
//            Console.Write(i + (i + 2 <= n ? ", " : ""));
//        }
//    }
////}
#endregion

#region Problem 17 
//class Program
//{
//    static void Main()
//    {
//        Console.Write("Enter base: ");
//        int baseNum = int.Parse(Console.ReadLine()!);
//        Console.Write("Enter exponent: ");
//        int exp = int.Parse(Console.ReadLine()!);

//        int result = 1;
//        for (int i = 0; i < exp; i++)
//        {
//            result *= baseNum;
//        }

//        Console.WriteLine(result);
//    }
//}
#endregion

#region Problem 18 
//class Program
//{
//    static void Main()
//    {
//        Console.Write("Enter a string: ");
//        string input = Console.ReadLine()!;
//        char[] arr = input.ToCharArray();
//        Array.Reverse(arr);
//        Console.WriteLine(new string(arr));
//    }
//}
#endregion

#region Problem 19 
//class Program
//{
//    static void Main()
//    {
//        Console.Write("Enter an integer: ");
//        int num = int.Parse(Console.ReadLine()!);
//        int reversed = 0;

//        while (num != 0)
//        {
//            reversed = reversed * 10 + num % 10;
//            num /= 10;
//        }

//        Console.WriteLine(reversed);
//    }
//}
#endregion

#region Problem 20 
//class Program
//{
//    static void Main()
//    {
//        Console.WriteLine("Enter array elements separated by spaces:");
//        string[] input = Console.ReadLine()!.Split(' ');
//        int[] arr = Array.ConvertAll(input, int.Parse);

//        int maxDistance = 0;

//        for (int i = 0; i < arr.Length; i++)
//        {
//            for (int j = i + 1; j < arr.Length; j++)
//            {
//                if (arr[i] == arr[j])
//                {
//                    int distance = j - i - 1;
//                    if (distance > maxDistance) maxDistance = distance;
//                }
//            }
//        }

//        Console.WriteLine($"Longest distance: {maxDistance}");
//    }
//}
#endregion

#region Problem 21 
//class Program
//{
//    static void Main()
//    {
//        Console.Write("Enter a sentence: ");
//        string sentence = Console.ReadLine()!;
//        string[] words = sentence.Split(' ');
//        Array.Reverse(words);
//        Console.WriteLine(string.Join(" ", words));
//    }
//}
#endregion