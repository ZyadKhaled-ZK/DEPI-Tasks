#region Problem 1
//using System;

//public interface IVehicle
//{
//    void StartEngine();
//    void StopEngine();
//}

//public class Car : IVehicle
//{
//    public void StartEngine()
//    {
//        Console.WriteLine("Car engine started.");
//    }

//    public void StopEngine()
//    {
//        Console.WriteLine("Car engine stopped.");
//    }
//}

//public class Bike : IVehicle
//{
//    public void StartEngine()
//    {
//        Console.WriteLine("Bike engine started.");
//    }

//    public void StopEngine()
//    {
//        Console.WriteLine("Bike engine stopped.");
//    }
//}

//class Program
//{
//    static void Main()
//    {
//        IVehicle car = new Car();
//        IVehicle bike = new Bike();

//        car.StartEngine();
//        car.StopEngine();

//        bike.StartEngine();
//        bike.StopEngine();
//    }
//}
#endregion

#region Problem 2-A
//using System;

//public abstract class Shape
//{
//    public abstract double GetArea();

//    public void Display()
//    {
//        Console.WriteLine($"Area: {GetArea():F2}");
//    }
//}

//public class Rectangle : Shape
//{
//    public double Width { get; }
//    public double Height { get; }

//    public Rectangle(double width, double height)
//    {
//        Width = width;
//        Height = height;
//    }

//    public override double GetArea()
//    {
//        return Width * Height;
//    }
//}

//public class Circle : Shape
//{
//    public double Radius { get; }

//    public Circle(double radius)
//    {
//        Radius = radius;
//    }

//    public override double GetArea()
//    {
//        return Math.PI * Radius * Radius;
//    }
//}

//class Program
//{
//    static void Main()
//    {
//        Shape rect = new Rectangle(5, 4);
//        Shape circle = new Circle(3);

//        rect.Display();
//        circle.Display();
//    }
//}
#endregion


#region Problem 2-B
//using System;

//public abstract class Shape
//{
//    // Abstract method (must be implemented by derived classes)
//    public abstract double GetArea();

//    // Non-abstract method (shared behavior)
//    public void Display()
//    {
//        Console.WriteLine($"Area: {GetArea():F2}");
//    }
//}

//public class Rectangle : Shape
//{
//    public double Width { get; }
//    public double Height { get; }

//    public Rectangle(double width, double height)
//    {
//        Width = width;
//        Height = height;
//    }

//    public override double GetArea()
//    {
//        return Width * Height;
//    }
//}

//public class Circle : Shape
//{
//    public double Radius { get; }

//    public Circle(double radius)
//    {
//        Radius = radius;
//    }

//    public override double GetArea()
//    {
//        return Math.PI * Radius * Radius;
//    }
//}

//class Program
//{
//    static void Main()
//    {
//        Shape rect = new Rectangle(5, 4);
//        Shape circle = new Circle(3);

//        rect.Display();
//        circle.Display();
//    }
//}


#endregion

#region Problem 3
//using System;

//public class Product : IComparable<Product>
//{
//    public int Id { get; set; }
//    public string Name { get; set; }
//    public double Price { get; set; }

//    public Product(int id, string name, double price)
//    {
//        Id = id;
//        Name = name;
//        Price = price;
//    }

//    public int CompareTo(Product other)
//    {
//        if (other == null) return 1;
//        return this.Price.CompareTo(other.Price);
//    }

//    public void Display()
//    {
//        Console.WriteLine($"ID: {Id}, Name: {Name}, Price: ${Price:F2}");
//    }
//}

//class Program
//{
//    static void Main()
//    {
//        Product[] products = new Product[]
//        {
//            new Product(1, "Laptop", 1200.50),
//            new Product(2, "Mouse", 25.99),
//            new Product(3, "Keyboard", 75.00),
//            new Product(4, "Monitor", 300.00),
//            new Product(5, "Headphones", 150.75)
//        };

//        Console.WriteLine("Products before sorting:");
//        foreach (var product in products)
//        {
//            product.Display();
//        }

//        Array.Sort(products);

//        Console.WriteLine("\nProducts after sorting by Price:");
//        foreach (var product in products)
//        {
//            product.Display();
//        }
//    }
//}
#endregion

#region Problem 4
//using System;

//public class Grade
//{
//    public double Score { get; set; }

//    public Grade(double score)
//    {
//        Score = score;
//    }
//}

//public class Student
//{
//    public int Id { get; set; }
//    public string Name { get; set; }
//    public Grade Grade { get; set; }

//    public Student(int id, string name, Grade grade)
//    {
//        Id = id;
//        Name = name;
//        Grade = grade;
//    }

//    public Student(Student other)
//    {
//        Id = other.Id;
//        Name = other.Name;
//        Grade = new Grade(other.Grade.Score);
//    }
//}

//class Program
//{
//    static void Main()
//    {
//        Student original = new Student(1, "Alice", new Grade(90));

//        Student shallowCopy = original;

//        Student deepCopy = new Student(original);

