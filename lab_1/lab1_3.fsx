printfn $"Введите первое комплексное число вида a + b*i"
printf "Введите float a: "
let a1 = float(System.Console.ReadLine())
printf "Введите float b: "
let b1 = float(System.Console.ReadLine())
printfn $"Введите второе комплексное число вида a + b*i"
printf "Введите float a: "
let a2 = float(System.Console.ReadLine())
printf "Введите float b: "
let b2 = float(System.Console.ReadLine())
printf "Введите операнд (+, -, *, /): "
let operand = char(System.Console.ReadLine())
let sum a1 b1 a2 b2 = [a1 + a2;b1 + b2]
let razn a1 b1 a2 b2 = [a1 - a2; b1 - b2] 
let multi a1 b1 a2 b2 = [a1*a2 - b1*b2; a1*b2 + b1*a2]
let division a1 b1 a2 b2 =[(a1*a2 - b1*(-1.0*b2))/(a2*a2 - b2*b2); a1*(-1.0*b2) + b1*a2/(a2*a2 - b2*b2)]
let func a1 b1 a2 b2 operand =
    if operand = '+' then sum a1 b1 a2 b2
    elif operand = '-' then razn a1 b1 a2 b2
    elif operand = '*' then multi a1 b1 a2 b2
    elif operand = '/' then division a1 b1 a2 b2
    else [0.0;0.0]
let answer = func a1 b1 a2 b2 operand
let sign = if answer[1] < 0.0 then "-" else "+"
printfn $"Ответ: {answer[0]} {sign} {answer[1]}i"