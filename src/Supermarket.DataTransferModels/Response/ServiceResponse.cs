namespace Supermarket.DataTransferModels.Response
{
    public class ServiceResponse<T> : BaseResponse
    {
        public T Data { get; private set; }

        private ServiceResponse(bool success, string message, T data) : base(success, message)
        {
            Data = data;
        }

        private ServiceResponse(bool success, string message) : base(success, message)
        { }

        public ServiceResponse(T data) : this(true, string.Empty, data)
        { }

        public ServiceResponse(string message) : this(false, message)
        { }

        public ServiceResponse() : this(true, string.Empty)
        { }
    }
}

