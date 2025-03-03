open System
#load "io.fsx"
let random = Random()
printf "Введите кол-во элементов списка: "
let x =
    try 
        Console.ReadLine() |> int
    with
        | _ -> failwith "ОШИБКА некорректный ввод"
if x < 0 then failwith "ОШИБКА некорректный ввод"
let countOccurrences targetNumber numbers =
    List.fold (fun count number -> if number = targetNumber then count + 1 else count) 0 numbers

// Пример использования

let numbers = [for i in 1 .. x do yield random.Next(1, 7)]
printfn "Список: %A" numbers
printf "Введите искомый элемент: "
let target =
    try 
        Console.ReadLine() |> int
    with
        | _ -> failwith "ОШИБКА некорректный ввод"
let occurrences = countOccurrences target numbers
printfn "Число %d встречается %d раз(а)" target occurrences  // Вывод: Число 2 встречается 3 раз(а)
