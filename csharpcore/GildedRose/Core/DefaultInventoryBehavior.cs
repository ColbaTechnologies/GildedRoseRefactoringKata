namespace GildedRose.Core;

public abstract class DefaultInventoryBehavior : IInventoryItem
{
    public string Name { get; }
    public int SellIn { get; private set; }
    public int Quality { get; }

    public void UpdateQuality()
    {
        SellIn -= 1;
    }
}
