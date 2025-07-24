namespace MittSpel
{
    public class Karaktär
    {


        public string Namn { get; set; } // get: läser värdet
        public int Hälsa { get; set; } // set: sätter värdet

        public virtual string Typ => "Karaktär"; // virtual kan skrivas över (override) av en klass som ärver från denna
        public Karaktär(string namn, int hälsa) // konstruktorn, byggaren, här skapas 2 variabler
        {
            Namn = namn; // tildellar värdet på parametern namn till egenskapen Namn
            Hälsa = hälsa; // same
        }
        public void TaSkada(int skada) // tar in ett heltal och drar det från karaktärens hälsa
        {
            Hälsa -= skada;
            Console.WriteLine($" {Namn} tar {skada} skada. Hälsa nu: {Hälsa}");
        }
    }
}