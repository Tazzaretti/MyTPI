using Service.Iservices;
using Service.Service;
namespace MyTest
{
    public static class CompositeRoot
    { 
        public static void DependecyInjection (WebApplicationBuilder builder) 
        {
            builder.Services.AddScoped<IUserSerivice,UserSerivice>();
            builder.Services.AddScoped<IAuthService, AuthSerivce>();
        }

    }
}
