namespace AutoService.Common.Models;

// наслідування від Person
public class Client : Person
{
    public string Email { get; set; }
    public int LoyaltyPoints { get; set; }
    public bool IsRegularClient { get; set; }

    // статичне поле
    public static int ClientsCount;

    // статичний конструктор
    static Client()
    {
        ClientsCount = 0;
    }

    // конструктор
    public Client(string fullName, string phoneNumber, int age, string email)
        : base(fullName, phoneNumber, age)
    {
        Email = email;
        LoyaltyPoints = 0;
        IsRegularClient = false;
        ClientsCount++;
    }

    // метод
    public void AddLoyaltyPoints(int points)
    {
        LoyaltyPoints += points;

        if (LoyaltyPoints >= 100)
        {
            IsRegularClient = true;
        }
    }

    // метод
    public override string GetInfo()
    {
        return $"Клієнт: {FullName}, телефон: {PhoneNumber}, email: {Email}, бонуси: {LoyaltyPoints}";
    }
}
