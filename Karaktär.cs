namespace MittSpel
{
    public class Karaktär
    {


        public string Namn { get; set; } // get: läser värdet
        public int Hälsa { get; set; } // set: sätter värdet
        public int UrsprungligHälsa { get; set; }

        public virtual string Typ => "Karaktär"; // virtual kan skrivas över (override) av en klass som ärver från denna
        public Karaktär(string namn, int hälsa, int ursprungligHälsa) // konstruktorn, byggaren, här skapas 2 variabler
        {
            Namn = namn; // tildellar värdet på parametern namn till egenskapen Namn
            Hälsa = hälsa; // same
            UrsprungligHälsa = ursprungligHälsa;
        }
        public void TaSkada(int skada) // tar in ett heltal och drar det från karaktärens hälsa
        {
            Hälsa -= skada;
            Console.WriteLine($" {Namn} tar {skada} skada."
            + $"Tidigare hälsa: {UrsprungligHälsa}"
            + $" Ny Hälsa: {Hälsa}");
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