using Beheerdersportaal.Model.Afdelingen;
using Beheerdersportaal.Model.Functies;
using Beheerdersportaal.Model.Gedeeld;

namespace Beheerdersportaal.Model.Vacatures
{
    public class Vacature : ArchiveerbareEntiteit<int>
    {
        public int Nummer { get; set; }
        public Functie Functie { get; set; }
        public int FunctieId { get; set; }
        public Afdeling Afdeling { get; set; }
        public int AfdelingId { get; set; }
        public string Omschrijving { get; set; }
    }
}
