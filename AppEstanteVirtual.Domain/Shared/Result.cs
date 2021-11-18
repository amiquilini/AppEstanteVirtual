using System.Threading.Tasks;
using AppEstanteVirtual.Domain.Constants;
using AppEstanteVirtual.Domain.Shared.Contracts;
using Microsoft.AspNetCore.Http;

namespace AppEstanteVirtual.Domain.Shared
{
    public static class Result
    {
        public static Task<IResult> ResultAsync(int statusCode, string message, object data = null)
        {
            return Task.FromResult<IResult>(new GenericResult(statusCode, message, data));
        }
        public static Task<IResult> ResultAsync(int statusCode, object data = null)
        {
            return Task.FromResult<IResult>(new GenericResult(statusCode, GlobalMessageConstants.MessageEmpty, data));
        }
    }
}