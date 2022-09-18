using Amazon.DynamoDBv2.DataModel;

namespace Aws.Dynamodb.Svc.Models
{
    [DynamoDBTable("student")]
    public class Student
    {
        [DynamoDBHashKey("id")]
        public int? Id { get; set; }

        [DynamoDBProperty("firstName")]
        public string? FirstName { get; set; }

        [DynamoDBProperty("lastName")]
        public string? LastName { get; set; }

        [DynamoDBProperty("class")]
        public string Class { get; set; }

        [DynamoDBProperty("unity")]
        public string? Unity { get; set; }

        [DynamoDBProperty("city")]
        public string? City { get; set; }

        [DynamoDBProperty("country")]
        public string? Country { get; set; }
    }
}
