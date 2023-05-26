import { Item, Items } from "./item";

export type UpdateItem = (item: Item) => Item;

export const updateGenericItem = ({name, quality, sellIn}: Item) => {
    const newSellIn = sellIn - 1;
    const newQuality = quality < 0 
        ? quality
        : newSellIn >= 0
            ? quality - 1
            : quality -2;
    return {
        name,
        sellIn: newSellIn,
        quality: newQuality
    };
}

export const updateAgedBrie = ({name, quality, sellIn}: Item) => {
    const newSellIn = sellIn - 1;
    const newQuality = quality >= 50
        ? quality
        : newSellIn >= 0
            ? quality + 1
            : quality + 2;
    return {
        name,
        sellIn: newSellIn,
        quality: newQuality
    };
}

export const updateSulfuras = (item: Item) => item;

export const updateBackstage = ({name, quality, sellIn}: Item) => {
    const newSellIn = sellIn - 1;
    const newQuality = quality >= 50
        ? quality
        : newSellIn < 0
            ? 0
            : newSellIn <= 5
                ? quality + 3
                : newSellIn <= 10 
                    ? quality + 2
                    : quality;
    return {
        name,
        sellIn: newSellIn,
        quality: newQuality
    };
}

export const updateConjured = ({name, quality, sellIn}: Item) => {
    const newSellIn = sellIn - 1;
    const newQuality = quality < 0 
        ? quality
        : newSellIn >= 0
            ? quality - 2
            : quality - 4;
    return {
        name,
        sellIn: newSellIn,
        quality: newQuality
    };
}

const findUpdater = (itemName: string): UpdateItem => {
    const lowerCaseName = itemName.toLowerCase();
    if (lowerCaseName.includes("aged") && lowerCaseName.includes("brie")) {
        return updateAgedBrie;
    }
    if (lowerCaseName.includes("sulfuras")) {
        return updateSulfuras;
    }
    if (lowerCaseName.includes("backstage") && lowerCaseName.includes("passes")) {
        return updateBackstage;
    }
    if (lowerCaseName.includes("conjured")) {
        return updateConjured;
    }
    return updateGenericItem;
};

export const updateItems = (items: Items) => items.map(item => findUpdater(item.name)(item));