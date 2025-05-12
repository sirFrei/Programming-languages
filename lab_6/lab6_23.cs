internal class Program
{
    public class Time
    {
        private byte hours { get; set; }
        private byte minutes { get; set; }

        public Time(byte hours, byte minutes)
        {
            if (minutes > 59)
            {

            }
            this.hours = hours;
            this.minutes = minutes;

        }
        public Time addminutes(Time time, uint additionalMinutes)
        {
            time.hours = (byte)(time.hours + (time.minutes + additionalMinutes) / 60);
            time.minutes = (byte)((time.minutes + additionalMinutes) % 60);
            return time;
        }
        public override string ToString()
        {
            return (hours.ToString() + " часов " + minutes.ToString() + " минут");
        }

        public static Time operator ++(Time time)
        {
            return time.addminutes(time, 1);
        }
        public static Time operator --(Time time)
        {
            if (time.minutes == 0)
            {
                if (time.hours == 0)
                {
                    Console.WriteLine("Время не может быть отрицательным");
                    return time;
                }
                time.hours -= 1;
                time.minutes = 59;

            }
            else
            {
                time.minutes -= 1;
            }
            return time;
        }

        public static explicit operator byte(Time time)
        {
            return time.hours;
        }
        public static implicit operator bool(Time time)
        {
            return (time.hours != 0 && time.minutes != 0);
        }
    }
    public static byte TakeAndTestForByte()
    {
        string s = Console.ReadLine();
        byte b;
        if (byte.TryParse(s, out b))
        {
            return b;
        }
        else
        {
            Console.WriteLine(s + " не целое положительное число. Введите целое положительное число:");
            return TakeAndTestForByte();
        }
        
    }
    public static uint TakeAndTestForUint()
    {
        string s = Console.ReadLine();
        uint u;
        if (uint.TryParse(s, out u))
        {
            return u;
        }
        else
        {
            Console.WriteLine(s + " не целое положительное число. Введите целое положительное число:");
            return TakeAndTestForUint();
        }

    }
    private static void Main(string[] args)
    {
        Console.WriteLine("Введите часы:");
        byte hours = TakeAndTestForByte();
        Console.WriteLine("Введите Минуты:");
        byte minutes = TakeAndTestForByte();
        Time time = new Time(hours, minutes);
        Console.WriteLine("Введено время "+ time.ToString());
        Console.WriteLine("Введите минуты для добавления");
        time.addminutes(time,TakeAndTestForUint());
        Console.WriteLine("Результат:"+ time.ToString());
        Console.WriteLine("Добавляем одну минуту");
        time++;
        Console.WriteLine(time.ToString());
        Console.WriteLine("Вычитаем минуту");
        time--;
        Console.WriteLine(time.ToString());
        

    }

}
