module GildedRose.Types
    
    type Item = { Name: string; SellIn: int; Quality: int }    
    
    type IQualityCalculator =
        abstract member CalculateQuality : item:Item -> unit
        
    type ISellInCalculator =
        abstract member CalculateSellIn : item:Item -> unit
        
    type ICalculator =
        abstract member Calculate : Item -> (int * int)

    type AgedCalculator private () =
        static member val Instance = AgedCalculator ()
        
        interface ICalculator with
                member this.Calculate item =
                    let quality =
                        match item.Quality with
                        | q when q < 50 -> item.Quality + 1
                        | _ -> item.Quality
                        
                    let sellIn = item.SellIn - 1
                    
                    let quality =
                        match (sellIn, quality) with
                        | s, q when s < 0 && q < 50 -> quality + 1
                        | _ -> quality
                    (sellIn, quality)
            
    type BackstageCalculator private () =
        static member val Instance = BackstageCalculator ()
        
        interface ICalculator with   
            member this.Calculate item = failwith "todo"            

    type SulfurasCalculator private () =
        static member val Instance = SulfurasCalculator ()
        interface ICalculator with
            member this.Calculate item = failwith "todo"            
            
    type OtherCalculator private () =
        static member val Instance = OtherCalculator ()
        interface ICalculator with
            member this.Calculate item = failwith "todo"                    
            
    type Groups =
        | Aged
        | Backstage
        | Sulfuras
        | Other        

