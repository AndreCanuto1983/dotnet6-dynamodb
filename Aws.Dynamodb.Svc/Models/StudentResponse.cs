using Aws.Dynamodb.Svc.Interfaces;
using System.Text.Json.Serialization;

namespace Aws.Dynamodb.Svc.Models
{
    public class StudentResponse : IResponseBase
    {
        public bool Success { get; set; }        
        public string Message { get; set; }

        [JsonIgnore]
        public int? StatusCode { get; set; }
    }
}
