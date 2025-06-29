using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace AllInOne
{
    [Serializable]
    public class BaggageItem
    {
        public string Name;
        public double Weight;
    }

    [Serializable]
    public class PassengerBaggage
    {
        public List<BaggageItem> Items = new();
        public double Average => Items.Count > 0 ? Items.Average(i => i.Weight) : 0;
    }

    [Serializable]
    public class BaggageData
    {
        public List<PassengerBaggage> Passengers = new();
    }

    public static class AllTasks
    {
        private static Random _rand = new Random();

        public static void Task1()
        {
            const int counter = 10;
            var nums = Enumerable.Range(0, counter)
                                    .Select(_ => _rand.Next(-100, 101))
                                    .ToList();

            File.WriteAllLines("input1.txt", nums.Select(n => n.ToString()));

            int half = nums.Count / 2;
            int result = nums.Take(half).Sum() - nums.Skip(half).Sum();
            File.WriteAllText("output1.txt", result.ToString());
            Console.WriteLine($"Task1 result: {result}");
        }

        public static void Task2()
        {
            const int lines = 5, perLine = 4;
            var sb = new StringBuilder();
            for (int i = 0; i < lines; i++)
            {
                sb.Clear();
                for (int j = 0; j < perLine; j++)
                {
                    sb.Append(_rand.Next(-50, 51));
                    if (j < perLine - 1) sb.Append(' ');
                }
                File.AppendAllText("input2.txt", sb + Environment.NewLine);
            }

            int sum = File.ReadAllLines("input2.txt")
                          .SelectMany(l => l.Split(' ', StringSplitOptions.RemoveEmptyEntries))
                          .Select(int.Parse)
                          .Sum();

            File.WriteAllText("output2.txt", sum.ToString());
            Console.WriteLine($"Task2 sum: {sum}");
        }

        public static void Task3()
        {
            var sample = new[]
            {
                "стр",
                "строка в которой чуть больше букав",
                "Очень очень длинная строка в которой так много букв что она выйдет за экран и потеряется там"
            };
            File.WriteAllLines("input3.txt", sample);

            var lines = File.ReadAllLines("input3.txt");
            if (lines.Length == 0) return;

            string shortest = lines.OrderBy(s => s.Length).First();
            string longest = lines.OrderByDescending(s => s.Length).First();
            File.WriteAllLines("output3.txt", new[] { shortest, longest });
            Console.WriteLine($"Task3 shortest: {shortest}");
            Console.WriteLine($"Task3 longest: {longest}");
        }

        public static void Task4()
        {
            const int counter = 20;
            using (var bw = new BinaryWriter(File.Create("input4.bin")))
                for (int i = 0; i < counter; i++)
                    bw.Write(_rand.Next(-100, 101));

            var evens = new List<int>();
            using (var br = new BinaryReader(File.OpenRead("input4.bin")))
                while (br.BaseStream.Position < br.BaseStream.Length)
                {
                    int n = br.ReadInt32();
                    if (n % 2 == 0) evens.Add(n);
                }

            using (var bw = new BinaryWriter(File.Create("output4.bin")))
                foreach (var n in evens) bw.Write(n);

            Console.WriteLine($"Task4 even counter: {evens.Count}");
        }

        public static void Task5()
        {
            double m = double.Parse(File.ReadAllText("input5_tolerance.txt"));
            var serializer = new XmlSerializer(typeof(BaggageData));
            BaggageData data;
            using (var fs = new FileStream("input5.xml", FileMode.Open))
                data = (BaggageData)serializer.Deserialize(fs);

            double overall = data.Passengers.SelectMany(p => p.Items).Average(i => i.Weight);
            var selected = new List<int>();
            for (int i = 0; i < data.Passengers.Count; i++)
                if (Math.Abs(data.Passengers[i].Average - overall) <= m)
                    selected.Add(i + 1);

            File.WriteAllText("output5.txt", string.Join(" ", selected));
            Console.WriteLine("Task5 done");
        }

        public static void Task6()
        {
            Console.Write("\nTask6: Enter item for delete");
            string e = Console.ReadLine().Trim();
            Console.Write("Input L items via space: ");
            var list = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

            File.WriteAllLines("input6.txt", new[] { e, string.Join(" ", list) });
            var result = list.Where(x => x != e).ToList();
            File.WriteAllText("output6.txt", string.Join(" ", result));
            Console.WriteLine("Task6 result: " + string.Join(" ", result));
        }

        public static void Task7()
        {
            Console.Write("\nTask7: Input numbers via space ");
            var tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var linkedList = new LinkedList<string>(tokens);
            File.WriteAllText("input7.txt", string.Join(" ", linkedList));

            using var writer = new StreamWriter("output7.txt");
            for (var node = linkedList.Last; node != null; node = node.Previous)
            {
                writer.WriteLine(node.Value);
                Console.WriteLine(node.Value);
            }
        }

        public static void Task8()
        {
            var allFirms = File.ReadAllText("firms8.txt")
                               .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var purchases = File.ReadAllLines("purchases8.txt")
                                .Select(line => new HashSet<string>(line.Split(' ', StringSplitOptions.RemoveEmptyEntries)))
                                .ToList();

            var a = new HashSet<string>(purchases[0]);
            var b = new HashSet<string>(purchases[0]);
            foreach (var set in purchases.Skip(1))
            {
                a.IntersectWith(set);
                b.UnionWith(set);
            }
            var c = new HashSet<string>(allFirms);
            c.ExceptWith(b);

            File.WriteAllLines("output8_a.txt", a);
            File.WriteAllLines("output8_b.txt", b);
            File.WriteAllLines("output8_c.txt", c);
            Console.WriteLine($"Task8: a={a.Count}, b={b.Count}, c={c.Count}");
        }

        public static void Task9()
        {
            Console.Write("\nTask9: Input number of strings: ");
            int m = int.Parse(Console.ReadLine());
            var lines = new List<string>();
            for (int i = 0; i < m; i++)
            {
                Console.Write($"String {i + 1}: ");
                lines.Add(Console.ReadLine());
            }
            File.WriteAllLines("input9.txt", lines);

            char[] voiced = "бвгджз".ToCharArray();
            var found = new HashSet<char>();
            foreach (var line in lines)
                foreach (var c in line.ToLowerInvariant())
                    if (voiced.Contains(c)) found.Add(c);

            var ordered = found.OrderBy(c => c).Select(c => c.ToString());
            File.WriteAllLines("output9.txt", ordered);
            Console.WriteLine("Task9 done");
        }


        public static void Task10()
        {
            var lines = File.ReadAllLines("input10.txt");
            int n = int.Parse(lines[0]);
            var names = lines.Skip(1).Take(n).ToList();

            var counts = new Dictionary<string, int>();
            var logins = new List<string>();
            foreach (var full in names)
            {
                var surname = full.Split(' ')[0];
                if (!counts.ContainsKey(surname)) counts[surname] = 0;
                counts[surname]++;
                logins.Add(surname + (counts[surname] > 1 ? counts[surname].ToString() : ""));
            }

            File.WriteAllLines("output10.txt", logins);
            Console.WriteLine("Task10 done, logins written to output10.txt");
        }
    }

    public class Program
    {
        public static void Main()
        {
            AllTasks.Task1();
            AllTasks.Task2();
            AllTasks.Task3();
            AllTasks.Task4();
            AllTasks.Task5();
            AllTasks.Task6();
            AllTasks.Task7();
            AllTasks.Task8();
            AllTasks.Task9();
            AllTasks.Task10();
            Console.WriteLine("\nAll Tasks Completed.");
        }
    }
}
