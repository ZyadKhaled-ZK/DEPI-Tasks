using System;

#region Problem 1

//enum Weekdays
//{
//    Monday = 1,
//    Tuesday,
//    Wednesday,
//    Thursday,
//    Friday
//}

//class Problem1
//{
//    static void Main(string[] args)
//    {
//        foreach (Weekdays day in Enum.GetValues(typeof(Weekdays)))
//        {
//            Console.WriteLine($"{day} = {(int)day}");
//        }
//    }
//}

#endregion

#region Problem 2

//enum Grades : short
//{
//    A = 90,
//    B = 80,
//    C = 70,
//    D = 60,
//    F = -1
//}

//class Problem2
//{
//    static void Main(string[] args)
//    {
//        foreach (Grades grade in Enum.GetValues(typeof(Grades)))
//        {
//            Console.WriteLine($"{grade} = {(short)grade}");
//        }
//    }
//}

#endregion

#region Problem 3

//class Department
//{
//    public string Name { get; set; }

//    public Department(string name)
//    {
//        Name = name;
//    }

//    public override string ToString()
//    {
//        return Name;
//    }
//}

//class Person
//{
//    public string Name { get; set; }
//    public int Age { get; set; }
//    public Department Department { get; set; }

//    public Person(string name, int age, Department department)
//    {
//        Name = name;
//        Age = age;
//        Department = department;
//    }

//    public override string ToString()
//    {
//        return $"Name: {Name}, Age: {Age}, Department: {Department}";
//    }
//}

//class Problem3
//{
//    static void Main(string[] args)
//    {
//        Person person1 = new Person("John", 30, new Department("IT"));
//        Person person2 = new Person("Sarah", 25, new Department("HR"));

//        Console.WriteLine(person1);
//        Console.WriteLine(person2);
//    }
//}

#endregion

#region Problem 4

//class Department
//{
//    public string Name { get; set; }

//    public Department(string name)
//    {
//        Name = name;
//    }

//    public override string ToString()
//    {
//        return Name;
//    }
//}

//class Person
//{
//    public string Name { get; set; }
//    public int Age { get; set; }
//    public Department Department { get; set; }
//    public virtual double Salary { get; set; }

//    public Person(string name, int age, Department department)
//    {
//        Name = name;
//        Age = age;
//        Department = department;
//    }
//}

//class Child : Person
//{
//    public sealed override double Salary { get; set; }

//    public Child(string name, int age, Department department, double salary)
//        : base(name, age, department)
//    {
//        Salary = salary;
//    }

//    public void DisplaySalary()
//    {
//        Console.WriteLine($"Salary: {Salary}");
//    }
//}

//class Problem4
//{
//    static void Main(string[] args)
//    {
//        Child child = new Child("Mike", 12, new Department("Student"), 500);
//        child.DisplaySalary();
//    }
//}

#endregion

#region Problem 5

//static class Utility
//{
//    public static double CalculateRectanglePerimeter(double length, double width)
//    {
//        return 2 * (length + width);
//    }
//}

//class Problem5
//{
//    static void Main(string[] args)
//    {
//        double perimeter = Utility.CalculateRectanglePerimeter(5, 10);
//        Console.WriteLine($"Perimeter: {perimeter}");
//    }
//}

#endregion

#region Problem 6

//class ComplexNumber
//{
//    public double Real { get; set; }
//    public double Imaginary { get; set; }

//    public ComplexNumber(double real, double imaginary)
//    {
//        Real = real;
//        Imaginary = imaginary;
//    }

//    public static ComplexNumber operator *(ComplexNumber c1, ComplexNumber c2)
//    {
//        double real = c1.Real * c2.Real - c1.Imaginary * c2.Imaginary;
//        double imaginary = c1.Real * c2.Imaginary + c1.Imaginary * c2.Real;
//        return new ComplexNumber(real, imaginary);
//    }

//    public override string ToString()
//    {
//        return $"{Real} + {Imaginary}i";
//    }
//}

