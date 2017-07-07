using System;

namespace Beheerdersportaal.Model.Gedeeld
{
    public class ArchiveerbareEntiteit<TSleutel> : Entiteit<TSleutel>, IArchiveerbaar
    {
        public bool IsGearchiveerd { get; set; }
        public DateTime TijdstipAangemaaktUtc { get; set; }
        public DateTime TijdstipLaatstGewijzigdUtc { get; set; }
    }
}
