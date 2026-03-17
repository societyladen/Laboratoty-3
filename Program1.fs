open System

let readFloatsSeq count =
    
    seq {
        for index in 1 .. count do
            printf "Введите вещественное число %d: " index
            yield Console.ReadLine()
    }
    |> Seq.map (fun input -> int (float input)) 

[<EntryPoint>]
let main args =
    printf "Введите количество значений последовательности: "
    let count = Console.ReadLine() |> int

    if count <= 0 then
        printf "Ошибка: количество должно быть положительным!"
        exit 1
    else
        let floatsSeq = readFloatsSeq count
        floatsSeq |> Seq.iter (printfn "Элемент %d")

    0
