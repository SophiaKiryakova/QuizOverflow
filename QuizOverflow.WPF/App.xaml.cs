using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using QuizOverflow.Data;
using QuizOverflow.Data.Contracts;
using QuizOverflow.Services.Contracts;
using QuizOverflow.Services.MappingProfiles;
using QuizOverflow.Services.Services;
using System;
using System.Windows;

namespace QuizOverflow.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var serviceProvider = CreateServiceProvider();
            serviceProvider.GetRequiredService<MainWindow>();

            base.OnStartup(e);
        }

        private IServiceProvider CreateServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddScoped<ISeedService, SeedService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IQuizOverflowDbContext, QuizOverflowDbContext>();


            IConfigurationProvider config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            services.AddSingleton(config);
            services.AddScoped<IMapper, Mapper>();

            services.AddSingleton<MainWindow>(s => new MainWindow(s.GetRequiredService<ISeedService>()));

            return services.BuildServiceProvider();
        }
    }
}
