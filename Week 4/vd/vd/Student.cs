class Student
{
    private string name;
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    public int age;
    public int Age
    {
        get { return age; }
        set { age = value; }
    }
    private double gpa;
    public double Gpa
    {
        get { return gpa; }
        private set { gpa = value; }
    }

    public Student(String name, int age, double gpa)
    {
        this.name = name;
        this.age = age;
        this.gpa = gpa;
        StudentManager.totalStudentsCount++;
    }
    public void UpdateGpa(double newGpa)
    {
        if (newGpa >= 0.0 && newGpa <= 10.0)
        {
            gpa = newGpa;
        }
        else
        {
            throw new ArgumentOutOfRangeException("GPA 0.0 and 10.0");
        }
    }
}
