class Program
{
    static void Main(string[] args)
    {
        Console.Write("Select: ");
        double s;
        int select = int.Parse(Console.ReadLine());
        if (select == 1)
        {
            Console.Write("Input r = ");
            int r = int.Parse(Console.ReadLine());
            Console.WriteLine($"Area of ​​a circle = {3.14 * r * r}");
        }
        else if (select == 2)
        {
            Console.WriteLine("Input:");
            Console.Write("a = ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("b = ");
            int b = int.Parse(Console.ReadLine());
            Console.WriteLine($"Area of ​​rectangle = {a*b}");
        }
        else
        {
            Console.WriteLine("input:");
            Console.Write("d = ");
            int d = int.Parse(Console.ReadLine());
            Console.Write("h = ");
            int h = int.Parse(Console.ReadLine());
            Console.WriteLine($"Output: Area of ​​a circle = {3.14 * d * h}");
        }
        
    }
}
