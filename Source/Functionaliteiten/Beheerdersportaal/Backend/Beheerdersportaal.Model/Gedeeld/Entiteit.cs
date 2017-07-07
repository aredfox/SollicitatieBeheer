namespace Beheerdersportaal.Model.Gedeeld
{
    public class Entiteit<TSleutel> : IEntiteit<TSleutel>
    {
        public TSleutel Id { get; }

        object IEntiteit.Id => Id;
    }
}
