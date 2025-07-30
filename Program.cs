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

            Console.WriteLine("Välkommen till karaktärsspelet");

            // klass = ritning (klassen Magiker)
            // objekt = en ett riktigt hus (new Magiker = man bygger själva figuren "magikern")
            // denna byggs utifrån ritningen/klassen.
            Magiker m = new Magiker(mana: 25, hälsa: 100, UrsprungligHälsa: 100, eldKlot: 50, namn: "Gandalf"); // ett nytt objekt(instans) av klassen magiker
            Troll t = new Troll(hälsa: 250, UrsprungligHälsa: 250, fetma: 100, kukSmäll: 75, namn: "Lindskog");
            Människa mn = new Människa(hälsa: 100, UrsprungligHälsa: 100, ångest: 50, kniv: 75, namn: "FetMats");


            string input = "";

            while (input != "exit")
            {
                Console.WriteLine("########################################");
                Console.WriteLine("Menyval:");
                Console.WriteLine("0. Visa karaktärer");
                Console.WriteLine("1. Välj en karaktär ");
                Console.WriteLine("2. Avsluta spelet");
                Console.WriteLine("#######################################");
                string? choice = Console.ReadLine();
                Console.WriteLine("");

                switch (choice)
                {
                    case "0":

                        Console.WriteLine(m.Typ);
                        Console.WriteLine(t.Typ);
                        Console.WriteLine(mn.Typ);
                        break;
                    case "1":
                        Console.WriteLine("Ange karaktär:");
                        string? answer = Console.ReadLine();
                        if (answer?.ToLower() == "troll")
                        {
                            if (t.ärDöd)
                            {
                                Console.WriteLine($"{t.Namn} är död och kan inte ageran\n");
                                break;
                            }

                            Console.WriteLine($"Du har valt {t.Typ}");
                            Console.WriteLine(t);
                            Console.WriteLine("");
                            Console.WriteLine("Nya alternativ:");
                            Console.WriteLine("1. Attackera");
                            Console.WriteLine("2. Vila");
                            Console.WriteLine("3. Använd lindskog special");

                            string? trollVal = Console.ReadLine();
                            Console.WriteLine("");
                            Console.WriteLine($"DEBUG: trollVal = '{trollVal}'");

                            switch (trollVal)
                            {
                                case "1":
                                    Console.WriteLine("Vem vill du attackera?");
                                    Console.WriteLine($"1. {m.Typ}");
                                    Console.WriteLine($"2. {mn.Typ}");
                                    string? nyTrollVal = Console.ReadLine();
                                    Console.WriteLine("");

                                    switch (nyTrollVal)
                                    {
                                        case "1":
                                            if (m.ärDöd)
                                            {
                                                Console.WriteLine($"{m.Namn} är redan död och kan inte attackeras\n");
                                            }
                                            else
                                            {
                                                int tidigareHälsa = m.Hälsa;
                                                t.Attackera(m);
                                                Console.WriteLine($"{t.Namn} använder kuksmäll. Skada: {t.KukSmäll}."
                                                + $" {m.Namn}s hälsa går från: {tidigareHälsa}. till {m.Hälsa}\n");
                                                if (m.ärDöd)
                                                {
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
                                                int tidigareHälsa_mn = mn.Hälsa;
                                                t.Attackera(mn);
                                                Console.WriteLine($"{t.Namn} använder kuksmäll. Skada: {t.KukSmäll}."
                                                + $" {mn.Namn} hälsa går från: {tidigareHälsa_mn}. till {mn.Hälsa}\n");
                                                if (mn.ärDöd)
                                                {
                                                    Console.WriteLine($"{mn.Namn} är död\n");
                                                }
                                            }
                                            break;
                                        case "3":
                                            t.AnvändÖvertygelse();
                                            Console.WriteLine("test");
                                            break;
                                    }
                                    break;
                                case "2":
                                    t.Vila();
                                    break;
                            }
                        }
                        else if (answer?.ToLower() == "magiker")
                        {
                            if (m.ärDöd)
                            {
                                Console.WriteLine($"{m.Namn} är död och kan inte agera\n");
                                break;
                            }
                            Console.WriteLine($"Du har valt {m.Typ}");
                            Console.WriteLine(m);
                            Console.WriteLine("");
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
                                    switch (nyMagikerVal)
                                    {
                                        case "1":
                                            {
                                                if (t.ärDöd)
                                                {
                                                    Console.WriteLine($"{t.Namn} är död och kan inte attackeras\n");
                                                }
                                                else
                                                {
                                                    int tidigareHälsa = t.Hälsa;
                                                    m.Attackera(t);
                                                    Console.WriteLine($"{m.Namn} använder eldklot. Skada: {m.EldKlot}."
                                                    + $" {t.Namn}s hälsa går från: {tidigareHälsa}. till {t.Hälsa}\n");
                                                    if (t.ärDöd)
                                                    {
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
                                                        Console.WriteLine($"{mn.Namn} är död\n");
                                                    }
                                                }
                                            }
                                            break;
                                    }
                                    break;
                                case "2":
                                    {
                                        m.Vila();
                                    }
                                    break;
                            }
                        }
                        else if (answer?.ToLower() == "människa")
                        {
                            if (mn.ärDöd)
                            {
                                Console.WriteLine($"{mn.Namn} är död och kan inte agera\n");
                                break;
                            }
                            Console.WriteLine($"Du har valt {mn.Typ}");
                            Console.WriteLine(mn);
                            Console.WriteLine("");
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
                                                    Console.WriteLine($"{t.Namn} är död och kan inte attackeras\n");
                                                }
                                                else
                                                {
                                                    int tidigareHälsa = t.Hälsa;
                                                    mn.Attackera(t);
                                                    Console.WriteLine($"{mn.Namn} använder kniv. Skada: {mn.Kniv}."
                                                    + $" {t.Namn}s hälsa går från: {tidigareHälsa}. till {t.Hälsa}\n");
                                                    if (t.ärDöd)
                                                    {
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
                        break;
                }
            }
        }
    }
}
