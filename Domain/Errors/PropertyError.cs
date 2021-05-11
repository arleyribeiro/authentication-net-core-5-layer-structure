using System.Net;

namespace Domain.Errors
{
    public class PropertyError
    {
        public int Code { get; set; }
        public string PropertyName { get; set; }
    }
}