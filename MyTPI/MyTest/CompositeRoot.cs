using Service.Iservices;
using Service.Service;
namespace MyTest
{
    public static class CompositeRoot
    { 
        public static void DependecyInjection (WebApplicationBuilder builder) 
        {
            builder.Services.AddScoped<IUserService,UserSerivice>();
            builder.Services.AddScoped<IAuthService, AuthSerivce>();
            builder.Services.AddScoped<IProductosService, ProductosService>();
            builder.Services.AddScoped<IEnviosService, EnviosService>();
            builder.Services.AddScoped<IVariantesService, VariantesService>();
            builder.Services.AddScoped<IVentasService, VentasService>();

        }

    }
}
