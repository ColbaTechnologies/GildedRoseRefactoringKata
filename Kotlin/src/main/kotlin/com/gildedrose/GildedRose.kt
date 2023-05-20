package com.gildedrose

class GildedRose(var items: List<Item>) {

    fun updateQuality() {
        items = items.map { item -> getStrategy(item.name) update item }.toList()
    }

}

