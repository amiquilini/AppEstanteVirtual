using AppEstanteVirtual.Domain.Shared.Contracts;

namespace AppEstanteVirtual.Domain.Shared
{
    public class GenericResult: IResult
    {
        public GenericResult(string message, object data)
        {
            Message = message;
            Data = data;
        }

        public string Message { get; set; }
        public object Data { get; set; }
    }
}