using AutoService.Common.Models;

namespace AutoService.Common.Services;

public class CrudService<T> : ICrudService<T> where T : BaseEntity
{
    // вбудована колекція .NET
    private readonly List<T> _items = new();

    // метод Create
    public void Create(T element)
    {
        _items.Add(element);
    }

    // метод Read
    public T Read(Guid id)
    {
        return _items.FirstOrDefault(x => x.Id == id)
            ?? throw new Exception("Елемент не знайдено");
    }

    // метод ReadAll
    public IEnumerable<T> ReadAll()
    {
        return _items;
    }

    // метод Update
    public void Update(T element)
    {
        var index = _items.FindIndex(x => x.Id == element.Id);

        if (index == -1)
        {
            throw new Exception("Елемент для оновлення не знайдено");
        }

        _items[index] = element;
    }

    // метод Remove
    public void Remove(T element)
    {
        _items.Remove(element);
    }
}
