using System;
using System.Security.Cryptography.X509Certificates;
using System.Xml;
using MittSpel;
namespace MittSpel
{

    class Program
    {

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nVälkommen till karaktärsspelet\n");
            Console.ResetColor();

            // klass = ritning (klassen Magiker)
            // objekt = en ett riktigt hus (new Magiker = man bygger själva figuren "magikern")
            // denna byggs utifrån ritningen/klassen.
            Magiker m = new Magiker(mana: 25, hälsa: 100, UrsprungligHälsa: 100, eldKlot: 50, namn: "Gandalf"); // ett nytt objekt(instans) av klassen magiker
            Troll t = new Troll(hälsa: 250, UrsprungligHälsa: 250, fetma: 100, kukSmäll: 75, namn: "Lindskog");
            Människa mn = new Människa(hälsa: 100, UrsprungligHälsa: 100, ångest: 50, kniv: 100, namn: "FetMats");


            string input = "";

            Console.ForegroundColor = ConsoleColor.Yellow;
            while (input != "exit")
            {
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("########################################");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Menyval:");
                Console.WriteLine("0. Visa karaktärer");
                Console.WriteLine("1. Välj en karaktär ");
                Console.WriteLine("2. Avsluta spelet");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("########################################");
                string? choice = Console.ReadLine();
                Console.ResetColor();
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.White;

                switch (choice)
                {
                    case "0":

                        Console.WriteLine(m.Typ);
                        Console.WriteLine(t.Typ);
                        Console.WriteLine(mn.Typ);
                        break;
                    case "1":
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Ange karaktär:");
                        string? answer = Console.ReadLine();
                        Console.ResetColor();
                        if (answer?.ToLower() == "troll")
                        {
                            if (t.ärDöd)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;

                                Console.WriteLine($"{t.Namn} är död och kan inte ageran\n");
                                break;
                            }
                            Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine($"Du har valt {t.Typ}");
                            Console.WriteLine(t);
                            Console.WriteLine("");
                            Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Nya alternativ:");
                            Console.WriteLine("1. Attackera");
                            Console.WriteLine("2. Vila");
                            Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("3. Använd lindskog special");
                            Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.Yellow;

                            string? trollVal = Console.ReadLine();
                            Console.WriteLine("");

                            switch (trollVal)
                            {
                                case "1":
                                    Console.WriteLine("Vem vill du attackera?");
                                    Console.WriteLine($"1. {m.Typ}");
                                    Console.WriteLine($"2. {mn.Typ}");
                                    string? nyTrollVal = Console.ReadLine();
                                    Console.WriteLine("");
                                    Console.ResetColor();

                                    switch (nyTrollVal)
                                    {
                                        case "1":
                                            if (m.ärDöd)
                                            {
                                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                                Console.WriteLine($"{m.Namn} är redan död och kan inte attackeras\n");
                                            }
                                            else
                                            {
                                                int tidigareHälsa = m.Hälsa;
                                                t.Attackera(m);
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine($"{t.Namn} använder kuksmäll. Skada: {t.KukSmäll}."
                                                + $" {m.Namn}s hälsa går från: {tidigareHälsa}. till {m.Hälsa}\n");
                                                if (m.ärDöd)
                                                    Console.ResetColor();
                                                {
                                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                                    Console.WriteLine($"{m.Namn} är död\n");
                                                }
                                            }
                                            break;
                                        case "2":
                                            if (mn.ärDöd)
                                            {
                                                Console.WriteLine($"{mn.Namn} är redan död och kan inte attackera\n");
                                            }
                                            else
                                            {
                                                Console.ResetColor();
                                                Console.ForegroundColor = ConsoleColor.White;
                                                int tidigareHälsa_mn = mn.Hälsa;
                                                t.Attackera(mn);
                                                Console.WriteLine($"{t.Namn} använder kuksmäll. Skada: {t.KukSmäll}."
                                                + $" {mn.Namn} hälsa går från: {tidigareHälsa_mn}. till {mn.Hälsa}\n");
                                                if (mn.ärDöd)
                                                {
                                                    Console.ResetColor();
                                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                                    Console.WriteLine($"{mn.Namn} är död\n");
                                                }
                                            }
                                            break;
                                    }
                                    break;
                                case "2":
                                    Console.ResetColor();
                                    t.Vila();
                                    break;
                                case "3":
                                    t.AnvändÖvertygelse();
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine($"\nLindskog Hälsa:{t.Hälsa}\n");
                                    Console.ResetColor();
                                    break;
                            }
                        }
                        else if (answer?.ToLower() == "magiker")
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            if (m.ärDöd)
                            {
                                Console.WriteLine($"{m.Namn} är död och kan inte agera\n");
                                break;
                            }
                            Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine($"Du har valt {m.Typ}");
                            Console.WriteLine(m);
                            Console.WriteLine("");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Nya alternativ:");
                            Console.WriteLine("1. Attackera");
                            Console.WriteLine("2. Vila");

                            string? magikerVal = Console.ReadLine();
                            Console.WriteLine("");

                            switch (magikerVal)
                            {
                                case "1":
                                    Console.WriteLine("Vem vill du attackera?");
                                    Console.WriteLine($"1. {t.Typ}");
                                    Console.WriteLine($"2. {mn.Typ}");
                                    string? nyMagikerVal = Console.ReadLine();
                                    Console.WriteLine("");
                                    Console.ResetColor();

                                    switch (nyMagikerVal)
                                    {
                                        case "1":
                                            {
                                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                                if (t.ärDöd)
                                                {
                                                    Console.WriteLine($"{t.Namn} är död och kan inte attackeras\n");
                                                }
                                                else
                                                {
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    int tidigareHälsa = t.Hälsa;
                                                    m.Attackera(t);
                                                    int faktiskSkada = tidigareHälsa - t.Hälsa;
                                                    Console.WriteLine($"{m.Namn} använder eldklot. Skada: {faktiskSkada}."
                                                    + $" {t.Namn}s hälsa går från: {tidigareHälsa}. till {t.Hälsa}\n");
                                                    if (t.ärDöd)
                                                    {
                                                        Console.ResetColor();
                                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                                        Console.WriteLine($"{t.Namn} är död\n");

                                                    }
                                                }
                                            }
                                            break;
                                        case "2":
                                            {
                                                if (mn.ärDöd)
                                                {
                                                    Console.WriteLine($"{mn.Namn} är död och kan inte attackeras\n");
                                                }
                                                else
                                                {
                                                    int tidigareHälsa_mn = mn.Hälsa;
                                                    m.Attackera(mn);
                                                    Console.WriteLine($"{m.Namn} använder eldklot. Skada: {m.EldKlot}."
                                                    + $" {mn.Namn} hälsa går från: {tidigareHälsa_mn}. till {mn.Hälsa}\n");
                                                    if (mn.ärDöd)
                                                    {
                                                        Console.ResetColor();
                                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                                        Console.WriteLine($"{mn.Namn} är död\n");
                                                        Console.ResetColor();
                                                    }
                                                }
                                            }
                                            break;
                                    }
                                    break;
                                case "2":
                                    {
                                        Console.ResetColor();
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        m.Vila();
                                        Console.ResetColor();
                                    }
                                    break;
                            }
                        }
                        else if (answer?.ToLower() == "människa")
                        {
                            if (mn.ärDöd)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine($"{mn.Namn} är död och kan inte agera\n");
                                Console.ResetColor();
                                break;
                            }
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine($"Du har valt {mn.Typ}");
                            Console.WriteLine(mn);
                            Console.WriteLine("");
                            Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Nya alternativ:");
                            Console.WriteLine("1. Attackera");
                            Console.WriteLine("2. Vila");

