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
            if (ångest > 0)
            {
                Hälsa -= 50;
            }
        }
        public override string ToString()
        {
            return $"Människa: {Namn}, Hälsa: {UrsprungligHälsa}, Skada(kniv): {Kniv}"
            + $" Då {Namn} lider av grov ångest -{Ångest} hälsa\n"
            + $"ny hälsa: {Hälsa}";
        }
        public void Attackera(Karaktär mål)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"{Namn} attackerar {mål.Namn}!");
            mål.TaSkada(Kniv);
            Console.ResetColor();
        }

    }


}