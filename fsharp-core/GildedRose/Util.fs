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
    
    let group item =
        let g =
            match item.Name with
            | Aged n -> Aged
            | Backstage n -> Backstage
            | Sulfuras n -> Sulfuras
            | _ -> Other
        g
        
    let calculator item =
        let c =
            match group item with
            | Groups.Aged -> AgedCalculator.Instance :> ICalculator
            | Groups.Backstage -> BackstageCalculator.Instance
            | Groups.Sulfuras -> SulfurasCalculator.Instance
            | _ -> OtherCalculator.Instance
        c    