                            string? mnVal = Console.ReadLine();
                            Console.WriteLine("");

                            switch (mnVal)
                            {
                                case "1":
                                    Console.WriteLine("Vem vill du attackera?");
                                    Console.WriteLine($"1. {t.Typ}");
                                    Console.WriteLine($"2. {m.Typ}");
                                    string? nyMnVal = Console.ReadLine();
                                    Console.WriteLine("");
                                    switch (nyMnVal)
                                    {
                                        case "1":
                                            {
                                                if (t.ärDöd)
                                                {
                                                    Console.ResetColor();
                                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                                    Console.WriteLine($"{t.Namn} är död och kan inte attackeras\n");
                                                }
                                                else
                                                {
                                                    int tidigareHälsa = t.Hälsa;
                                                    mn.Attackera(t);
                                                    int faktiskSkada = tidigareHälsa - t.Hälsa;
                                                    Console.WriteLine($"{mn.Namn} använder kniv. Skada: {faktiskSkada}."
                                                    + $" {t.Namn}s hälsa går från: {tidigareHälsa}. till {t.Hälsa}\n");
                                                    if (t.ärDöd)
                                                    {
                                                        Console.ResetColor();
                                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                                        Console.WriteLine($"{t.Namn} är död\n");
                                                    }
                                                }
                                            }
                                            break;
                                        case "2":
                                            {
                                                if (m.ärDöd)
                                                {
                                                    Console.WriteLine($"{m.Namn} är död och kan inte attackeras\n");
                                                }
                                                else
                                                {
                                                    int tidigareHälsa_m = m.Hälsa;
                                                    mn.Attackera(m);
                                                    Console.WriteLine($"{mn.Namn} använder kniv. Skada: {mn.Kniv}."
                                                    + $" {m.Namn}s hälsa går från: {tidigareHälsa_m}. till {m.Hälsa}\n");
                                                    if (m.ärDöd)
                                                    {
                                                        Console.WriteLine($"{m.Namn} är död\n");
                                                    }
                                                }
                                            }
                                            break;
                                    }
                                    break;
                                case "2":
                                    {
                                        Console.ResetColor();
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        mn.Vila();
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Okänt karaktärsval\n!");
                        }

                        break;
                    case "2":
                        Console.WriteLine("Spelet avslutas\n");
                        input = "exit";
                        break;
                    default:
                        Console.WriteLine("Ogiltigt svar, försök igen\n");
                        Console.ResetColor();
                        break;
                }
            }
        }
    }
}
