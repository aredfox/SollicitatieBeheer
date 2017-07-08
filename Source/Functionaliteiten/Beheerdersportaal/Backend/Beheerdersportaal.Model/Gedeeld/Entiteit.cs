namespace Beheerdersportaal.Model.Gedeeld
{
    public class Entiteit<TSleutel> : IEntiteit<TSleutel>
    {
        public TSleutel Id { get; private set; }

        object IEntiteit.Id => Id;
    }
}
