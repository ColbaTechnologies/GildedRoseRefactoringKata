package com.gildedrose

import org.junit.jupiter.api.Assertions.assertEquals
import org.junit.jupiter.api.Test

internal class GildedRoseTest {

//    @Test
//    fun foo() {
//        val items = listOf(Item("foo", 0, 0))
//        val app = GildedRose(items)
//        app.updateQuality()
//        assertEquals("fixme", app.items[0].name)
//
//    }

    @Test
    fun `Normal product case - After 1 day sell reduced and quality reduced in 1`() {
        val items = listOf(Item("Product1", 5, 2))
        val app = GildedRose(items)
        app.updateQuality()
        assertEquals(4, app.items[0].sellIn)
        assertEquals(1, app.items[0].quality)
    }

    @Test
    fun `Normal product case - After 2 day sell reduced and quality reduced in 1`() {
        val items = listOf(Item("Product1", 5, 2))
        val app = GildedRose(items)
        app.updateQuality()
        app.updateQuality()
        assertEquals(3, app.items[0].sellIn)
        assertEquals(0, app.items[0].quality)
    }


    // FIRST CASE
    @Test
    fun `After selling date, quality reduces by 2`() {
        val items = listOf(Item("Product1", 0, 5))
        val app = GildedRose(items)
        app.updateQuality()
        assertEquals(3, app.items[0].quality)
    }


    // SECOND CASE
    @Test
    fun `The quality of a product never has negative value`() {
        val items = listOf(Item("Product1", 0, 1))
        val app = GildedRose(items)
        app.updateQuality()
        assertEquals(0, app.items[0].quality)
    }

    @Test
    fun `The product Aged brie increase the quality after time`() {
        val items = listOf(Item("Aged Brie", 10, 1))
        val app = GildedRose(items)
        app.updateQuality()
        assertEquals(2, app.items[0].quality)
    }

    @Test
    fun `The product Aged brie increase the quality in double when selling is 0 `() {
        val items = listOf(Item("Aged Brie", 0, 1))
        val app = GildedRose(items)
        app.updateQuality()
        assertEquals(3, app.items[0].quality)
    }

    // THIRD CASE

    @Test
    fun `The quality of a product never is greater than 50 `() {
        val items = listOf(Item("Aged Brie", 0, 50))
        val app = GildedRose(items)
        app.updateQuality()
        assertEquals(50, app.items[0].quality)
    }

    // FOURTH CASE
    @Test
    fun `The quality of a sulfuras product never is modified `() {
        val items = listOf(Item("Sulfuras, Hand of Ragnaros", 10, 50))
        val app = GildedRose(items)
        app.updateQuality()
        assertEquals(50, app.items[0].quality)
        assertEquals(10, app.items[0].sellIn)
    }

    // FIFTH CASE
    @Test
    fun `The Backstage end date quality goes to 0 `() {
        val items = listOf(Item("Backstage passes to a TAFKAL80ETC concert", 0, 24))
        val app = GildedRose(items)
        app.updateQuality()
        assertEquals(0, app.items[0].quality)
    }

    @Test
    fun `The Backstage less than 5 days quality +3 `() {
        val items = listOf(Item("Backstage passes to a TAFKAL80ETC concert", 3, 24))
        val app = GildedRose(items)
        app.updateQuality()
        assertEquals(27, app.items[0].quality)
    }

    @Test
    fun `The Backstage less than 10 days quality +2 `() {
        val items = listOf(Item("Backstage passes to a TAFKAL80ETC concert", 10, 24))
        val app = GildedRose(items)
        app.updateQuality()
        assertEquals(26, app.items[0].quality)
    }

}


