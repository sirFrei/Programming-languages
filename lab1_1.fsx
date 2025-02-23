printf "Введите первый символ: "
let char_a = char(System.Console.ReadLine())
printf "Введите второй символ: "
let char_b = char(System.Console.ReadLine())
printf "Введите длинну списка: "
let x = int(System.Console.ReadLine());
let func char_a char_b x = 
    let sps = [
        for i in 1 .. x do 
            if i % 2 = 1 then 
                yield char_a
            else yield char_b]
    printfn "Итоговый список: %A" sps
func char_a char_b x


