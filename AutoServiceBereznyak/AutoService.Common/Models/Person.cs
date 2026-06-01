namespace AutoService.Common.Models;

// базовий клас для людей
public abstract class Person : BaseEntity
{
    public string FullName { get; set; }
    public string PhoneNumber { get; set; }
    public int Age { get; set; }

    // конструктор
    protected Person(string fullName, string phoneNumber, int age)
    {
        FullName = fullName;
        PhoneNumber = phoneNumber;
        Age = age;
    }

    // метод
    public virtual string GetInfo()
    {
        return $"{FullName}, телефон: {PhoneNumber}, вік: {Age}";
    }
}
