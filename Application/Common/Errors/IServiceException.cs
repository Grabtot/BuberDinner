using System.Net;

namespace BuberDinner.Application.Common.Errors
{
    public interface IServiceException
    {
        string Message { get; }
        int StatusCode { get; }
        HttpStatusCode HttpStatusCode { get; }
    }
}