using System.Runtime.ConstrainedExecution;
using System.Xml;

namespace MittSpel
{

    public class Troll : Karaktär
    {
        public int Fetma { get; set; }
        public int KukSmäll { get; set; }
        public bool Entremedd { get; set; }
        public bool AnväntÖvertygelse { get; set; } = false;

        public override string Typ => "Troll"; // => är samma som  get {return "Gandalf";}

        public Troll(int hälsa, int UrsprungligHälsa, int fetma, int kukSmäll, string namn)
        : base(namn, hälsa, UrsprungligHälsa)
        {
            Fetma = fetma;
            KukSmäll = kukSmäll;

            if (fetma > 0)
            {
                Hälsa -= fetma;
            }
        }
        public void AnvändÖvertygelse()
        {
            AnväntÖvertygelse = true;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"{Namn} övertygar fiende att göra 25 mindre skada i nästa anfall.");
            Console.ResetColor();
        }
        public override void TaSkada(int skada)
        {
            if (AnväntÖvertygelse)
            {
                skada -= 25;
                if (skada < 0)
                    skada = 0;
                AnväntÖvertygelse = false; // för den bara ska användas en gång sätter vi false igen
                Console.WriteLine($"{Namn} använde övertygelse och tog bara {skada} i skada.");
            }
            else
            {
                Console.WriteLine($"{Namn} tar {skada} i skada.");
            }
            base.TaSkada(skada); // ropar på basklassens metod(Karaktär.TaSkada) och skickar med det ev modifierade svaret av skada.
        }
        public override string ToString()
        {
            if (Entremedd)
            {
                Entremedd = false;
                return $"Troll: {Namn}, Hälsa: {UrsprungligHälsa}, Skada(kuksmäll): {KukSmäll}."
                    + $" lider av fetma. Hälsa -{Fetma}"
                    + $" Ny hälsa: {Hälsa} specialförmåga: övertygelse";
            }
            else
            {
                return $"Troll: {Namn}, Hälsa: {Hälsa}, Skada(kuksmäll): {KukSmäll}.";
            }
        }

        public void Attackera(Karaktär mål) // du måste skicka in en karaktär att attacker, "mål" är objektet som attackeras
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"{Namn} attackerar {mål.Namn}!"); //måste göra detta för varje .cs fil för att attackerna ska vara speciella.
            mål.TaSkada(KukSmäll);
            Console.ResetColor();
        }

    }

}