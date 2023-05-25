using System.Collections.Generic;
using System.Linq;
using GildedRose.Core;

namespace GildedRose;

public class GildedRose
{
    public IEnumerable<Item> Items => _items.Select(item => new Item
    {
        Name = item.Name,
        SellIn = item.SellIn,
        Quality = item.Quality
    }).ToList();

    private readonly List<IInventoryItem> _items;

    public GildedRose(IEnumerable<Item> items) => _items = items.ToInventoryItems().ToList();

    public void UpdateQuality()
    {
        foreach (var item in _items)
            item.UpdateQuality();
    }
}