//class Problem6
//{
//    static void Main(string[] args)
//    {
//        ComplexNumber c1 = new ComplexNumber(3, 2);
//        ComplexNumber c2 = new ComplexNumber(1, 4);
//        ComplexNumber result = c1 * c2;
//        Console.WriteLine($"{c1} * {c2} = {result}");
//    }
//}

#endregion

#region Problem 7

//enum Gender : byte
//{
//    Male = 0,
//    Female = 1,
//    Other = 2
//}

//class Problem7
//{
//    static void Main(string[] args)
//    {
//        Console.WriteLine($"Gender enum underlying type: byte");
//        Console.WriteLine($"Size of byte: {sizeof(byte)} byte(s)");
//        Console.WriteLine($"Size of int: {sizeof(int)} byte(s)");
//        Console.WriteLine($"Memory saved per enum value: {sizeof(int) - sizeof(byte)} byte(s)");
//    }
//}

#endregion

#region Problem 8

//static class Utility
//{
//    public static double CelsiusToFahrenheit(double celsius)
//    {
//        return (celsius * 9 / 5) + 32;
//    }

//    public static double FahrenheitToCelsius(double fahrenheit)
//    {
//        return (fahrenheit - 32) * 5 / 9;
//    }
//}

//class Problem8
//{
//    static void Main(string[] args)
//    {
//        double celsius = 25;
//        double fahrenheit = Utility.CelsiusToFahrenheit(celsius);
//        Console.WriteLine($"{celsius}°C = {fahrenheit}°F");

//        double fahrenheit2 = 77;
//        double celsius2 = Utility.FahrenheitToCelsius(fahrenheit2);
//        Console.WriteLine($"{fahrenheit2}°F = {celsius2}°C");
//    }
//}

#endregion

#region Problem 9

//enum Grades : short
//{
//    A = 90,
//    B = 80,
//    C = 70,
//    D = 60,
//    F = -1
//}

//class Problem9
//{
//    static void Main(string[] args)
//    {
//        string input1 = "A";
//        string input2 = "X";

//        Grades grade1;
//        if (Enum.TryParse(input1, out grade1))
//        {
//            Console.WriteLine($"Successfully parsed '{input1}' to {grade1}");
//        }
//        else
//        {
//            Console.WriteLine($"Failed to parse '{input1}'");
//        }

//        Grades grade2;
//        if (Enum.TryParse(input2, out grade2))
//        {
//            Console.WriteLine($"Successfully parsed '{input2}' to {grade2}");
//        }
//        else
//        {
//            Console.WriteLine($"Failed to parse '{input2}'");
//        }
//    }
//}

#endregion

#region Problem 10

//class Department
//{
//    public string Name { get; set; }

//    public Department(string name)
//    {
//        Name = name;
//    }

//    public override bool Equals(object obj)
//    {
//        if (obj == null || !(obj is Department))
//            return false;

//        Department other = (Department)obj;
//        return Name == other.Name;
//    }

//    public override int GetHashCode()
//    {
//        return Name.GetHashCode();
//    }

//    public override string ToString()
//    {
//        return Name;
//    }
//}

//class Employee
//{
//    public int Id { get; set; }
//    public string Name { get; set; }
//    public Department Department { get; set; }

//    public Employee(int id, string name, Department department)
//    {
//        Id = id;
//        Name = name;
//        Department = department;
//    }

//    public override bool Equals(object obj)
//    {
//        if (obj == null || !(obj is Employee))
//            return false;

//        Employee other = (Employee)obj;
//        return Id == other.Id && Name == other.Name;
//    }

//    public override int GetHashCode()
//    {
//        return Id.GetHashCode() ^ Name.GetHashCode();
//    }

//    public override string ToString()
//    {
//        return $"ID: {Id}, Name: {Name}, Department: {Department}";
//    }
//}

//class Helper2<T>
//{
//    public static int SearchArray(T[] array, T value)
//    {
//        for (int i = 0; i < array.Length; i++)
//        {
//            if (array[i].Equals(value))
//                return i;
//        }
//        return -1;
//    }
//}

