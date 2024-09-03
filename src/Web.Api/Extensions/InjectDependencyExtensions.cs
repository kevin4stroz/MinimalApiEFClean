using Web.Infraestructure.Interfaces;
using Web.Infraestructure.Implementation;
using Web.Domain.Interfaces;
using Web.Domain.Implementation;
using Web.Application.Interfaces;
using Web.Application.Implementation;
using Web.Api.Endpoints.Quiz;
using Web.Api.Endpoints;
using Microsoft.EntityFrameworkCore;

namespace Web.Api.Extensions
{
    public static class InjectDependencyExtensions
    {
        public static WebApplicationBuilder AddDependency(this WebApplicationBuilder container, IConfiguration configuration)
        {
            // Configuration
            container.Services.AddSingleton<IConfiguration>(configuration);

            // Context db
            var connectionString = container.Configuration.GetConnectionString("DefaultConnection");
            container.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(connectionString, sqlOptions =>
                    sqlOptions.MigrationsAssembly("Web.Api")
                )
            );

            // Infraestructure
            container.Services.AddScoped<IQuestionsRepository, QuestionsRepository>();
            container.Services.AddScoped<ICategoryRepository, CategoryRepository>();

            // Domain
            container.Services.AddScoped<IQuestionsDomain, QuestionsDomain>();

            // Application
            container.Services.AddScoped<IQuestionsApplication, QuestionsApplication>();

            // Endpoints
            container.Services.AddScoped<EndpointQuestions>();
            container.Services.AddScoped<IEndpoint, EndpointQuestions>();


            return container;
        }
    }
}
