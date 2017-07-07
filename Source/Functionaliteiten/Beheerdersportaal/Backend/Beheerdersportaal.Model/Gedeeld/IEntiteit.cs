namespace Beheerdersportaal.Model.Gedeeld
{
    public interface IEntiteit
    {
        object Id { get; }
    }
    public interface IEntiteit<TSleutel> : IEntiteit
    {
        new TSleutel Id { get; }
    }
}
