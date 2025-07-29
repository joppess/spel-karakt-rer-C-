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
            Troll t = new Troll(hälsa: 250, UrsprungligHälsa: 100, fetma: 100, kukSmäll: 75, namn: "Lindskog");
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
                            Console.WriteLine($"Du har valt {t.Typ}");
                            Console.WriteLine(t);
                            Console.WriteLine("");
                            Console.WriteLine("Nya alternativ:");
                            Console.WriteLine("1. Attackera");
                            Console.WriteLine("2. Vila");

                            string? trollVal = Console.ReadLine();

                            switch (trollVal)
                            {
                                case "1":
                                    Console.WriteLine("Vem vill du attackera?");
                                    Console.WriteLine($"1. {m.Typ}");
                                    Console.WriteLine($"2. {mn.Typ}");
                                    string? nyTrollVal = Console.ReadLine();

                                    switch (nyTrollVal)
                                    {
                                        case "1":
                                            t.Attackera(m);
                                            Console.WriteLine($"{t.Typ} använder kuksmäll. Skada: {t.KukSmäll}. {m.Typ} hälsa innan: {m.UrsprungligHälsa}. Hälsa efter {m.Hälsa}");
                                            break;

                                        case "2":
                                            t.Attackera(mn); // utskrift på skada och hälsa!!!!!
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
                            Console.WriteLine($"Du har valt{m.Typ}");
                            Console.WriteLine(m);
                            Console.WriteLine("");
                            Console.WriteLine("Nya alternativ:");
                            Console.WriteLine("1. Attackera");
                            Console.WriteLine("2. Vila");

                            string? magikerVal = Console.ReadLine();

                            switch (magikerVal)
                            {
                                case "1":
                                    Console.WriteLine("Vem vill du attackera?");
                                    Console.WriteLine($"1. {t.Typ}");
                                    Console.WriteLine($"2. {mn.Typ}");
                                    string? nyMagikerVal = Console.ReadLine();
                                    switch (nyMagikerVal)
                                    {
                                        case "1":
                                            {
                                                m.Attackera(t);
                                            }
                                            break;
                                        case "2":
                                            {
                                                m.Attackera(mn);
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
                        else if ((answer?.ToLower() == "människa"))
                        {
                            Console.WriteLine($"Du har valt{mn.Typ}");
                            Console.WriteLine(mn);
                            Console.WriteLine("");
                            Console.WriteLine("Nya alternativ:");
                            Console.WriteLine("1. Attackera");
                            Console.WriteLine("2. Vila");

                            string? mnVal = Console.ReadLine();

                            switch (mnVal)
                            {
                                case "1":
                                    Console.WriteLine("Vem vill du attackera?");
                                    Console.WriteLine($"1. {t.Typ}");
                                    Console.WriteLine($"2. {m.Typ}");
                                    string? nyMnVal = Console.ReadLine();
                                    switch (nyMnVal)
                                    {
                                        case "1":
                                            {
                                                mn.Attackera(t);
                                            }
                                            break;
                                        case "2":
                                            {
                                                mn.Attackera(m);
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
                        break;
                    case "2":
                        Console.WriteLine("Spelet avslutas");
                        input = "exit";
                        break;
                    default:
                        Console.WriteLine("Ogiltigt svar, försök igen");
                        break;
                }
            }
        }
    }
}
