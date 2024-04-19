namespace DeconstructionDemo;

public record Student
{
    public Student(string name, string lastName, int age)
    {
        Name = name;
        LastName = lastName;
        Age = age;
    }

    public void Deconstruct(out string name, out string lastName, out int age)
    {
        name = Name; 
        lastName = LastName; 
        age = Age;
    }

    public string Name { get; init; }

    public string LastName { get; init; }

    public int Age { get; init; }
}