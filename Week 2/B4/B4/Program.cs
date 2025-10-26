class Program  {
    static void Main(string[] args)
    {
        Console.Write("Input string initial: ");
        string stringInitial = Console.ReadLine();

        Console.Write("Input string to find: ");
        string stringFind = Console.ReadLine();

        Console.Write("Input string to insert: ");
        string stringInsert = Console.ReadLine();

        int point = -1;

        for (int i = 0; i <= stringInitial.Length - stringFind.Length; i++)
        {   
            bool test = true;
            for (int j = 0; j < stringFind.Length; j++)
            {
                if (stringInitial[i + j] != stringFind[j])
                {
                    test = false;
                    break;
                }
            }
            if (test)
            {
                point = i;
                break;
            }
        }

        if (point == -1)
        {
            Console.WriteLine("Can't find");
            return;
        }

        string result = "";

        for (int i = 0; i < point; i++)
        {
            result += stringInitial[i];
        }

        result += stringInsert + " ";

        for (int i = point; i < stringInitial.Length; i++)
        {
            result += stringInitial[i];
        }

        Console.WriteLine("Output: " + result);
    }
}
