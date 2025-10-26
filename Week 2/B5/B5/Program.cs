class Program {
    static void input(int n, double[] point)
    {
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Student {i + 1}: ");
            point[i] = double.Parse(Console.ReadLine());
        }
    }
    static double average(int n, double[] point)
    {
        double sum = 0;
        for (int i = 0; i < n; i++)
            sum += point[i];
        return sum / n;
    }
    static double maxPoint(int n, double[] point)
    {
        double max = point[0];
        for (int i = 1; i < n; i++)
            if (max < point[i])
                max = point[i];
        return max;
    }
    static double minPoint(int n, double[] point)
    {
        double min = point[0];
        for (int i = 1; i < n; i++)
            if (min > point[i])
                min = point[i];
        return min;
    }
    static double ratePass(int n, double[] point)
    {
        int count = 0;
        for (int i = 0; i < n; i++)
            if (point[i] >= 5)
                count++;
        return (double)count / n * 100;
    }

    static void classify(int n, double[] point)
    {
        int goodCount = 0;
        int ratherCount = 0;
        int mediumCount = 0;
        int leastCount = 0;
        for (int i = 0; i < n; i++)
        {
            if (point[i] > 8)
                goodCount++;
            else if (point[i] >= 6.5)
                ratherCount++;
            else if (point[i] >= 5)
                mediumCount++;
            else
                leastCount++;
        }
        Console.WriteLine($"Good: {goodCount} student");
        Console.WriteLine($"Rather: {ratherCount} student");
        Console.WriteLine($"Medium: {mediumCount} student");
        Console.WriteLine($"Least: {leastCount} student");
    }
    static void Main(string[] args)
    {
        Console.Write("Input the number of students: ");
        int n = int.Parse(Console.ReadLine());

        double[] point = new double[n];
        Console.WriteLine("Input the point: ");
        input(n, point);

        Console.WriteLine($"Average point: {Math.Round(average(n, point), 2)}");

        Console.WriteLine($"Max point: {maxPoint(n, point)}");

        Console.WriteLine($"Min point: {minPoint(n, point)}");

        Console.WriteLine($"Pass rate: {Math.Round(ratePass(n, point), 2)}%");

        Console.WriteLine("Classify: "); 
        classify(n, point);



    }
}
