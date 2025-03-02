module IO
open System.Globalization // for use dot in float numbers with russian system globalization
// Exceptions types
exception IntFailed
exception FloatFailed
exception UnsupportedTypeFailed of string
// Input of [int, float, string] with exceptions
let inline Input<^T> (message: string): ^T = 
    printf "%s" message
    let userInput: string = System.Console.ReadLine()
    if typeof<^T> = typeof<int> then
        match System.Int32.TryParse(userInput) with
        | (true, value) -> value |> unbox<^T>
        | (false, _) -> raise IntFailed
    else if typeof<^T> = typeof<float> then
        match System.Double.TryParse(userInput, NumberStyles.Any, CultureInfo.InvariantCulture) with
        | (true, value) -> value |> unbox<^T>
        | (false, _) -> raise FloatFailed
    else if typeof<^T> = typeof<string> then
        userInput |> unbox<^T>
    else
        raise (UnsupportedTypeFailed($"Wrong type: {typeof<^T>}"))
