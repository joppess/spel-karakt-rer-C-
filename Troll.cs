using System.Xml;

namespace MittSpel
{

    public class Troll : Karaktär
    {
        public int Fetma { get; set; }
        public int KukSmäll { get; set; }

        public override string Typ => "Troll"; // => är samma som  get {return "Gandalf";}

        public Troll(int hälsa, int fetma, int kukSmäll, string namn)
        : base(namn, hälsa)
        {
            Fetma = fetma;

            KukSmäll = kukSmäll;

            Console.WriteLine($"Namn: {Namn}, Hälsa: {Hälsa}, attack: {KukSmäll}");
            if (fetma > 0)
            {
                Hälsa -= fetma;
            }
        }
        public override string ToString()
        {
            return $"Lider av fetma hälsa -{Fetma}hp\nNy hälsa: {Hälsa}";
        }

        public void Attackera(Karaktär mål) // du måste skicka in en karaktär att attacker, "mål" är objektet som attackeras
        {
            Console.WriteLine($"{Namn} attackerar {mål.Namn}!"); //måste göra detta för varje .cs fil för att attackerna ska vara speciella.
            mål.TaSkada(KukSmäll);
        }

    }
    // lägg till övertygelse +20 i skada så det blir mindre skada totalt

}