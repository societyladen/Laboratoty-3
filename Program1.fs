open System

// Задание 1
let readFloatsSeq count =
    [
    for index in 1 .. count do
        printf "Введите вещественное число %d: " index
        let input = Console.ReadLine()
        yield float input
    ]

[<EntryPoint>]
let main args =
    printf "Введите количество значений последовательности: "
    let count = Console.ReadLine() |> int
    let list1 = readFloatsSeq count

    if count <= 0 then
        printf "Ошибка: количество должно быть положительным!"
        exit 1
    else
        let floatsSeq = seq{for i in list1 -> i}
        let intsSeq = floatsSeq
        let ints = Seq.map int floatsSeq
        
        printfn "Последовательность float: %A" intsSeq
        printfn "Последовательность integer: %A" ints

    0