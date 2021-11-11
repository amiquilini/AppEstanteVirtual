using System.Threading.Tasks;
using AppEstanteVirtual.Domain.Shared.Contracts;

namespace AppEstanteVirtual.Domain.Shared
{
    public static class Result
    {
        public static Task<IResult> ResultAsync(string message = "", object data = null)
        {
            return Task.FromResult<IResult>(new GenericResult(message, data));
        }
    }
}