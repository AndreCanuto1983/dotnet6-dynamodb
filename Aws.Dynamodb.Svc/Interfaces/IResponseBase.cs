using System.Text.Json.Serialization;

namespace Aws.Dynamodb.Svc.Interfaces
{
    public interface IResponseBase
    {        
        public bool Success { get; set; }
        public string Message { get; set; }

        [JsonIgnore]
        public int? StatusCode { get; set; }
    }
}