//class Problem10
//{
//    static void Main(string[] args)
//    {
//        Employee[] employees = new Employee[]
//        {
//            new Employee(1, "John", new Department("IT")),
//            new Employee(2, "Sarah", new Department("HR")),
//            new Employee(3, "Mike", new Department("IT"))
//        };

//        Employee searchEmployee = new Employee(2, "Sarah", new Department("HR"));
//        int index = Helper2<Employee>.SearchArray(employees, searchEmployee);

//        if (index != -1)
//        {
//            Console.WriteLine($"Employee found at index {index}: {employees[index]}");
//        }
//        else
//        {
//            Console.WriteLine("Employee not found");
//        }
//    }
//}

#endregion

#region Problem 11

//class Helper
//{
//    public static T Max<T>(T a, T b) where T : IComparable<T>
//    {
//        return a.CompareTo(b) > 0 ? a : b;
//    }
//}

//class Problem11
//{
//    static void Main(string[] args)
//    {
//        Console.WriteLine($"Max(10, 20) = {Helper.Max(10, 20)}");
//        Console.WriteLine($"Max(3.5, 2.1) = {Helper.Max(3.5, 2.1)}");
//        Console.WriteLine($"Max(\"apple\", \"banana\") = {Helper.Max("apple", "banana")}");
//    }
//}

#endregion

#region Problem 12

//class Helper2<T>
//{
//    public static void ReplaceArray(T[] array, T oldValue, T newValue)
//    {
//        for (int i = 0; i < array.Length; i++)
//        {
//            if (array[i].Equals(oldValue))
//            {
//                array[i] = newValue;
//            }
//        }
//    }
//}

//class Problem12
//{
//    static void Main(string[] args)
//    {
//        int[] intArray = { 1, 2, 3, 2, 5 };
//        Console.WriteLine("Original int array: " + string.Join(", ", intArray));
//        Helper2<int>.ReplaceArray(intArray, 2, 99);
//        Console.WriteLine("After replacing 2 with 99: " + string.Join(", ", intArray));

//        string[] stringArray = { "apple", "banana", "apple", "orange" };
//        Console.WriteLine("Original string array: " + string.Join(", ", stringArray));
//        Helper2<string>.ReplaceArray(stringArray, "apple", "grape");
//        Console.WriteLine("After replacing 'apple' with 'grape': " + string.Join(", ", stringArray));
//    }
//}

#endregion

#region Problem 13

//struct Rectangle
//{
//    public double Length { get; set; }
//    public double Width { get; set; }

//    public Rectangle(double length, double width)
//    {
//        Length = length;
//        Width = width;
//    }

//    public override string ToString()
//    {
//        return $"Length: {Length}, Width: {Width}";
//    }
//}

//class RectangleHelper
//{
//    public static void Swap(ref Rectangle r1, ref Rectangle r2)
//    {
//        Rectangle temp = r1;
//        r1 = r2;
//        r2 = temp;
//    }
//}

//class Problem13
//{
//    static void Main(string[] args)
//    {
//        Rectangle rect1 = new Rectangle(5, 10);
//        Rectangle rect2 = new Rectangle(3, 7);

//        Console.WriteLine($"Before swap: rect1 = {rect1}, rect2 = {rect2}");
//        RectangleHelper.Swap(ref rect1, ref rect2);
//        Console.WriteLine($"After swap: rect1 = {rect1}, rect2 = {rect2}");
//    }
//}

#endregion

#region Problem 14

//class Department
//{
//    public string Name { get; set; }

//    public Department(string name)
//    {
//        Name = name;
//    }

//    public override bool Equals(object obj)
//    {
//        if (obj == null || !(obj is Department))
//            return false;

//        Department other = (Department)obj;
//        return Name == other.Name;
//    }

//    public override int GetHashCode()
//    {
//        return Name.GetHashCode();
//    }

//    public override string ToString()
//    {
//        return Name;
//    }
//}

//class Employee
//{
//    public int Id { get; set; }
//    public string Name { get; set; }
//    public Department Department { get; set; }

//    public Employee(int id, string name, Department department)
//    {
//        Id = id;
//        Name = name;
//        Department = department;
//    }

