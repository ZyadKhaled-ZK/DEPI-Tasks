#region Problem 1
//using System;

//class Car
//{

//    public int Id { get; set; }
//    public string Brand { get; set; }
//    public double Price { get; set; }


//    public Car()
//    {
//        Id = 0;
//        Brand = "Unknown";
//        Price = 0.0;
//    }


//    public Car(int id)
//    {
//        Id = id;
//        Brand = "Unknown";
//        Price = 0.0;
//    }


//    public Car(int id, string brand)
//    {
//        Id = id;
//        Brand = brand;
//        Price = 0.0;
//    }


//    public Car(int id, string brand, double price)
//    {
//        Id = id;
//        Brand = brand;
//        Price = price;
//    }


//    public void Display()
//    {
//        Console.WriteLine($"Id: {Id}, Brand: {Brand}, Price: {Price}");
//    }
//}

//class Program
//{
//    static void Main()
//    {

//        Car car1 = new Car();
//        Car car2 = new Car(1);
//        Car car3 = new Car(2, "Toyota");
//        Car car4 = new Car(3, "BMW", 45000);

//        car1.Display();
//        car2.Display();
//        car3.Display();
//        car4.Display();
//    }
//}
#endregion
#region Problem 2
//using System;

//class Calculator
//{
//    public int Sum(int a, int b)
//    {
//        return a + b;
//    }

//    public int Sum(int a, int b, int c)
//    {
//        return a + b + c;
//    }

//    public double Sum(double a, double b)
//    {
//        return a + b;
//    }
//}

//class Program
//{
//    static void Main()
//    {
//        Calculator calc = new Calculator();

//        int result1 = calc.Sum(5, 10);            
//        int result2 = calc.Sum(3, 4, 5);         
//        double result3 = calc.Sum(2.5, 3.7);     

//        Console.WriteLine($"Sum of two integers: {result1}");
//        Console.WriteLine($"Sum of three integers:{result2}");
//        Console.WriteLine($"Sum of two doubles: {result3}");
//    }
//}

#endregion
#region Problem 3
//using System;

//class Parent
//{
//    public int X { get; set; }
//    public int Y { get; set; }

//    public Parent(int x, int y)
//    {
//        X = x;
//        Y = y;
//    }
//}

//class Child : Parent
//{
//    public int Z { get; set; }

//    public Child(int x, int y, int z) : base(x, y)
//    {
//        Z = z;
//    }

//    public void Display()
//    {
//        Console.WriteLine($"X: {X}, Y: {Y}, Z: {Z}");
//    }
//}

//class Program
//{
//    static void Main()
//    {
//        Child child = new Child(10, 20, 30);

//        child.Display();
//    }
//}

#endregion
#region Problem 4
//using System;

//class Parent
//{
//    public int X { get; set; }
//    public int Y { get; set; }

//    public Parent(int x, int y)
//    {
//        X = x;
//        Y = y;
//    }

//    public virtual int Product()
//    {
//        return X * Y;
//    }
//}

//class ChildNew : Parent
//{
//    public int Z { get; set; }

//    public ChildNew(int x, int y, int z) : base(x, y)
//    {
//        Z = z;
//    }

//    public new int Product()
//    {
//        return X * Y * Z;
//    }
//}

//class ChildOverride : Parent
//{
//    public int Z { get; set; }

//    public ChildOverride(int x, int y, int z) : base(x, y)
//    {
//        Z = z;
//    }

//    // Overrides Parent.Product()
//    public override int Product()
//    {
//        return X * Y * Z;
//    }
//}

//class Program
//{
//    static void Main()
//    {
//        // Using 'new'
//        Parent p1 = new ChildNew(2, 3, 4);
//        ChildNew c1 = new ChildNew(2, 3, 4);

//        Console.WriteLine("Using new keyword:");
//        Console.WriteLine("Parent reference: " + p1.Product()); 
//        Console.WriteLine("Child reference: " + c1.Product());  

//        Console.WriteLine();

