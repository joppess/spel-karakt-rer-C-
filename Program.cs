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
            Magiker m = new Magiker(mana: 25, hälsa: 100, eldKlot: 50, namn: "Gandalf"); // ett nytt objekt(instans) av klassen magiker
            Troll t = new Troll(hälsa: 250, fetma: 100, kukSmäll: 75, namn: "Lindskog");
            Människa mn = new Människa(hälsa: 100, ångest: 50, kniv: 75, namn: "FetMats");


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
                        string? answer = Console.ReadLine();
                        if (answer?.ToLower() == "Troll")
                        {
                            Console.WriteLine(t);
                            Console.WriteLine($"Du har valt{t.Typ}");
                            Console.WriteLine("Nya alternativ:");
                            Console.WriteLine("1. Attackera");
                            Console.WriteLine("2. Vila");

                            string? trollval = Console.ReadLine();

                            switch (trollval)
                            {
                                case "1":
                                    //lägg in attack
                                    break;
                                case "2":
                                    //lägg in vila
                                    break;
                            }
                        }
                        else if (answer?.ToLower() == "Magiker")
                        {
                            Console.WriteLine(m);
                            Console.WriteLine($"Du har valt{t.Typ}");
                            Console.WriteLine("Nya alternativ:");
                            Console.WriteLine("1. Attackera");
                            Console.WriteLine("2. Vila");

                            string? magikerVal = Console.ReadLine();

                            switch (magikerVal)
                            {
                                case "1":
                                    break;
                                //lägg in attack
                                case "2":
                                    //lägg in vila
                                    break;
                            }
                        }
                        break;
                    case "2":
                        Console.WriteLine("Spelet avslutas");
                        input = "exit";
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    case "5":
                        break;
                    case "6":
                        break;
                    default:
                        Console.WriteLine("Ogiltigt svar, försök igen");
                        break;



                }

            }





        }

    }
}