//        Console.WriteLine("Before modification:");
//        Console.WriteLine("Original Grade: " + original.Grade.Score);
//        Console.WriteLine("Shallow Grade: " + shallowCopy.Grade.Score);
//        Console.WriteLine("Deep Grade: " + deepCopy.Grade.Score);

//        original.Grade.Score = 75;

//        Console.WriteLine();
//        Console.WriteLine("After modifying original grade:");
//        Console.WriteLine("Original Grade: " + original.Grade.Score);
//        Console.WriteLine("Shallow Grade: " + shallowCopy.Grade.Score);
//        Console.WriteLine("Deep Grade: " + deepCopy.Grade.Score);
//    }
//}


#endregion

#region Problem 5
//using System;

//public interface IWalkable
//{
//    void Walk();
//}

//public class Robot : IWalkable
//{
//    public void Walk()
//    {
//        Console.WriteLine("Robot walking using internal navigation system.");
//    }

//    void IWalkable.Walk()
//    {
//        Console.WriteLine("Robot walking as an IWalkable entity.");
//    }
//}

//class Program
//{
//    static void Main()
//    {
//        Robot robot = new Robot();

//        robot.Walk();

//        IWalkable walkableRobot = robot;
//        walkableRobot.Walk();
//    }
//}


#endregion

#region Problem 6
//using System;

//public struct Account
//{
//    private int accountId;
//    private string accountHolder;
//    private decimal balance;

//    public int AccountId
//    {
//        get { return accountId; }
//        set { accountId = value; }
//    }

//    public string AccountHolder
//    {
//        get { return accountHolder; }
//        set { accountHolder = value; }
//    }

//    public decimal Balance
//    {
//        get { return balance; }
//        set
//        {
//            if (value >= 0)
//                balance = value;
//        }
//    }

//    public Account(int id, string holder, decimal initialBalance)
//    {
//        accountId = id;
//        accountHolder = holder;
//        balance = initialBalance >= 0 ? initialBalance : 0;
//    }
//}

//class Program
//{
//    static void Main()
//    {
//        Account account = new Account(101, "John Smith", 5000);

//        Console.WriteLine("Initial Account Details:");
//        Console.WriteLine("ID: " + account.AccountId);
//        Console.WriteLine("Holder: " + account.AccountHolder);
//        Console.WriteLine("Balance: " + account.Balance);

//        account.Balance = 3000;
//        Console.WriteLine("\nAfter updating balance:");
//        Console.WriteLine("Balance: " + account.Balance);

//        account.Balance = -1000;
//        Console.WriteLine("\nAfter attempting invalid update:");
//        Console.WriteLine("Balance: " + account.Balance);
//    }
//}


#endregion

#region Problem 7
//using System;

//public class Book
//{
//    public string Title { get; set; }
//    public string Author { get; set; }

//    public Book()
//    {
//        Title = "Unknown Title";
//        Author = "Unknown Author";
//    }

//    public Book(string title)
//    {
//        Title = title;
//        Author = "Unknown Author";
//    }

//    public Book(string title, string author)
//    {
//        Title = title;
//        Author = author;
//    }

//    public void Display()
//    {
//        Console.WriteLine("Title: " + Title + ", Author: " + Author);
//    }
//}

//class Program
//{
//    static void Main()
//    {
//        Book book1 = new Book();
//        Book book2 = new Book("1984");
//        Book book3 = new Book("Clean Code", "Robert C. Martin");

//        Console.WriteLine("Book created using default constructor:");
//        book1.Display();

//        Console.WriteLine();

//        Console.WriteLine("Book created using constructor with Title only:");
//        book2.Display();

//        Console.WriteLine();

//        Console.WriteLine("Book created using constructor with Title and Author:");
//        book3.Display();
//    }
//}


#endregion

#region Problem 8
//using System;

//public interface ILogger
//{
//    // Default implementation in interface (C# 8.0+)
//    void Log(string message)
//    {
//        Console.WriteLine($"[DEFAULT LOG] {DateTime.Now}: {message}");
//    }
//}

//public class ConsoleLogger : ILogger
//{
//    // Override the default implementation
//    public void Log(string message)
//    {
//        Console.WriteLine($"[CONSOLE] {DateTime.Now:HH:mm:ss} - {message}");
//    }
//}

//public class FileLogger : ILogger
//{
//    // Uses default implementation (no override)
//}

//class Program
//{
//    static void Main()
//    {
//        Console.WriteLine("Testing ConsoleLogger (overridden implementation):");
//        ILogger consoleLogger = new ConsoleLogger();
//        consoleLogger.Log("This is a custom console log message");

//        Console.WriteLine("\nTesting FileLogger (default implementation):");
//        ILogger fileLogger = new FileLogger();
//        fileLogger.Log("This uses the default interface implementation");
//    }
//}


#endregion

#region Part 2 problem 1
//using System;
//using System.Collections.Generic;

//public interface IShapeSeries
//{
//    int CurrentShapeArea { get; set; }
//    void GetNextArea();
//    void ResetSeries();
//}

