open System

let readFloatsSeq count =
    seq {
        for index = 1 to count do
            let rec readValue() =
                printf "Введите вещественное число %d: " index
                let input = Console.ReadLine()
                
                let success, value = Double.TryParse input
                if success then
                    value
                else
                    printfn "  Ошибка: некорректный ввод! Попробуйте снова."
                    readValue()
            
            yield readValue()
    }
    |> Seq.map int

let rec getValidCount() =
        printf "Введите количество значений последовательности: "
        let countInput = Console.ReadLine()
        
        let success, count = Int32.TryParse countInput
        
        if not success || count <= 0 then
            printfn "Ошибка: количество должно быть положительным целым числом! Попробуйте снова."
            getValidCount()
        else
            count

[<EntryPoint>]
let main args =
    let count = getValidCount()
    let floatsSeq = readFloatsSeq count
    floatsSeq |> Seq.iter (printfn "Элемент без дробной части: %d")
    
    0
