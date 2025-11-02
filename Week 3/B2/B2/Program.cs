class Program
    {
    static void Main(string[] args)
    {
        Console.Write("Input string: ");
        string s = Console.ReadLine();
        
        for (int i = s.Length - 1; i >= 0; i--)
        {
            Console.Write(s[i]);
        }
    }
}
