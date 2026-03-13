open System
open System.IO


let getFileNames directoryPath =
    seq {
        for filePath in Directory.EnumerateFiles(directoryPath) do
            yield Path.GetFileName(filePath)
    }


let checkFileExists directoryPath fileName =
    getFileNames directoryPath
    |> Seq.exists (fun name -> name = fileName)

[<EntryPoint>]
let main args =
    printf "Введите путь к каталогу: "
    let directoryPath = Console.ReadLine()
    
    if Directory.Exists(directoryPath) then
        printf "Введите название файла для поиска: "
        let searchFileName = Console.ReadLine()
        
        let filesSeq = getFileNames directoryPath
        
        printfn "\nФайлы в каталоге %s:" directoryPath
        for file in filesSeq do
            printfn "  - %s" file
        
        let fileExists = checkFileExists directoryPath searchFileName
        
        printfn "\nРезультат поиска:"
        if fileExists then
            printfn "Файл '%s' существует!" searchFileName
        else
            printfn "Файл '%s' не найден." searchFileName
    else
        printfn "Ошибка: Каталог '%s' не существует!" directoryPath
    
    printfn "\nНажмите любую клавишу для выхода..."
    Console.ReadKey() |> ignore
    0