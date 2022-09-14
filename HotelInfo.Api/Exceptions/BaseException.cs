namespace HotelInfo.Api.Exceptions
{
    public abstract class BaseException : Exception
    {
        public int StatusCode { get; protected set; }

        protected BaseException(string message) : base(message)
        {
        }
    }
}
