namespace AppEstanteVirtual.Domain.Shared.Contracts
{
    public interface  IResult
    {
        string Message { get; set; }
        object Data { get; set; }
    }
}