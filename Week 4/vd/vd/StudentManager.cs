class StudentManager
{
    private List<Student> students = new List<Student>();
  
    public static int totalStudentsCount = 0;

    public void AddStudent(Student s)
    {
        students.Add(s);
    }
    public void ShowAllStudents()
    {
        foreach (var student in students)
        {
            Console.WriteLine($"Name: {student.Name}, Age: {student.Age}, GPA: {student.Gpa}");
        }
    }
    public Student FindTopStudent()
    {
        if (students.Count == 0)
        {
            return null;
        }
        Student topStudent = students[0];
        foreach (var student in students)
        {
            if (student.Gpa > topStudent.Gpa)
            {
                topStudent = student;
            }
        }
        return topStudent;
    }
}
