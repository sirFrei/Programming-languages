

class Program
{


    public class OneString
    {
        public OneString(OneString previousString)
        {

            this.FString = previousString.FString;


        }


        public OneString(string firstString)
        {
            this.FString = firstString;

        }

        protected string FString { get; set; }

        public string FLSymbols()
        {
            if (FString != "")
            {
                return FString[0].ToString() + FString[FString.Length - 1].ToString();
            }
            return FString;

        }

        public override string ToString()
        {
            return FString;
        }
    }

    public class DoubleString : OneString
    {
        public string SecondString { get; set; }

        public DoubleString(string firstString, string secondString)
            : base(firstString)
        {

            SecondString = secondString;

        }

        public string SumStrings()
        {
            return FString + SecondString;
        }

        public string String_Move() //Получение строки без символов из второй строки
        {
            string res = "";
            bool flag = true;

                for (int i = 0; i < FString.Length; i++)
                {
                    flag = true;   
                    for (int g = 0; g < SecondString.Length; g++)
                        {
                            if (FString[i] == SecondString[g]) flag = false;
                        }
                    if (flag) res += FString[i];

                }
                return res;

        }


    }


    static void Main()
    {
        Console.WriteLine("Введите строку");
        OneString string1 = new OneString(Console.ReadLine());
        OneString string2 = new OneString(string1);

        Console.WriteLine("Строка 1: " + string1.ToString());
        Console.WriteLine("Строка 1: " + string2.ToString());
        Console.WriteLine("Строка 1 First and last symbols: " + string2.FLSymbols());

        Console.WriteLine("Введите строку");
        string fs = Console.ReadLine();
        Console.WriteLine("Введите вторую строку");
        string ss = Console.ReadLine();

        DoubleString string3 = new DoubleString(fs,ss);
        Console.WriteLine("Строка 2: "+string3);
        Console.WriteLine("Сумма строк 1 и 2: " + string3.SumStrings());
        Console.WriteLine("Строка 1 без символов строки 2" + string3.String_Move());
        Console.WriteLine("Строка 1 First and last symbols: " + string3.FLSymbols());


    }
}
