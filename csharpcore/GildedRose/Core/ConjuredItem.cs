using System;

namespace GildedRose.Core;

public class ConjuredItem : IInventoryItem
{
    public ConjuredItem(string name, int sellIn, int quality)
    {
        if (!IsConjuredItem(name))
            throw new ArgumentException(name, nameof(name));

        Name = name;
        SellIn = sellIn;
        Quality = quality;
    }

    public ConjuredItem(Item item) : this(item.Name, item.SellIn, item.Quality) { }

    public string Name { get; }
    public int SellIn { get; private set; }
    public int Quality { get; private set; }

    public void UpdateQuality()
    {
        SellIn -= 1;
        Quality -= Quality <= 50
            ? SellIn >= 0 ? 2 : 4
            : Quality;
    }

    public static bool IsConjuredItem(string itemName) => itemName.ToLower().Contains("conjured");
}
