namespace MittSpel
{
    public class Karaktär
    {


        public string Namn { get; set; } // get: läser värdet
        public int Hälsa { get; set; } // set: sätter värdet
        public int UrsprungligHälsa { get; set; }

        public virtual string Typ => "Karaktär"; // virtual kan skrivas över (override) av en klass som ärver från denna
        public bool ärDöd => Hälsa <= 0; // är hälsa mindre eller lika med 0? isf returnera true/false
        public Karaktär(string namn, int hälsa, int ursprungligHälsa) // konstruktorn, byggaren, här skapas 2 variabler
        {
            Namn = namn; // tildellar värdet på parametern namn till egenskapen Namn
            Hälsa = hälsa; // same
            UrsprungligHälsa = ursprungligHälsa;
        }
        public virtual void TaSkada(int skada) // tar in ett heltal och drar det från karaktärens hälsa
        // måste vara virtual så vi kan override:a denna i troll.cs
        {
            Hälsa -= skada;
            if (Hälsa <= 0)
            {
                Hälsa = 0;
            }
        }
        public virtual void Vila()
        {
            Hälsa += 50;
            if (Hälsa > 250)
                Hälsa = 250;
            Console.WriteLine($"{Namn} vilar och återfår 50 i hälsa. Nuvarande hälsa: {Hälsa}"); // detta används genom t.Vila():
        }
    }
}