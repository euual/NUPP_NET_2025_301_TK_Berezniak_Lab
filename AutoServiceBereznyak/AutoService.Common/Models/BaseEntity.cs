namespace AutoService.Common.Models;

// базовий клас
public abstract class BaseEntity
{
    public Guid Id { get; set; }

    // конструктор
    protected BaseEntity()
    {
        Id = Guid.NewGuid();
    }
}