//public class SquareSeries : IShapeSeries
//{
//    private int side = 0;
//    public int CurrentShapeArea { get; set; }

//    public void GetNextArea()
//    {
//        side++;
//        CurrentShapeArea = side * side;
//    }

//    public void ResetSeries()
//    {
//        side = 0;
//        CurrentShapeArea = 0;
//    }
//}

//public class CircleSeries : IShapeSeries
//{
//    private int radius = 0;
//    public int CurrentShapeArea { get; set; }

//    public void GetNextArea()
//    {
//        radius++;
//        CurrentShapeArea = (int)(Math.PI * radius * radius);
//    }

//    public void ResetSeries()
//    {
//        radius = 0;
//        CurrentShapeArea = 0;
//    }
//}

//public class Shape : IComparable<Shape>
//{
//    public string Name { get; set; }
//    public double Area { get; set; }

//    public int CompareTo(Shape other)
//    {
//        return Area.CompareTo(other.Area);
//    }
//}

//public abstract class GeometricShape
//{
//    public double Dimension1 { get; set; }
//    public double Dimension2 { get; set; }

//    public GeometricShape(double d1, double d2)
//    {
//        Dimension1 = d1;
//        Dimension2 = d2;
//    }

//    public abstract double CalculateArea();
//    public abstract double Perimeter { get; }
//}

//public class Triangle : GeometricShape
//{
//    public Triangle(double d1, double d2) : base(d1, d2) { }

//    public override double CalculateArea()
//    {
//        return 0.5 * Dimension1 * Dimension2;
//    }

//    public override double Perimeter
//    {
//        get { return Dimension1 + Dimension2 + Math.Sqrt(Dimension1 * Dimension1 + Dimension2 * Dimension2); }
//    }
//}

//public class Rectangle : GeometricShape
//{
//    public Rectangle(double d1, double d2) : base(d1, d2) { }

//    public override double CalculateArea()
//    {
//        return Dimension1 * Dimension2;
//    }

//    public override double Perimeter
//    {
//        get { return 2 * (Dimension1 + Dimension2); }
//    }
//}

//public static class ShapeFactory
//{
//    public static GeometricShape CreateShape(string shapeType, double dim1, double dim2)
//    {
//        switch (shapeType.ToLower())
//        {
//            case "rectangle":
//                return new Rectangle(dim1, dim2);
//            case "triangle":
//                return new Triangle(dim1, dim2);
//            default:
//                throw new ArgumentException("Invalid shape type");
//        }
//    }
//}

//class Program
//{
//    static void PrintTenShapes(IShapeSeries series)
//    {
//        series.ResetSeries();
//        for (int i = 0; i < 10; i++)
//        {
//            series.GetNextArea();
//            Console.WriteLine(series.CurrentShapeArea);
//        }
//    }

//    public static void SelectionSort(int[] numbers)
//    {
//        for (int i = 0; i < numbers.Length - 1; i++)
//        {
//            int minIndex = i;
//            for (int j = i + 1; j < numbers.Length; j++)
//            {
//                if (numbers[j] < numbers[minIndex])
//                    minIndex = j;
//            }
//            int temp = numbers[i];
//            numbers[i] = numbers[minIndex];
//            numbers[minIndex] = temp;
//        }
//    }

//    static void Main()
//    {
//        Console.WriteLine("Square Series:");
//        PrintTenShapes(new SquareSeries());

//        Console.WriteLine("\nCircle Series:");
//        PrintTenShapes(new CircleSeries());

//        List<Shape> shapes = new List<Shape>
//        {
//            new Shape { Name = "Square", Area = 16 },
//            new Shape { Name = "Circle", Area = 28.27 },
//            new Shape { Name = "Rectangle", Area = 20 },
//            new Shape { Name = "Triangle", Area = 10 }
//        };

//        Shape[] shapeArray = shapes.ToArray();
//        Array.Sort(shapeArray);

//        Console.WriteLine("\nSorted Shapes by Area:");
//        foreach (var s in shapeArray)
//            Console.WriteLine(s.Name + " - " + s.Area);

//        GeometricShape rect = ShapeFactory.CreateShape("rectangle", 5, 4);
//        GeometricShape tri = ShapeFactory.CreateShape("triangle", 6, 3);

//        Console.WriteLine("\nGeometric Shapes:");
//        Console.WriteLine("Rectangle Area: " + rect.CalculateArea() + ", Perimeter: " + rect.Perimeter);
//        Console.WriteLine("Triangle Area: " + tri.CalculateArea() + ", Perimeter: " + tri.Perimeter);

//        int[] areas = new int[shapeArray.Length];
//        for (int i = 0; i < shapeArray.Length; i++)
//            areas[i] = (int)shapeArray[i].Area;

//        SelectionSort(areas);

//        Console.WriteLine("\nAreas Sorted Using SelectionSort:");
//        foreach (int a in areas)
//            Console.WriteLine(a);
//    }
//}
#endregion