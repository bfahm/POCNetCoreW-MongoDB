using AuthenticatedMongoDb.Options;
using AuthenticatedMongoDb.Repositories;
using AuthenticatedMongoDb.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticatedMongoDb.Installers
{
    public class ServicesInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            // Register here any Repositories that will be used:
            services.AddScoped<IUserRepository, UserRepository> ();

            // Register here any Services that will be used:
            services.AddScoped<IAuthenticationService, AuthenticationService> ();
        }
    }
}
