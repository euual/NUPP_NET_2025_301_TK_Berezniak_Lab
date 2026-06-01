namespace AutoService.Common.Models;

// наслідування від Person
public class Mechanic : Person
{
    public string Specialization { get; set; }
    public int ExperienceYears { get; set; }
    public decimal Salary { get; set; }

    // конструктор
    public Mechanic(string fullName, string phoneNumber, int age, string specialization, int experienceYears, decimal salary)
        : base(fullName, phoneNumber, age)
    {
        Specialization = specialization;
        ExperienceYears = experienceYears;
        Salary = salary;
    }

    // метод
    public override string GetInfo()
    {
        return $"Механік: {FullName}, спеціалізація: {Specialization}, досвід: {ExperienceYears} років, зарплата: {Salary} грн";
    }
}
