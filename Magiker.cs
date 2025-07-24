
namespace MittSpel
{

    public class Magiker : Karaktär // subklass som ärver från Karaktär
    {
        public int Mana { get; set; } // skapar egenskapen mana som lagrar heltal
        public int EldKlot { get; set; }
        public override string Typ => "Magiker"; // => är samma som  get {return "Gandalf";}

        public Magiker(int mana, int hälsa, int eldKlot, string namn)
        : base(namn, hälsa) // skickar namn och hälsa till karaktärens konstruktor
        {
            Mana = mana; //sätter mana
            EldKlot = eldKlot;
        }


    }
}