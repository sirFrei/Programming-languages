open System
#load "io.fsx"
printfn "Введите кол-во элементов списка"
let x =
    try 
        Console.ReadLine() |> int
    with
        | _ -> failwith "ОШИБКА некорректный ввод"
if x < 0 then failwith "ОШИБКА некорректный ввод"
let random = Random()
let getFirstDigit number =
    number.ToString().[0] |> string |> int

let getFirstDigitsList numbers =
    List.map getFirstDigit numbers

// Пример использования
let numbers = [for i in 1 .. x do yield random.Next(1, 1000)]
printfn "Элементы списка: %A" numbers
let firstDigits = getFirstDigitsList numbers
printfn "Первая цифра каждого элемента списка: %A" firstDigits  
