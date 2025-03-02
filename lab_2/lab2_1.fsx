open System
#load "io.fsx"
let x: int = abs(IO.Input "Введите кол-во элементов: ")
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
