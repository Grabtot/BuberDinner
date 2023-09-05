using System.Net;

namespace BuberDinner.Application.Common.Errors
{
    public class DuplicateEmailException : Exception, IServiceException
    {
        private HttpStatusCode _statusCode = HttpStatusCode.Conflict;
        public override string Message => "Account already exists";

        public int StatusCode => (int)_statusCode;

        public HttpStatusCode HttpStatusCode => _statusCode;
    }
}
