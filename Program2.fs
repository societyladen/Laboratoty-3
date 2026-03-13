open System

let readStringsSeq count =
    seq {
        for index in 1 .. count do
            printf "Введите элемент %d: " index
            yield Console.ReadLine()
    }

[<EntryPoint>]
let main args =
    printf "Введите количество элементов: "
    let count = Console.ReadLine() |> int

    if count <= 0 then
        printfn "Ошибка: количество должно быть положительным!"
        exit 1
    else
        let stringsSeq = readStringsSeq count
        
        let resultString, evenCount =
            stringsSeq
            |> Seq.fold (fun (output : string, acc : int) (s : string) ->
                let newOutput = output + s + " "
                let newAcc = if s.Length % 2 = 0 then acc + 1 else acc
                newOutput, newAcc
            ) ("", 0)
        
        printfn "Последовательность строк:"
        printfn "%s" resultString
        printfn "Строк с чётной длиной: %d" evenCount
        0