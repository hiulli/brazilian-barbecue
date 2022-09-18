using BrazilianBarbecue.Core.Interfaces;
using BrazilianBarbecue.Core.Services;
using BrazilianBarbecue.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BrazilianBarbecue.Infrastructure.IoC
{
    public class IoCServiceRegister
    {
        public static void Register(IServiceCollection services)
        {
            //Add Service            
            services.AddScoped<IParticipantService, ParticipantService>();
            services.AddScoped<IBarbecueService, BarbecueService>();
            services.AddScoped<IBarbecueParticipantService, BarbecueParticipantService>();

            //Add Repository            
            services.AddScoped<IParticipantRepository, ParticipantRepository>();
            services.AddScoped<IBarbecueRepository, BarbecueRepository>();
            services.AddScoped<IBarbecueParticipantRepository, BarbecueParticipantRepository>();
        }
    }
}
