using SelfieAWookies.Core.Selfies.Domain;
using SelfieAWookies.Core.Selfies.Infrastructures.Repositories;

namespace SelfieAWookie.API.UI._6.Controllers.ExtensionMethods
{
    public static class DIMethods
    {
        /// <summary>
        /// Prepare Custums Dependency Injection
        /// </summary>
        /// <param name="services"></param>
        #region Public Methods
        
        public static void AddInjections(this IServiceCollection services) // On veut regrouper toutes les parties que l'on souhaite.
        {
            services.AddScoped<ISelfieRepository>();
        }  
        #endregion

    }
}
