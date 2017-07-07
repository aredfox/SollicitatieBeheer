using System;

namespace Beheerdersportaal.Model.Gedeeld
{
    public interface IArchiveerbaar
    {
        bool IsGearchiveerd { get; set; }
        DateTime TijdstipAangemaaktUtc { get; set; }
        DateTime TijdstipLaatstGewijzigdUtc { get; set; }
    }
}