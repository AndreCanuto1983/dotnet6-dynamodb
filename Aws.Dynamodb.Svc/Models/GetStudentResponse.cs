using Aws.Dynamodb.Svc.Interfaces;
using System.Text.Json.Serialization;

namespace Aws.Dynamodb.Svc.Models
{
    public class GetStudentResponse<T> : IResponseBase
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }        

        [JsonIgnore]
        public int? StatusCode { get; set; }
    }
}
