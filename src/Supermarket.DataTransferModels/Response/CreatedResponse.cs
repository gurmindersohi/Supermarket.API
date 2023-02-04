namespace Supermarket.DataTransferModels.Response
{
    using System.Net;

    public class CreatedResponse<T> : ServiceResponse<T>
    {
        public int Id { get; private set; }

        public string CreatedAtRoute { get; private set; }

        public CreatedResponse(int id, string createdAtRoute) : base()
        {
            Id = id;
            CreatedAtRoute = createdAtRoute;
            StatusCode = HttpStatusCode.Created;
        }
    }
}