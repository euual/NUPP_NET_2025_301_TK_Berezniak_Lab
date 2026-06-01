
using AutoService.Common.Models;
using System.Collections;
using System.Collections.Concurrent;
using System.Text.Json;

namespace AutoService.Common.Services;

public class CrudServiceAsync<T> : ICrudServiceAsync<T> where T : BaseEntity
{
    private readonly ConcurrentDictionary<Guid, T> _items = new();
    private readonly SemaphoreSlim _semaphore = new(1, 1);

    public string FilePath { get; set; }

    public CrudServiceAsync(string filePath)
    {
        FilePath = filePath;
    }

    public async Task<bool> CreateAsync(T element)
    {
        await _semaphore.WaitAsync();

        try
        {
            return _items.TryAdd(element.Id, element);
        }
        finally
        {
            _semaphore.Release();
        }
    }

    public async Task<T> ReadAsync(Guid id)
    {
        await Task.Delay(1);

        if (_items.TryGetValue(id, out var element))
        {
            return element;
        }

        throw new Exception("Елемент не знайдено");
    }

    public async Task<IEnumerable<T>> ReadAllAsync()
    {
        await Task.Delay(1);
        return _items.Values.ToList();
    }

    public async Task<IEnumerable<T>> ReadAllAsync(int page, int amount)
    {
        await Task.Delay(1);

        return _items.Values
            .Skip((page - 1) * amount)
            .Take(amount)
            .ToList();
    }

    public async Task<bool> UpdateAsync(T element)
    {
        await _semaphore.WaitAsync();

        try
        {
            _items[element.Id] = element;
            return true;
        }
        finally
        {
            _semaphore.Release();
        }
    }

    public async Task<bool> RemoveAsync(T element)
    {
        await _semaphore.WaitAsync();

        try
        {
            return _items.TryRemove(element.Id, out _);
        }
        finally
        {
            _semaphore.Release();
        }
    }

    public async Task<bool> SaveAsync()
    {
        var json = JsonSerializer.Serialize(_items.Values.ToList(),
            new JsonSerializerOptions { WriteIndented = true });

        await File.WriteAllTextAsync(FilePath, json);

        return true;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return _items.Values.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
