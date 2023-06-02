using DemoGraphQL.Services;
using DemoGraphQL.Workerrs;
using HotChocolate.AspNetCore;

namespace DemoGraphQL;

internal static class Program
{
    public static void Main(string[] args)
    {
        var app = CreateWebApplication(args);

        ConfigureApplication(app);

        app.Run();
    }

    private static WebApplication CreateWebApplication(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add API services to the container.
        builder.Services.AddControllers();
        builder.Services.AddSwaggerGen();

        //Add GraphQL services and configure options
        builder.Services
            .AddGraphQLServer()
            //In memory subscriptions triggered from inside the application
            .AddInMemorySubscriptions()
            .AddQueryType<Queries.BookQuery>()
            .AddMutationType<Mutations.BookMutation>()
            .AddSubscriptionType<Subscriptions.BookUpdates>()
            //Initialise the schema on startup before any requests are made, helps catch schema errors early
            .InitializeOnStartup();

        //Add our services to the container
        AddServices(builder);

        var app = builder.Build();
        return app;
    }

    private static void AddServices(WebApplicationBuilder builder)
    {
        builder.Services.AddSingleton<BookRepository>();
        builder.Services.AddHostedService<BackgroundWorker>();
    }

    private static void ConfigureApplication(WebApplication app)
    {
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();

        // Add GraphQL middleware
        app.MapGraphQL().WithOptions(new GraphQLServerOptions
        {
            //Configure the GraphQL UI
            Tool =
            {
                //Set the GraphQL UI title to application name
                Title = nameof(DemoGraphQL),

                //Disable telemetry reporting to HotChocolate
                DisableTelemetry = true
            }
        });
        // Add websockets for GraphQL Subscriptions
        app.UseWebSockets();
    }
}