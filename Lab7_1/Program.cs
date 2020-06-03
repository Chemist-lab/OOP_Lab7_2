using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Lab7_1
{
    class Program
    {
        private static string FileName = "Data.json";
        private static string FilePath = @"Data.json";
        static void Main(string[] args)
        {
            while(true)
            {
                Console.WriteLine("╔════════════╤══════════════════════════════════════════╗");
                Console.WriteLine("   Hot key   │                Function       ");
                Console.WriteLine("╠════════════╪══════════════════════════════════════════╣");
                Console.WriteLine("      A      │              Add phone  ");
                Console.WriteLine("╠════════════╪══════════════════════════════════════════╣");
                Console.WriteLine("      C      │            Change phone info  ");
                Console.WriteLine("╠════════════╪══════════════════════════════════╣");
                Console.WriteLine("      D      │              Delete phone  ");
                Console.WriteLine("╠════════════╪══════════════════════════════════════════╣");
                Console.WriteLine("      T      │  Show all phones sort by memory & year ");
                Console.WriteLine("╠════════════╪══════════════════════════════════════════╣");
                Console.WriteLine("      F      │      Show all phones sort by price ");
                Console.WriteLine("╠════════════╪══════════════════════════════════════════╣");
                Console.WriteLine("    Space    │            Clear console  ");
                Console.WriteLine("╠════════════╪══════════════════════════════════════════╣");
                Console.WriteLine("     Esc     │             Exit program  ");
                Console.WriteLine("╚════════════╧══════════════════════════════════════════╝");

                if (!File.Exists(FileName))
                {
                    File.Create(FileName).Close();
                }
                var data = JsonConvert.DeserializeObject<List<Phones>>(File.ReadAllText(FilePath));
                int menuselect = 0;
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.A:
                        menuselect = 1;
                        break;
                    case ConsoleKey.S:
                        menuselect = 2;
                        break;
                    case ConsoleKey.T:
                        menuselect = 3;
                        break;
                    case ConsoleKey.Escape:
                        menuselect = 4;
                        break;
                    case ConsoleKey.D:
                        menuselect = 5;
                        break;
                    case ConsoleKey.F:
                        menuselect = 6;
                        break;
                }

                if (menuselect == 1)
                {
                    Console.Clear();

                    Console.WriteLine("Enter Phone Data\n");
                    Console.WriteLine("Phone model: ");
                    string pModel = Console.ReadLine();
                    Console.WriteLine("Phone producer: ");
                    string pProducer = Console.ReadLine();
                    Console.WriteLine("Phone year: ");
                    string pYear = Console.ReadLine();
                    Console.WriteLine("Phone diagonal: ");
                    string pDiag = Console.ReadLine();
                    Console.WriteLine("Phone memory: ");
                    string pMemory = Console.ReadLine();
                    Console.WriteLine("Phone Price: ");
                    string pPrice = Console.ReadLine();

                    if (pModel != null && pProducer != null && pYear != null && pDiag != null && pMemory != null && pPrice !=null)
                    {
                        data.Add(new Phones { Model = pModel, Producer = pProducer, Year = pYear, Diagonal = pDiag, Memory = pMemory, Price = pPrice });
                    }
                    else
                    {
                        Console.WriteLine("          Error\nSome fileds are empty.\nTry again");
                    }
                    Console.Clear();
                }

                if (menuselect == 2)
                {
                    Console.Clear();
                    Console.WriteLine("Enter Model of search phone: ");
                    string id = Console.ReadLine();
                    if (Console.ReadLine() != null)
                    {
                        Console.Clear();
                        Phones FoundData = data.Find(found => found.Model == id);
                        if (FoundData != null)
                        {
                            Console.Clear();
                            Console.WriteLine("╔════════════╤════════════╤══════════╤═════════════╤═════════════╤══════════════╗");
                            Console.WriteLine("    Model    │  Producer  │   Year   │   Diagonal  │   Memory    │    Price");
                            Console.WriteLine("╠════════════╪════════════╪══════════╪═════════════╪═════════════╪══════════════╣");
                            Console.WriteLine("{0,12} {1, 12} {2, 8} {3, 11} {4, 12} {5, 12}", FoundData.Model, FoundData.Producer, FoundData.Year, FoundData.Diagonal, FoundData.Memory, FoundData.Price);
                            Console.WriteLine("╚════════════╧════════════╧══════════╧═════════════╧═════════════╧══════════════╝");


                            Console.WriteLine("\nTo edit press 'E'");
                            Console.WriteLine("\n\nTo edit press 'D'");
                            if (Console.ReadKey().Key == ConsoleKey.E)
                            {
                                Console.Clear();
                                Console.WriteLine("Edit Phone Data\n");
                                Console.WriteLine("Phone model: ");
                                string pModel = Console.ReadLine();
                                Console.WriteLine("Phone producer: ");
                                string pProducer = Console.ReadLine();
                                Console.WriteLine("Phone year: ");
                                string pYear = Console.ReadLine();
                                Console.WriteLine("Phone diagonal: ");
                                string pDiag = Console.ReadLine();
                                Console.WriteLine("Phone memory: ");
                                string pMemory = Console.ReadLine();
                                Console.WriteLine("Phone Price: ");
                                string pPrice = Console.ReadLine();

                                if (pModel == null || pProducer == null || pYear == null || pDiag == null || pMemory == null)
                                {
                                    Console.WriteLine("          Error\nSome fileds are empty.\nTry again");
                                }
                                FoundData.Model = pModel;
                                FoundData.Producer = pProducer;
                                FoundData.Year = pYear;
                                FoundData.Diagonal = pDiag;
                                FoundData.Memory = pMemory;
                                FoundData.Price = pPrice;
                                Console.Clear();
                                Console.WriteLine("╔════════════╤════════════╤══════════╤═════════════╤═════════════╤══════════════╗");
                                Console.WriteLine("    Model    │  Producer  │   Year   │   Diagonal  │   Memory    │    Price");
                                Console.WriteLine("╠════════════╪════════════╪══════════╪═════════════╪═════════════╪══════════════╣");
                                Console.WriteLine("{0,12} {1, 12} {2, 8} {3, 11} {4, 12} {5, 12}", FoundData.Model, FoundData.Producer, FoundData.Year, FoundData.Diagonal, FoundData.Memory, FoundData.Price);
                                Console.WriteLine("╚════════════╧════════════╧══════════╧═════════════╧═════════════╧══════════════╝");
                            }
                            if (Console.ReadKey().Key == ConsoleKey.D)
                            {
                                data.RemoveAll(x => x.Model == id);
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Error\n\n" +
                        "Plane not found");
                        }


                    }
                }

                if (menuselect == 3)
                {
                    Console.Clear();
                    Console.WriteLine("╔════════════╤════════════╤══════════╤═════════════╤═════════════╤══════════════╗");
                    Console.WriteLine("    Model    │  Producer  │   Year   │   Diagonal  │   Memory    │    Price");
                    Console.WriteLine("╠════════════╪════════════╪══════════╪═════════════╪═════════════╪══════════════╣");
                    data.Sort(new Phones.SortByMemoryAndYear());
                    for (int i = 0; i < data.Count; i++)
                    {
                        Console.WriteLine("{0,12} {1, 12} {2, 8} {3, 11} {4, 12} {5, 12}", data[i].Model, data[i].Producer, data[i].Year, data[i].Diagonal, data[i].Memory, data[i].Price);
                        Console.WriteLine("╠════════════╪════════════╪══════════╪═════════════╪═════════════╪══════════════╣");
                    }
                    Console.WriteLine("╚════════════╧════════════╧══════════╧═════════════╧═════════════╧══════════════╝");
                    if (Console.ReadKey().Key == ConsoleKey.Spacebar)
                    {
                        Console.Clear();
                    }
                }

                if (menuselect == 6)
                {
                    Console.Clear();
                    Console.WriteLine("╔════════════╤════════════╤══════════╤═════════════╤═════════════╤══════════════╗");
                    Console.WriteLine("    Model    │  Producer  │   Year   │   Diagonal  │   Memory    │    Price");
                    Console.WriteLine("╠════════════╪════════════╪══════════╪═════════════╪═════════════╪══════════════╣");
                    data.Sort(new Phones.SortByPrice());
                    for (int i = 0; i < data.Count; i++)
                    {
                        Console.WriteLine("{0,12} {1, 12} {2, 8} {3, 11} {4, 12} {5, 12}", data[i].Model, data[i].Producer, data[i].Year, data[i].Diagonal, data[i].Memory, data[i].Price);
                        Console.WriteLine("╠════════════╪════════════╪══════════╪═════════════╪═════════════╪══════════════╣");
                    }
                    Console.WriteLine("╚════════════╧════════════╧══════════╧═════════════╧═════════════╧══════════════╝");
                    if (Console.ReadKey().Key == ConsoleKey.Spacebar)
                    {
                        Console.Clear();
                    }
                }

                if (menuselect == 4)
                {
                    Environment.Exit(0);
                }

                if (menuselect == 5)
                {
                    Console.Clear();
                    Console.WriteLine("Enter id of plane to delete: ");
                    string id = Console.ReadLine();
                    if (Console.ReadLine() != null)
                    {
                        Console.Clear();
                        Phones FoundData = data.Find(found => found.Model == id);
                        if (FoundData != null)
                        {
                            Console.WriteLine("╔════════════╤════════════╤══════════╤═════════════╤═════════════╤══════════════╗");
                            Console.WriteLine("    Model    │  Producer  │   Year   │   Diagonal  │   Memory    │    Price");
                            Console.WriteLine("╠════════════╪════════════╪══════════╪═════════════╪═════════════╪══════════════╣");
                            Console.WriteLine("{0,12} {1, 12} {2, 8} {3, 11} {4, 12} {5, 12}", FoundData.Model, FoundData.Producer, FoundData.Year, FoundData.Diagonal, FoundData.Memory, FoundData.Price);
                            Console.WriteLine("╚════════════╧════════════╧══════════╧═════════════╧═════════════╧══════════════╝");
                            data.RemoveAll(x => x.Model == id);
                            Console.WriteLine("This information has been deleted");
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Error\n\n" +
                        "Plane not found");
                        }


                    }
                }

                if (Console.ReadKey().Key == ConsoleKey.Spacebar)
                {
                    Console.Clear();
                }

                string serialize = JsonConvert.SerializeObject(data, Formatting.Indented);
                if (serialize.Count() > 1)
                {
                    if (!File.Exists(FileName))
                    {
                        File.Create(FileName).Close();
                    }
                    File.WriteAllText(FilePath, serialize, Encoding.UTF8);
                }
            }
        }
    }

    public class Phones
    {
        public string Model { get; set; }
        public string Producer { get; set; }
        public string Year { get; set; }
        public string Diagonal { get; set; }
        public string Memory { get; set; }
        public string Price { get; set; }
        public int CompareTo(Phones p)
        {
            return Convert.ToDouble(this.Price).CompareTo(Convert.ToDouble(p.Price));
        }
        public class SortByPrice : IComparer<Phones>
        {
            public int Compare(Phones p1, Phones p2)
            {
                float fl1 = (float)Convert.ToDouble(p1.Price);
                float fl2 = (float)Convert.ToDouble(p2.Price);
                if (fl1 > fl2)
                    return 1;
                else if (fl1 < fl2)
                    return -1;
                else
                    return 0;
            }
        }
        public class SortByMemoryAndYear : IComparer<Phones>
        {
            public int Compare(Phones p1, Phones p2)
            {
                float fl1 = (float)Convert.ToDouble(p1.Memory);
                float fl2 = (float)Convert.ToDouble(p2.Memory);
                float c1 = (float)Convert.ToDouble(p1.Year);
                float c2 = (float)Convert.ToDouble(p2.Year);
                if (fl1 < fl2)
                    return 1;
                else if (fl1 > fl2)
                    return -1;
                else if (c1 < c2)
                    return 1;
                else if (c1 > c2)
                    return -1;
                else
                    return 0;
            }
        }
        public class ArrayPhones : IEnumerable
        {
            int cnt = 0;
            Phones[] mas;
            public ArrayPhones(int count = 10)
            {
                mas = new Phones[count];
            }
            public void Add(Phones o)
            {
                if (cnt >= 10)
                {
                    return;
                }
                mas[cnt] = o;
                cnt++;
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                for (int i = 0; i < cnt; ++i) yield return mas[i];
            }
            public void Sort()
            {
                Array.Sort(mas, new Phones.SortByMemoryAndYear());
            }
        }
    }

}
