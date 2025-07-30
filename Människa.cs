namespace MittSpel
{
    public class Människa : Karaktär
    {
        public int Ångest { get; set; }
        public int Kniv { get; set; }

        public override string Typ => "Människa";

        public Människa(int hälsa, int UrsprungligHälsa, int ångest, int kniv, string namn)
        : base(namn, hälsa, UrsprungligHälsa)
        {
            Ångest = ångest;
            Kniv = kniv;
        }
        public override string ToString()
        {
            return $"Människa: Namn: {Namn}, Hälsa: {Hälsa} Ångest:{Ångest}, Skada(kniv): {Kniv}.";
        }
        public void Attackera(Karaktär mål)
        {
            Console.WriteLine($"{Namn} attackerar {mål.Namn}!");
            mål.TaSkada(Kniv);
        }

    }
    // fixa ångest

}