using System;

namespace GildedRose.Core;

public class AgedBrie : IInventoryItem
{
    public AgedBrie(string name, int sellIn, int quality)
    {
        if (!IsAgedBrie(name))
            throw new ArgumentException(name, nameof(name));

        Name = name;
        SellIn = sellIn;
        Quality = quality;
    }

    public AgedBrie(Item item) : this(item.Name, item.SellIn, item.Quality) { }

    public string Name { get; }
    public int SellIn { get; private set; }
    public int Quality { get; private set; }

    public void UpdateQuality()
    {
        SellIn -= 1;
        Quality = Quality <= 50
            ? SellIn >= 0
                ? Quality + 1
                : Quality + 2
            : Quality;
    }

    public static bool IsAgedBrie(string itemName) =>
        itemName.ToLower().Contains("aged") && itemName.ToLower().Contains("brie");
}
