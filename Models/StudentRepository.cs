namespace shereeni_dotnet.Models;

public static class StudentRepository
{
    public static List<Student> Students { get; set; } = new List<Student>()
    {
        new Student
        {
            Id = 1,
            Name = "Shakeel Khan",
            Email = "shakeel@yopmail.cm",
            Address = "ISB, PK"
        },
        new Student
        {
            Id = 2,
            Name = "Shake Khan",
            Email = "shak@yopmail.cm",
            Address = "ISB, PK"
        }
    };
}