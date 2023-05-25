namespace GildedRose.Core;

public interface IInventoryItem
{
    string Name { get; }
    int SellIn { get; }
    int Quality  { get; }

    void UpdateQuality();
}
