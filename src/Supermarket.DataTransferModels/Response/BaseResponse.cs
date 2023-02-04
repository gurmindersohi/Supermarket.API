namespace Supermarket.DataTransferModels.Response
{
    using System.Net;

    public abstract class BaseResponse
    {
        public bool Success { get; protected set; }
        public string Message { get; protected set; }
        public HttpStatusCode StatusCode { get; protected set; }

        public BaseResponse(bool success, string message, HttpStatusCode statusCode)
        {
            Success = success;
            Message = message;
            StatusCode = statusCode;
        }
    }
}

