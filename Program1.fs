open System

let readFloatsSeq count =
    seq {
        for index = 1 to count do
            printf "Введите вещественное число %d: " index
            let input = Console.ReadLine()
            
            let success, value = Double.TryParse input
            if success then
                yield value
            else
                printfn "  Ошибка: некорректный ввод! Используется 0"
                yield 0
    }
    |> Seq.map (fun input -> int (float input)) 

[<EntryPoint>]
let main args =
    printf "Введите количество значений последовательности: "
    let countInput = Console.ReadLine()
    
    let success, count = Int32.TryParse countInput
    
    if not success || count <= 0 then
        printfn "Ошибка: количество должно быть положительным целым числом!"
        exit 1
    else
        let floatsSeq = readFloatsSeq count
        floatsSeq |> Seq.iter (printfn "Элемент без дробной части: %d")
    
    0