//        // Using 'override'
//        Parent p2 = new ChildOverride(2, 3, 4);
//        ChildOverride c2 = new ChildOverride(2, 3, 4);

//        Console.WriteLine("Using override keyword:");
//        Console.WriteLine("Parent reference: " + p2.Product()); 
//        Console.WriteLine("Child reference: " + c2.Product()); 
//}

#endregion
#region Problem 5
//using System;

//class Parent
//{
//    public int X { get; set; }
//    public int Y { get; set; }

//    public Parent(int x, int y)
//    {
//        X = x;
//        Y = y;
//    }

//    public override string ToString()
//    {
//        return $"({X}, {Y})";
//    }
//}

//class Child : Parent
//{
//    public int Z { get; set; }

//    public Child(int x, int y, int z) : base(x, y)
//    {
//        Z = z;
//    }

//    public override string ToString()
//    {
//        return $"({X}, {Y}, {Z})";
//    }
//}

//class Program
//{
//    static void Main()
//    {
//        Parent p = new Parent(5, 10);
//        Parent c = new Child(1, 2, 3); 

//        Console.WriteLine("Parent object: " + p.ToString());
//        Console.WriteLine("Child object (as Parent reference): " + c.ToString());
//    }
//}

#endregion
#region Problem 6
//using System;

//interface IShape
//{
//    double Area { get; }   
//    void Draw();           
//}

//class Rectangle : IShape
//{
//    public double Width { get; set; }
//    public double Height { get; set; }

//    public Rectangle(double width, double height)
//    {
//        Width = width;
//        Height = height;
//    }

//    public double Area
//    {
//        get { return Width * Height; }
//    }

//    public void Draw()
//    {
//        Console.WriteLine("Drawing a rectangle.");
//    }
//}

//class Program
//{
//    static void Main()
//    {
    
//        IShape rect = new Rectangle(5, 3);

//        rect.Draw();
//        Console.WriteLine("Area: " + rect.Area);
//    }
//}

#endregion
#region Problem 7
//using System;

//interface IShape
//{
//    double Area { get; }
//    void Draw();

   
//    void PrintDetails()
//    {
//        Console.WriteLine("Shape details:");
//        Console.WriteLine("Area = " + Area);
//    }
//}

//class Circle : IShape
//{
//    public double Radius { get; set; }

//    public Circle(double radius)
//    {
//        Radius = radius;
//    }

//    public double Area
//    {
//        get { return Math.PI * Radius * Radius; }
//    }

//    public void Draw()
//    {
//        Console.WriteLine("Drawing a circle.");
//    }
//}

//class Program
//{
//    static void Main()
//    {
//        IShape circle = new Circle(4);

//        circle.Draw();
//        circle.PrintDetails();
//    }
//}

#endregion
#region Problem 8
//using System;

//interface IMovable
//{
//    void Move();
//}

//class Car : IMovable
//{
//    public string Brand { get; set; }

//    public Car(string brand)
//    {
//        Brand = brand;
//    }

//    public void Move()
//    {
//        Console.WriteLine($"{Brand} car is moving.");
//    }
//}

//class Program
//{
//    static void Main()
//    {
//        Car myCar = new Car("Toyota");

//        IMovable movableCar = myCar;

//        movableCar.Move();
//    }
//}

#endregion
#region Problem 9
//using System;

//interface IReadable
//{
//    void Read();
//}


//interface IWritable
//{
//    void Write();
//}


//class File : IReadable, IWritable
//{
//    public string FileName { get; set; }

//    public File(string fileName)
//    {
//        FileName = fileName;
//    }

   
//    public void Read()
//    {
//        Console.WriteLine($"Reading from file: {FileName}");
//    }

//    public void Write()
//    {
//        Console.WriteLine($"Writing to file: {FileName}");
//    }
//}

//class Program
//{
//    static void Main()
//    {
//        File myFile = new File("gg.txt");

//        myFile.Read();
//        myFile.Write();

//        IReadable readable = myFile;
//        IWritable writable = myFile;

//        readable.Read();
//        writable.Write();
//    }
//}

#endregion
#region Problem 10



#endregion