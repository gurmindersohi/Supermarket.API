namespace Supermarket.DataTransferModels.Response
{
    using System.Net;

    public class ServiceResponse<T> : BaseResponse
    {
        public T Data { get; private set; }

        private ServiceResponse(bool success, string message, T data, HttpStatusCode statusCode) : base(success, message, statusCode)
        {
            Data = data;
        }

        private ServiceResponse(bool success, string message, HttpStatusCode statusCode) : base(success, message, statusCode)
        { }

        public ServiceResponse(T data, HttpStatusCode statusCode) : this(true, string.Empty, data, statusCode)
        { }

        public ServiceResponse(string message, HttpStatusCode statusCode) : this(false, message, statusCode)
        { }

        public ServiceResponse() : this(true, string.Empty, HttpStatusCode.OK)
        { }
    }
}

