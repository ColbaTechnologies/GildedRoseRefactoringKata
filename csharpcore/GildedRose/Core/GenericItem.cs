namespace GildedRose.Core;

public class GenericItem : DefaultInventoryBehavior
{
    public GenericItem(string name, int sellIn, int quality)
    {
        Name = name;
        SellIn = sellIn;
        Quality = quality;
    }

    public GenericItem(Item item) : this(item.Name, item.SellIn, item.Quality) { }

    public string Name { get; }
    public int SellIn { get; private set; }
    public int Quality { get; private set; }

    public new void UpdateQuality()
    {
        base.UpdateQuality();
        Quality -= Quality <= 50
            ? SellIn >= 0 ? 1 : 2
            : Quality;
    }
}