//    public override string ToString()
//    {
//        return $"ID: {Id}, Name: {Name}, Department: {Department}";
//    }
//}

//class Helper2<T>
//{
//    public static int SearchArray(T[] array, T value)
//    {
//        for (int i = 0; i < array.Length; i++)
//        {
//            if (array[i].Equals(value))
//                return i;
//        }
//        return -1;
//    }
//}

//class Problem14
//{
//    static void Main(string[] args)
//    {
//        Employee[] employees = new Employee[]
//        {
//            new Employee(1, "John", new Department("IT")),
//            new Employee(2, "Sarah", new Department("HR")),
//            new Employee(3, "Mike", new Department("IT"))
//        };

//        Department searchDept = new Department("IT");
//        Console.WriteLine($"Searching for employees in department: {searchDept}");

//        for (int i = 0; i < employees.Length; i++)
//        {
//            if (employees[i].Department.Equals(searchDept))
//            {
//                Console.WriteLine($"Found: {employees[i]}");
//            }
//        }
//    }
//}

#endregion

#region Problem 15

//struct Circle
//{
//    public double Radius { get; set; }
//    public string Color { get; set; }

//    public Circle(double radius, string color)
//    {
//        Radius = radius;
//        Color = color;
//    }

//    public override bool Equals(object obj)
//    {
//        if (!(obj is Circle))
//            return false;

//        Circle other = (Circle)obj;
//        return Radius == other.Radius && Color == other.Color;
//    }

//    public override int GetHashCode()
//    {
//        return Radius.GetHashCode() ^ Color.GetHashCode();
//    }

//    public override string ToString()
//    {
//        return $"Radius: {Radius}, Color: {Color}";
//    }
//}

//class CircleClass
//{
//    public double Radius { get; set; }
//    public string Color { get; set; }

//    public CircleClass(double radius, string color)
//    {
//        Radius = radius;
//        Color = color;
//    }

//    public override bool Equals(object obj)
//    {
//        if (obj == null || !(obj is CircleClass))
//            return false;

//        CircleClass other = (CircleClass)obj;
//        return Radius == other.Radius && Color == other.Color;
//    }

//    public override int GetHashCode()
//    {
//        return Radius.GetHashCode() ^ Color.GetHashCode();
//    }

//    public override string ToString()
//    {
//        return $"Radius: {Radius}, Color: {Color}";
//    }
//}

//class Problem15
//{
//    static void Main(string[] args)
//    {
//        Circle circle1 = new Circle(5.0, "Red");
//        Circle circle2 = new Circle(5.0, "Red");

//        Console.WriteLine("Struct Comparison:");
//        Console.WriteLine($"circle1.Equals(circle2): {circle1.Equals(circle2)}");

//        CircleClass circleClass1 = new CircleClass(5.0, "Red");
//        CircleClass circleClass2 = new CircleClass(5.0, "Red");

//        Console.WriteLine("Class Comparison:");
//        Console.WriteLine($"circleClass1.Equals(circleClass2): {circleClass1.Equals(circleClass2)}");
//        Console.WriteLine($"circleClass1 == circleClass2: {circleClass1 == circleClass2}");
//    }
//}

#endregion

#region Part 2 - Problem 1

//class ArrayHelper
//{
//    public static T[] ReverseArray<T>(T[] array)
//    {
//        T[] reversed = new T[array.Length];
//        for (int i = 0; i < array.Length; i++)
//        {
//            reversed[i] = array[array.Length - 1 - i];
//        }
//        return reversed;
//    }
//}

//class Part 2 - Problem 1
//{
//    static void Main(string[] args)
//    {
//        int[] intArray = { 1, 2, 3, 4, 5 };
//        Console.WriteLine("Original int array: " + string.Join(", ", intArray));
//        int[] reversedInt = ArrayHelper.ReverseArray(intArray);
//        Console.WriteLine("Reversed int array: " + string.Join(", ", reversedInt));

