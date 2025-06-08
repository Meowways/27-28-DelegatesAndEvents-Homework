using System;
using System.Collections.Generic;
using System.Linq;

public class Inventory
{
    private List<Item> _items;

    private int _capacity;

    public Inventory(List<Item> items, int capacity)
    {
        if (items.Count > capacity)
            throw new InvalidOperationException($"Невозможно добавить {items.Count} предметов. Максимум: {capacity}.");

        _items = new List<Item>(items);
        _capacity = capacity;
    }

    public IReadOnlyList<Item> Items => _items;

    public int Capacity => _capacity;
    public int OccupiedCell => _items.Count;
    public int EmptyCell => Capacity - OccupiedCell;

    public bool HasEmptyCell => EmptyCell > 0;

    public void Add(Item item)
    {
        if (HasEmptyCell == false)
            throw new InvalidOperationException("Инвентарь полный.");

        _items.Add(item);
    }

    public List<Item> GetItemsBy(int id, int count)
    {
        List<Item> items = _items.Where(item => item.ID == id).Take(count).ToList();

        if (items.Count == 0)
            throw new ArgumentException($"Предмет с ID - {id} отсутствует в инвентаре.");

        if (items.Count < count)
            throw new InvalidOperationException($"Не возможно вернуть {count} предметов. Имеется {items.Count} предметов.");

        foreach (Item item in items)
            _items.Remove(item);

        return items;
    }
}

public class Item
{
    public Item(int id)
    {
        ID = id;
    }

    public int ID { get; private set; }
}
