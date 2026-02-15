#region Problem 1

//using System;

//public struct Point
//{
//    public int X { get; set; }
//    public int Y { get; set; }

//    public Point(int x, int y)
//    {
//        X = x;
//        Y = y;
//    }

//    public override string ToString()
//    {
//        return $"({X}, {Y})";
//    }
//}

//class Program
//{
//    static void Main()
//    {
//        Point p1 = new Point();
//        Console.WriteLine(p1);

//        Point p2 = new Point(3, 5);
//        Console.WriteLine(p2);
//    }
//}

#endregion

#region Problem 2

//using System;
//using gg;


//class Program
//{
//    static void Main()
//    {
//        TypeA obj = new TypeA(1, 2, 3);

//        Console.WriteLine("F = " + obj.GetF());

//        Console.WriteLine("G = " + obj.G);

//        Console.WriteLine("H = " + obj.H);
//    }
//}
#endregion

#region Problem 3
//using System;

//public struct Employee
//{
//    private int empid;
//    private string name;
//    private double salary;

//    public Employee(int id, string name, double salary)
//    {
//        this.empid = id;
//        this.name = name;
//        this.salary = salary;
//    }

//    public int empidprop
//    {
//        get { return empid; }
//        set { empid = value; }
//    }

//    public double salaryprop
//    {
//        get { return salary; }
//        set
//        {
//            if (value >= 0)
//                salary = value;
//        }
//    }

//    public string getname()
//    {
//        return name;
//    }

//    public void setname(string newname)
//    {
//        if (!string.IsNullOrWhiteSpace(newname))
//            name = newname;
//    }

//    public void display()
//    {
//        Console.WriteLine($"id: {empid}, name: {name}, salary: {salary}");
//    }
//}

//class Program
//{
//    static void Main()
//    {
//        Employee emp = new Employee(1, "Zyad", 5000);
//        emp.empidprop = 2;
//        emp.setname("Khaled");
//        emp.salaryprop = 7000;
//        emp.display();
//    }
//}

#endregion
#region Problem 4
//using System;

//public struct Point
//{
//    private int x;
//    private int y;

//    public Point(int x)
//    {
//        this.x = x;
//        this.y = 0;
//    }

//    public Point(int x, int y)
//    {
//        this.x = x;
//        this.y = y;
//    }

//    public void display()
//    {
//        Console.WriteLine($"({x}, {y})");
//    }
//}

//class Program
//{
//    static void Main()
//    {
//        Point p1 = new Point(5);
//        Point p2 = new Point(3, 7);

//        p1.display();
//        p2.display();
//    }
//}


#endregion
#region Problem 5
//using System;

//public struct Point
//{
//    private int x;
//    private int y;

//    public Point(int x)
//    {
//        this.x = x;
//        this.y = 0;
//    }

//    public Point(int x, int y)
//    {
//        this.x = x;
//        this.y = y;
//    }

//    public override string ToString()
//    {
//        return $"Point -> X: {x}, Y: {y}";
//    }
//}

//class Program
//{
//    static void Main()
//    {
//        Point p1 = new Point(4);
//        Point p2 = new Point(2, 6);
//        Point p3 = new Point(9, 1);

//        Console.WriteLine(p1);
//        Console.WriteLine(p2);
//        Console.WriteLine(p3);
//    }
//}

#endregion
#region Problem 6
//using System;

//public struct Point
//{
//    public int x;
//    public int y;

//    public Point(int x, int y)
//    {
//        this.x = x;
//        this.y = y;
//    }
//}

//public class Employee
//{
//    public string name;

//    public Employee(string name)
//    {
//        this.name = name;
//    }
//}

//class Program
//{
//    static void changepoint(Point p)
//    {
//        p.x = 100;
//        p.y = 100;
//    }

//    static void changeemployee(Employee e)
//    {
//        e.name = "changed";
//    }

//    static void Main()
//    {
//        Point p1 = new Point(1, 2);
//        Employee e1 = new Employee("ali");

//        changepoint(p1);
//        changeemployee(e1);

//        Console.WriteLine($"point: ({p1.x}, {p1.y})");
//        Console.WriteLine($"employee: {e1.name}");
//    }
//}


#endregion