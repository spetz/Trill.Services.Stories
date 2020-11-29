using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Convey;
using Convey.CQRS.Queries;
using Convey.Docs.Swagger;
using Convey.HTTP;
using Convey.MessageBrokers;
using Convey.MessageBrokers.RabbitMQ;
using Convey.Persistence.MongoDB;
using Convey.Persistence.Redis;
using Convey.Types;
using Convey.WebApi;
using Convey.WebApi.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Trill.Services.Stories.Application.Services;
using Trill.Services.Stories.Core.Repositories;
using Trill.Services.Stories.Infrastructure.Contexts;
using Trill.Services.Stories.Infrastructure.Exceptions;
using Trill.Services.Stories.Infrastructure.Logging;
using Trill.Services.Stories.Infrastructure.Mongo;
using Trill.Services.Stories.Infrastructure.Mongo.Documents;
using Trill.Services.Stories.Infrastructure.Mongo.Repositories;
using Trill.Services.Stories.Infrastructure.Protos;
using Trill.Services.Stories.Infrastructure.Services;

namespace Trill.Services.Stories.Infrastructure
{
    public static class Extensions
    {
        public static IConveyBuilder AddInfrastructure(this IConveyBuilder builder)
        {
            builder.Services
                .AddScoped<LogContextMiddleware>()
                .AddSingleton<IRequestStorage, RequestStorage>()
                .AddSingleton<IStoryRequestStorage, StoryRequestStorage>()
                .AddSingleton<IStoryIdGenerator, StoryIdGenerator>()
                .AddSingleton<IDateTimeProvider, DateTimeProvider>()
                .AddScoped<IMessageBroker, MessageBroker>()
                .AddScoped<IStoryRepository, StoryMongoRepository>()
                .AddScoped<IStoryRatingRepository, StoryRatingMongoRepository>()
                .AddScoped<IUserRepository, UserMongoRepository>()
                .AddTransient<IAppContextFactory, AppContextFactory>()
                .AddTransient(ctx => ctx.GetRequiredService<IAppContextFactory>().Create())
                .AddGrpc();

            builder
                .AddErrorHandler<ExceptionToResponseMapper>()
                .AddExceptionToMessageMapper<ExceptionToMessageMapper>()
                .AddQueryHandlers()
                .AddInMemoryQueryDispatcher()
                .AddHttpClient()
                .AddMongo()
                .AddRedis()
                .AddRabbitMq()
                .AddMongoRepository<StoryDocument, long>("stories")
                .AddMongoRepository<UserDocument, Guid>("users")
                .AddWebApiSwaggerDocs();
             
             builder.Services.AddSingleton<ICorrelationIdFactory, CorrelationIdFactory>();

             return builder;
        }
        
        public static long ToUnixTimeMilliseconds(this DateTime dateTime)
            => new DateTimeOffset(dateTime).ToUnixTimeMilliseconds();

        public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
        {
            app.UseMiddleware<LogContextMiddleware>()
                .UseErrorHandler()
                .UseSwaggerDocs()
                .UseConvey()
                .UseMongo();

            app.UseRouting()
                .UseEndpoints(e => e.MapGrpcService<StoryServiceGrpcServer>());

            return app;
        }

        public static Task GetAppName(this HttpContext httpContext)
            => httpContext.Response.WriteAsync(httpContext.RequestServices.GetService<AppOptions>().Name);

        internal static CorrelationContext GetCorrelationContext(this IHttpContextAccessor accessor)
            => accessor.HttpContext?.Request.Headers.TryGetValue("Correlation-Context", out var json) is true
                ? JsonConvert.DeserializeObject<CorrelationContext>(json.FirstOrDefault())
                : null;

        internal static string GetSpanContext(this IMessageProperties messageProperties, string header)
        {
            if (messageProperties is null)
            {
                return string.Empty;
            }

            if (messageProperties.Headers.TryGetValue(header, out var span) && span is byte[] spanBytes)
            {
                return Encoding.UTF8.GetString(spanBytes);
            }

            return string.Empty;
        }
    }
}