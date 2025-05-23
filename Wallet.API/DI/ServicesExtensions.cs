using Wallet.Infrastructure.Repository.Interfaces.Users;
using Wallet.Infrastructure.Repository.Interfaces.Wallets;
using Wallet.Infrastructure.Repository.Repositories.Users;
using Wallet.Infrastructure.Repository.Repositories.Wallets;
using Wallet.Services.Service.Interfaces;
using Wallet.Services.Service.Services;

namespace Wallet.API.DI
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddAplication(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService,UserService>();

            services.AddScoped<IAuthService, AuthService>();

            services.AddScoped<IWalletRepository, WalletRepository>();
            services.AddScoped<IWalletService, WalletService>();
            return services;
        }
    }
}
