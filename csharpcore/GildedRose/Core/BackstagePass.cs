using System;

namespace GildedRose.Core;

public class BackstagePass : IInventoryItem
{
    public BackstagePass(string name, int sellIn, int quality)
    {
        if (!IsBackstagePass(name))
            throw new ArgumentException(name, nameof(name));
        Name = name;
        SellIn = sellIn;
        Quality = quality;
    }

    public BackstagePass(Item item) : this(item.Name, item.SellIn, item.Quality) { }

    public string Name { get; }
    public int SellIn { get; private set; }
    public int Quality { get; private set; }

    public void UpdateQuality()
    {
        SellIn -= 1;
        Quality = SellIn switch
        {
            >= 50 => 50,
            <= 0 => 0,
            <= 5 => Quality += 3,
            <= 10 => Quality += 2,
            _ => Quality + 1
        };
    }

    public static bool IsBackstagePass(string name) =>
        name.ToLower().Contains("backstage") && name.ToLower().Contains("passes");
}
