using System.Xml;

namespace MittSpel
{

    public class Troll : Karaktär
    {
        public int Fetma { get; set; }

        public override string Typ => "Troll";

        public Troll(int hälsa, int fetma, string namn)
        : base(namn, hälsa)
        {
            Fetma = fetma;

            Console.WriteLine($"Namn: {Namn}, Hälsa: {Hälsa}");
            if (fetma > 0)
            {
                Hälsa -= fetma;
            }
        }
        public override string ToString()
        {
            return $"Lider av fetma hälsa -{Fetma}hp\nNy hälsa: {Hälsa}";
        }

    }
    // lägga till attack Stor-Dase

}