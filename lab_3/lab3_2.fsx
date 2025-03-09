open System

// Функция для ввода последовательности чисел
let getNumbers () =
    printfn "Введите длину последовательности:"
    let length = 
        match Int32.TryParse(Console.ReadLine()) with
        | true, len when len > 0 -> len
        | _ -> 
            printfn "Некорректный ввод. Установлена длина по умолчанию: 5."
            5

    printfn "Введите %d чисел через пробел:" length
    let input = Console.ReadLine()
    input.Split(' ')
    |> Array.take length
    |> Array.map (fun s -> 
        match Int32.TryParse(s) with
        | true, num -> num
        | false, _ -> 
            printfn "Некорректный ввод числа. Заменено на 0."
            0) // Если ввод некорректен, заменяем на 0
    |> Seq.ofArray

// Функция для ввода числа от пользователя
let getTargetNumber () =
    printfn "Введите число для поиска:"
    match Int32.TryParse(Console.ReadLine()) with
    | true, num -> num
    | false, _ -> 
        printfn "Некорректный ввод. Установлено число по умолчанию: 0."
        0

// Получаем последовательность чисел от пользователя
let numbers = getNumbers()

// Получаем число для поиска
let targetNumber = getTargetNumber()

// Применяем Seq.filter для поиска элементов, равных заданному числу
let count = Seq.filter (fun x -> x = targetNumber) numbers |> Seq.length

// Выводим результат
printfn "Количество элементов, равных %d: %d" targetNumber count