using System;

namespace GildedRose.Core;

public class Sulfuras : DefaultInventoryBehavior
{
    public Sulfuras(string name, int sellIn)
    {
        if (!IsSulfuras(name))
            throw new ArgumentException(name, nameof(name));

        Name = name;
        SellIn = sellIn;
        Quality = 80;
    }

    public Sulfuras(Item item) : this(item.Name, item.SellIn) { }

    public string Name { get; }
    public int SellIn { get; private set; }
    public int Quality { get; }

    public static bool IsSulfuras(string name) => name.ToLower().Contains("sulfuras");
}
