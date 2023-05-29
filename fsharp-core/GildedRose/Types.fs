module GildedRose.Types

    type Item = { Name: string; SellIn: int; Quality: int }    
    
    type IQualityCalculator =
        abstract member CalculateQuality : item:Item -> unit
        
    type ISellInCalculator =
        abstract member CalculateSellIn : item:Item -> unit
        
    type ICalculator =
        inherit IQualityCalculator
        inherit ISellInCalculator

    type AgedCalculator =
        interface ICalculator with
                member this.CalculateQuality(item) = failwith "todo"
                member this.CalculateSellIn(item) = failwith "todo"
            
    type BackstageCalculator =
        interface IQualityCalculator with   
            member this.CalculateQuality(item) = failwith "todo"
            
        interface ISellInCalculator with
            member this.CalculateSellIn(item) = failwith "todo"

    type SulfurasCalculator =
        interface IQualityCalculator with
            member this.CalculateQuality(item) = failwith "todo"
            
        interface ISellInCalculator with
            member this.CalculateSellIn(item) = failwith "todo"
            
    type OtherCalculator =
        interface IQualityCalculator with
            member this.CalculateQuality(item) = failwith "todo"
            
        interface ISellInCalculator with
            member this.CalculateSellIn(item) = failwith "todo"            
        
            
    type ItemGroupByName =
        | Aged of AgedCalculator
        | Backstage of BackstageCalculator
        | Sulfuras  of SulfurasCalculator
        | Other        

