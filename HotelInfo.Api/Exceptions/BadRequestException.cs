using System.Net;

namespace HotelInfo.Api.Exceptions
{
    public class BadRequestException : BaseException
    {
        public BadRequestException(string message) : base(message)
        { 
            StatusCode = (int)HttpStatusCode.BadRequest;
        }
    }
}
