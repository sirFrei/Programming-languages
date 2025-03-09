open System
open System.IO

// Функция для поиска всех текстовых файлов в каталоге и его подкаталогах
let findTextFiles directory =
    try
        // Проверяем, существует ли каталог
        if Directory.Exists(directory) then
            // Ищем все файлы с расширением .txt
            let txtFiles = Directory.GetFiles(directory, "*.txt", SearchOption.AllDirectories)
            // Выводим пути к файлам
            for file in txtFiles do
                printfn "%s" file
        else
            printfn "Каталог не существует: %s" directory
    with
    | :? UnauthorizedAccessException -> printfn "Нет доступа к каталогу: %s" directory
    | :? PathTooLongException -> printfn "Слишком длинный путь: %s" directory
    | :? IOException -> printfn "Ошибка ввода-вывода: %s" directory

// Функция для ввода пути к каталогу
let getDirectoryPath () =
    printfn "Введите путь к каталогу:"
    let path = Console.ReadLine()
    if Directory.Exists(path) then
        path
    else
        printfn "Указанный каталог не существует. Попробуйте снова."
        getDirectoryPath()

// Получаем путь к каталогу от пользователя
let directoryPath = getDirectoryPath()

// Ищем и выводим текстовые файлы
findTextFiles directoryPath