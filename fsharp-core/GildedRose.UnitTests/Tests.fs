module GildedRose.UnitTests

open System.Collections.Generic
open GildedRose
open GildedRose.Util
open Xunit
open Swensen.Unquote

[<Fact>]
let ``Given an Aged item it's correctly identified`` () =
    let item = {Name = "Aged"; SellIn = 0; Quality = 0}
    let aged =
        match item.Name with
        | Aged n -> true
        | _ -> false
    test <@ true = aged @>
 
[<Fact>]    
let ``Given a non Aged item it's not identified`` () =
    let item = {Name = "NonAged"; SellIn = 0; Quality = 0}
    let aged =
        match item.Name with
        | Aged n -> true
        | _ -> false
    test <@ false = aged @>
    
[<Fact>]    
let ``Given a list of item they are correctly identified`` () =
    let items = List<Types.Item>()  
    items.Add({Name = "Aged"; SellIn = 0; Quality = 0})
    items.Add({Name = "Backstage"; SellIn = 0; Quality = 0})
    items.Add({Name = "Sulfuras"; SellIn = 0; Quality = 0})
        
    let groups = items |> Seq.map(group) |> Seq.toList
    test <@ [Types.Aged; Types.Backstage; Types.Sulfuras] = groups @>
        
[<Fact>]    
let ``Given a Aged item calculate quality and sell in values`` () =
    let mutable item: Types.Item = {Name = "Aged"; SellIn = 2; Quality = 0}
    let c = calculator item    
    for i = 0 to 30 do
        if (i > 0) then
            let sellIn, quality = c.Calculate item
            item <- { item with SellIn = sellIn }
            item <- { item with Quality = quality }
        
    test <@ -28 = item.SellIn @>
    test <@ 50 = item.Quality @>            