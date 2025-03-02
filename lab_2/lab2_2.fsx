open System
#load "io.fsx"
let random = Random()
let x: int = abs(IO.Input "Введите кол-во элементов: ")
let countOccurrences targetNumber numbers =
    List.fold (fun count number -> if number = targetNumber then count + 1 else count) 0 numbers

// Пример использования

let numbers = [for i in 1 .. x do yield random.Next(1, 7)]
printfn "Список: %A" numbers
let target:int = IO.Input "Введите искомый элемент: "
let occurrences = countOccurrences target numbers
printfn "Число %d встречается %d раз(а)" target occurrences  // Вывод: Число 2 встречается 3 раз(а)
