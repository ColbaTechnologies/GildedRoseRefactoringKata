using System.ComponentModel.DataAnnotations;

namespace GildedRose;

public sealed class Item
{
    public string Name { get; set; }
    public int SellIn { get; set; }
    public int Quality { get; set; }
}
