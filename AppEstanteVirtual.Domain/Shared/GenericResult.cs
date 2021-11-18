using AppEstanteVirtual.Domain.Shared.Contracts;

namespace AppEstanteVirtual.Domain.Shared
{
    public class GenericResult: IResult
    {
        public GenericResult(int statusCode, string message, object data)
        {
            StatusCode = statusCode;
            Message = message;
            Data = data;
        }
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}