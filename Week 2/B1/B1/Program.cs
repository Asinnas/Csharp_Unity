using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Input: ");
        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());
        double c = double.Parse(Console.ReadLine());

        Console.Write("Output: ");
        if (a+b >= c || a+c>=b || b+c>=a)
        {
            if (a == b && b == c)
            {
                Console.WriteLine("Equilateral");
            }
            else if (a == b || b == c || a == c)
            {
                Console.WriteLine("Isosceles");
            }
            else
            {
                Console.WriteLine("Scalene");
            }
        }
        else
        {
            Console.WriteLine("Not a triangle");
        }

    }
}