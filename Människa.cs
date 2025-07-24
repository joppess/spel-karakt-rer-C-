namespace MittSpel
{
    public class Människa : Karaktär
    {
        public int Ångest { get; set; }
        public int Kniv { get; set; }

        public override string Typ => "Männsika";

        public Människa(int hälsa, int ångest, int kniv, string namn)
        : base(namn, hälsa)
        {

        }

    }





}