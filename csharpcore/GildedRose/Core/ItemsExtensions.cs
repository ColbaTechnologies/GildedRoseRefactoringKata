using System.Collections.Generic;
using System.Linq;
using static GildedRose.Core.AgedBrie;
using static GildedRose.Core.BackstagePass;
using static GildedRose.Core.ConjuredItem;
using static GildedRose.Core.Sulfuras;

namespace GildedRose.Core;

public static class ItemsExtensions
{
    public static string Display(this IInventoryItem item) =>
        $"{item.Name}, {item.SellIn}, {item.Quality}";

    private static IInventoryItem ToInventoryItem(this Item item) => item.Name switch
    {
        "Aged Brie" => new AgedBrie(item),
        _ when IsConjuredItem(item.Name) => new ConjuredItem(item),
        _ when IsBackstagePass(item.Name) => new BackstagePass(item),
        _ when IsSulfuras(item.Name) => new Sulfuras(item),
        _ when IsAgedBrie(item.Name) => new AgedBrie(item),
        _ => new GenericItem(item)
    };

    public static IEnumerable<IInventoryItem> ToInventoryItems(this IEnumerable<Item> items) => items
        .Select(item => item.ToInventoryItem());

}
