using Aws.Dynamodb.Svc.Interfaces;
using Aws.Dynamodb.Svc.Repository;

namespace Aws.Dynamodb.Svc.Configurations
{
    public static class DependencyInjection
    {
        public static void DependencyInjectionSettings(this IServiceCollection services)
        {
            services.AddScoped<IStudentRepository, StudentRepository>();
        }
    }
}
