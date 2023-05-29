module GildedRose.Util

    open GildedRose.Types

    let (|Aged|_|) (name : string) =
        if (name.StartsWith "Aged") then
            Some Types.Aged
        else        
            None    
        
    let (|Backstage|_|) (name : string) =
        if (name.StartsWith "Backstage") then
            Some Types.Backstage
        else        
            None    
         
    let (|Sulfuras|_|) (name : string) =
        if (name.StartsWith "Sulfuras") then
            Some Types.Sulfuras
        else        
            None    
    
    let calculate item: Item =
        let calculator =
            match item.Name with
            | Aged n -> Types.Aged :> ICalculator
            | Backstage n -> Types.Backstage :> ICalculator
            | Sulfuras n -> Types.Sulfuras :> ICalculator
            | _ -> Types.Other :> ICalculator
        calculator    