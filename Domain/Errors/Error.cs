using System.Net;

namespace Domain.Errors
{
    public class Error
    {
        public int Code { get; set; }
        public string Description { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}