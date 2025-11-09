using B1;
using System.Threading.Channels;

class Program  {
    
    static List<Worker> listWorker = new List<Worker>();
    static void Main()
    {

        int choice;

        do
        {
            Console.WriteLine("1. Input worker");
            Console.WriteLine("2. Show list");
            Console.WriteLine("3. Sort with name and salary");
            Console.WriteLine("4. Find worker with code");
            Console.WriteLine("5. Exit");
            Console.Write("Choice option (1-5): ");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1: inputWorker(); break;
                case 2: showList(); break;
                case 3: sortList(); break;
                case 4: findWorker(); break;
                case 5: Console.WriteLine("Exiting..."); break;
                default: Console.WriteLine("Invalid choice. Please choose again."); break;
            }
        }while (choice != 5);
    }
    static void inputWorker()
    {
        string code;
        while (true)
        {
            Console.Write("Enter code: ");
            code = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(code))
            {
                Console.WriteLine("Code cannot be empty. Please enter again.");
                continue;
            }

            if (listWorker.Any(w => w.Code == code))
            {
                Console.WriteLine("Worker with this code already exists. Please enter a different code.");
            }
            else
            {
                break;
            }
        }
        Console.Write("Enter name: ");
        string name = Console.ReadLine();


        int age;

        while (true)
        {
            Console.Write("Enter age (>0): ");
            string? ageInput = Console.ReadLine();
            if (int.TryParse(ageInput, out age) && age > 0)
            {
                break;
            }
            Console.WriteLine("Invalid age. Please enter a positive integer.");
        }

        Console.Write("Enter locate: ");
        string locate = Console.ReadLine();

        Console.WriteLine("Choice level: ");
        foreach (var level in Enum.GetValues(typeof(B1.Level)))
        {
            Console.WriteLine($"{(int)level}. {level}");
        }

        int levelChoice = int.Parse(Console.ReadLine());

        while (levelChoice < 0 || levelChoice > 5)
        {
            Console.WriteLine("Invalid choice. Please choose again.");
            levelChoice = int.Parse(Console.ReadLine());
        }

        Worker cn = new Worker(code, name, age, locate, (Level)levelChoice);
        listWorker.Add(cn);
        Console.WriteLine("Finish");
    }  
    static void showList()
    {
        if (listWorker.Count == 0)
        {
            Console.WriteLine("List is empty.");
            return;
        }

        foreach (var worker in listWorker)
        {
            worker.showInfo();
        }
    }

    static void sortList()
    {
        var sortedList = listWorker
            .OrderBy(w => w.FullName)
            .ThenByDescending(w => w.payroll())
            .ToList();

        foreach (var worker in sortedList)
        {
            worker.showInfo();
        }
    }
    static void findWorker()
    {
        Console.Write("Enter code to find: ");
        string code = Console.ReadLine();
        var worker = listWorker.FirstOrDefault(w => w.Code == code);
        if (worker != null)
        {
            Console.WriteLine("Finish find: ");
            worker.showInfo();
        }
        else
        {
            Console.WriteLine("Worker not found.");
        }
    }
}