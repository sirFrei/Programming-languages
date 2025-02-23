printf "Введите натуральное число x: "
let x = int(System.Console.ReadLine())
let rec r_func x =
    if x = 0 then 0
    else x%10 + r_func(x/10)
printfn $"{r_func x}" 