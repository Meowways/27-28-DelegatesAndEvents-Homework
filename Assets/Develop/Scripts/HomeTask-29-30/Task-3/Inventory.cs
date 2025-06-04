using System;
using System.Collections.Generic;
using System.Linq;

public class Inventory
{
    private List<Item> _items = new();

    private int _maxSize;

    public Inventory(List<Item> items, int maxSize)
    {
        _items = new List<Item>(items);
        _maxSize = maxSize;
    }

    public IReadOnlyList<Item> Items => _items;

    public int CurrentSize => _items.Sum(item => item.Count);

    public int MaxSize => _maxSize;

    public void Add(Item item)
    {
        if (CurrentSize + item.Count > MaxSize)
            return;

        Item inneritem = _items.FirstOrDefault(innerItem => innerItem.ID == item.ID);

        if (inneritem != null)
            inneritem.Add(item.Count);
        else
            _items.Add(item);
    }

    public Item GetItemsBy(int id, int count)
    {
        Item item = _items.FirstOrDefault(item => item.ID == id);

        if (item == null)
            throw new ArgumentException($"Item with ID {id} not found.");

        if (item.Count < count)
            throw new InvalidOperationException($"Cannot return {count} items. Only {item.Count} available.");

        item.Subtract(count);

        if (item.Count == 0)
            _items.Remove(item);

        return new Item(id, count);
    }
}

public class Item
{
    public Item(int iD, int count)
    {
        ID = iD;

        if (count > 0)
            Count = count;
        else
            Count = 0;
    }

    public int ID { get; private set; }
    public int Count { get; private set; }

    public void Add(int additionalValue) => Count += additionalValue;

    public void Subtract(int subtractetValue) => Count -= subtractetValue;
}