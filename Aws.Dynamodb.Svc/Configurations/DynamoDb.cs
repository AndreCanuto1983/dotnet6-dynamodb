using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;

namespace Aws.Dynamodb.Svc.Configurations
{
    public static class DynamoDb
    {
        public static void DynamoDbSettings(this WebApplicationBuilder builder)
        {
            builder.Services.AddDefaultAWSOptions(
                builder.Configuration.GetAWSOptions()
                );
            builder.Services.AddAWSService<IAmazonDynamoDB>();
            builder.Services.AddScoped<IDynamoDBContext, DynamoDBContext>();
        }
    }
}
