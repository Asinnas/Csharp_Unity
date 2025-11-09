class Program
{
    static void Main()
    {
        StudentManager manager = new StudentManager();

        Console.Write("Enter number of student: ");
        int n = int.Parse(Console.ReadLine()!);

        Student[] list = new Student[n];

        for (int i = 0; i < list.Length; i++)
        {
            Console.WriteLine($"Enter information {i+1}");

            Console.Write("Name: ");
            string name = Console.ReadLine()!;

            Console.Write("Age: ");
            int age = int.Parse(Console.ReadLine()!);

            Console.Write("GPA: ");
            double gpa = double.Parse(Console.ReadLine()!);

            list[i] = new Student(name, age, gpa);

            manager.AddStudent(list[i]);
        }

        Console.Write("Enter Student need to Update GPA: ");
        int a = int.Parse(Console.ReadLine()!);
        Console.Write("Update GPA: ");
        double newGpa = double.Parse(Console.ReadLine()!);
        list[a-1].UpdateGpa(newGpa);

        manager.ShowAllStudents();

        var topStudent = manager.FindTopStudent();

        Console.WriteLine($"Top Student: Name: {topStudent.Name}, Age: {topStudent.Age}, GPA: {topStudent.Gpa}");

        Console.WriteLine($"Number of Student: {StudentManager.totalStudentsCount}");


    }
}