open System

// Функция для нахождения первой цифры числа
let firstDigit number =
    let numberStr = abs(number).ToString()
    if numberStr.Length > 0 then
        // Берем первый символ строки и преобразуем его в число
        int (numberStr.[0].ToString())
    else
        None // Если строка пустая, возвращаем None

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

// Получаем последовательность чисел от пользователя
let numbers = getNumbers()

// Применяем Seq.map для нахождения первой цифры каждого элемента
let firstDigits = Seq.map firstDigit numbers

// Выводим результат
printfn "Первые цифры чисел: %A" (Seq.toList firstDigits)