using projekt___aplikace_pro_spravu_domacich_ukolu;
using System;
using System.Collections.Generic;
class Program
{
    static List<domaciUkol> ukoly = new List<domaciUkol>();

    static void Main(string[] args)
    {
        bool pokracovat = true;
        int untitledPocet = 0;

        while (pokracovat)
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Aplikace pro správu domácích úkolů");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("----------------------------------");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            
            Console.WriteLine("1 - přidat nový ukol");
            Console.WriteLine("2 - zobrazit všechny ukoly");
            Console.WriteLine("3 - vymazat ukol");
            Console.WriteLine("4 - konec");

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("----------------------------------");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("input: ");

            var volba = Console.ReadKey();
            switch (volba.KeyChar)
            {
                case '1':
                    untitledPocet++;
                    PridatUkol(untitledPocet);
                    break;
                case '2':
                    ZobrazitUkoly();
                    break;
                case '3':
                    OdstranitUkol();
                    break;
                case '4':
                    pokracovat = false;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("\n----------------------------------");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("neplatny input");
                    
                    Thread.Sleep(1500);
                    break;
            }
        }
    }

    static void PridatUkol(int pocet)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("zadej název úkolu: ");
        string nazev = Console.ReadLine();
        if (nazev == "")
        {
            nazev = "ukol_" + pocet;
        }

        Console.WriteLine("----------------------------------");
        Console.Write("zadej popis úkolu: ");
        string popis = Console.ReadLine();
        if (popis == "")
        {
            
            popis = "bez popisu";
        }

        Console.WriteLine("----------------------------------");
        Console.Write("zadej termín úkolu (ve formátu YYYY-MM-DD): ");
        DateTime termin;
        while (!DateTime.TryParse(Console.ReadLine(), out termin))
        {
            Console.ForegroundColor= ConsoleColor.Red;
            Console.WriteLine("neplatný format, zkus to zadat znovu");
            Console.ForegroundColor = ConsoleColor.Yellow;
        }

        domaciUkol novyUkol = new domaciUkol
        {
            Nazev = nazev,
            Popis = popis,
            Termin = termin
        };

        ukoly.Add(novyUkol);
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("ukol byl pridan");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Thread.Sleep(2000);
    }

    static void ZobrazitUkoly()
    {
        Console.Clear();
        if (ukoly.Count == 0)
        {
            Console.WriteLine("zadne ukoly nejsou k dispozici");
        }
        else
        {
            Console.WriteLine("seznam ukolu:");
            Console.WriteLine("----------------------------------");
            for (int i = 0; i < ukoly.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {ukoly[i]}");
            }
        }
        Console.WriteLine("----------------------------------");
        Console.WriteLine("stiskni nejakou klavesu pro navrat do menu");
        Console.ReadKey();
    }

    static void OdstranitUkol()
    {
        Console.Clear();
        if (ukoly.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("zadne ukoly k odstraneni");
            Console.ForegroundColor = ConsoleColor.Yellow;
        }
        else
        {
            if (ukoly.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("zadne ukoly nejsou k dispozici");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Thread.Sleep(1000);
            }
            else
            {
                Console.WriteLine("seznam ukolu:");
                Console.WriteLine("----------------------------------");
                for (int i = 0; i < ukoly.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {ukoly[i]}");
                }
            }
            Console.WriteLine("----------------------------------");
            Console.Write("zadej cislo ukolu k odstraneni: ");
            int index;
            while (!int.TryParse(Console.ReadLine(), out index) || index < 1 || index > ukoly.Count)
            {
                Console.WriteLine("neplatne cislo, zkus to znovu: ");
            }

            ukoly.RemoveAt(index - 1);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("ukol byl odstranen");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Thread.Sleep(2000);
        }
    }
}
