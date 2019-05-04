using System.Net;

namespace HotelInfo.Api.Exceptions
{
    public class NotFoundException : BaseException
    {
        public NotFoundException(string message) : base(message)
        {
            StatusCode = (int)HttpStatusCode.NotFound;
        }
    }
}
