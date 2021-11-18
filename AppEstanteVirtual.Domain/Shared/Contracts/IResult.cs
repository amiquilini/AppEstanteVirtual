namespace AppEstanteVirtual.Domain.Shared.Contracts
{
    public interface  IResult
    {
        int StatusCode { get; set; }
        string Message { get; set; }
        object Data { get; set; }
    }
}