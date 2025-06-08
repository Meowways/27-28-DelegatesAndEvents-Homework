using System.Collections.Generic;
using UnityEngine;

public class Example : MonoBehaviour
{
    private List<Item> _items = new();

    private Inventory _inventory;

    private void Awake()
    {
        _items.Add(new Item(0));
        _items.Add(new Item(1));
        _items.Add(new Item(2));
        _items.Add(new Item(3));
        _items.Add(new Item(4));

        _inventory = new Inventory(_items, 15);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) 
            _inventory.Add(new Item(0));

        if (Input.GetKeyDown(KeyCode.Alpha2))
            _inventory.GetItemsBy(0, 2);

        if (Input.GetKeyDown(KeyCode.Alpha3))
            Debug.Log($"Capacity - {_inventory.Capacity}; OccupiedCell - {_inventory.OccupiedCell}; EmptyCell - {_inventory.EmptyCell}");

        //_inventory.Items[0] = new Item(0);
        //_inventory.Items[1].ID = _items.Count;
    }

}