//        string[] stringArray = { "apple", "banana", "cherry" };
//        Console.WriteLine("Original string array: " + string.Join(", ", stringArray));
//        string[] reversedString = ArrayHelper.ReverseArray(stringArray);
//        Console.WriteLine("Reversed string array: " + string.Join(", ", reversedString));
//    }
//}

#endregion

#region Part 2 - Problem 2

//class Stack<T>
//{
//    private T[] items;
//    private int top;

//    public Stack(int capacity)
//    {
//        items = new T[capacity];
//        top = -1;
//    }

//    public void Push(T item)
//    {
//        if (top == items.Length - 1)
//        {
//            Console.WriteLine("Stack is full");
//            return;
//        }
//        items[++top] = item;
//    }

//    public T Pop()
//    {
//        if (top == -1)
//        {
//            Console.WriteLine("Stack is empty");
//            return default(T);
//        }
//        return items[top--];
//    }

//    public T Peek()
//    {
//        if (top == -1)
//        {
//            Console.WriteLine("Stack is empty");
//            return default(T);
//        }
//        return items[top];
//    }

//    public bool IsEmpty()
//    {
//        return top == -1;
//    }
//}

//class Part 2 - Problem 3
//{
//    static void Main(string[] args)
//    {
//        Stack<int> intStack = new Stack<int>(5);
//        intStack.Push(10);
//        intStack.Push(20);
//        intStack.Push(30);

//        Console.WriteLine($"Peek: {intStack.Peek()}");
//        Console.WriteLine($"Pop: {intStack.Pop()}");
//        Console.WriteLine($"Pop: {intStack.Pop()}");

//        Stack<string> stringStack = new Stack<string>(3);
//        stringStack.Push("Hello");
//        stringStack.Push("World");

//        Console.WriteLine($"Peek: {stringStack.Peek()}");
//        Console.WriteLine($"Pop: {stringStack.Pop()}");
//    }
//}

#endregion

#region Part 2 - Problem 3

//class ArrayHelper
//{
//    public static void SwapElements<T>(T[] array, int index1, int index2)
//    {
//        if (index1 < 0 || index1 >= array.Length || index2 < 0 || index2 >= array.Length)
//        {
//            Console.WriteLine("Invalid indices");
//            return;
//        }

//        T temp = array[index1];
//        array[index1] = array[index2];
//        array[index2] = temp;
//    }
//}

//class Problem18
//{
//    static void Main(string[] args)
//    {
//        int[] intArray = { 1, 2, 3, 4, 5 };
//        Console.WriteLine("Before swap: " + string.Join(", ", intArray));
//        ArrayHelper.SwapElements(intArray, 1, 3);
//        Console.WriteLine("After swap: " + string.Join(", ", intArray));

//        string[] stringArray = { "apple", "banana", "cherry", "date" };
//        Console.WriteLine("Before swap: " + string.Join(", ", stringArray));
//        ArrayHelper.SwapElements(stringArray, 0, 2);
//        Console.WriteLine("After swap: " + string.Join(", ", stringArray));
//    }
//}

#endregion

#region Part 2 - Problem 4

//class ArrayHelper
//{
//    public static T FindMax<T>(T[] array) where T : IComparable<T>
//    {
//        if (array == null || array.Length == 0)
//        {
//            throw new ArgumentException("Array cannot be null or empty");
//        }

//        T max = array[0];
//        for (int i = 1; i < array.Length; i++)
//        {
//            if (array[i].CompareTo(max) > 0)
//            {
//                max = array[i];
//            }
//        }
//        return max;
//    }
//}

//class Part 2 - Problem 4
//{
//    static void Main(string[] args)
//    {
//        int[] intArray = { 3, 7, 2, 9, 1 };
//        Console.WriteLine($"Max integer: {ArrayHelper.FindMax(intArray)}");

//        double[] doubleArray = { 3.5, 7.2, 2.1, 9.8, 1.4 };
//        Console.WriteLine($"Max double: {ArrayHelper.FindMax(doubleArray)}");

//        string[] stringArray = { "apple", "banana", "cherry", "date" };
//        Console.WriteLine($"Max string: {ArrayHelper.FindMax(stringArray)}");
//    }
//}

#endregion