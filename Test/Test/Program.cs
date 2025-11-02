using System.Text;

class Program

{
    public static void Test(float a)
    {
        if (a > 5)
        {
            Console.WriteLine(String.Format($"Diem {a} xep hang TB"));
        }
        else if (a >= 5 && a <= 7)
        {
            Console.WriteLine(String.Format($"Diem {a} xep hang Kha"));
        }
        else
        {
            Console.WriteLine(String.Format($"Diem {a} xep hang Gioi"));
        }
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Nhap diem: ");
        float a = float.Parse(Console.ReadLine()!);
        int diem = (int)a;
        Console.WriteLine(diem);
        Test(diem);
    }
}